using System;
using System.Collections.Generic;
using Microsoft.Research.Kinect.Nui;
using Vector = Microsoft.Research.Kinect.Nui.Vector;

namespace InputData
{
    public class GestureDetector
    {
        const float SwipeMinimalLength = 0.4f;
        const float SwipeMaximalHeight = 0.2f;
        const float SwipeMaximalWidth = 0.2f;
        const int SwipeMininalDuration = 250;
        const int SwipeMaximalDuration = 2500;
        
        public int MinimalPeriodBetweenGestures { get; set; }

        readonly List<Entry> entries = new List<Entry>();

        public event Action<int> OnGestureDetected;

        DateTime lastGestureDate = DateTime.Now;

        InputData gestureData = new InputData();

        readonly int windowSize;
        
        public InputData getGesture()
        {
            return gestureData;
        }

        protected GestureDetector(int windowSize = 20)
        {
            this.windowSize = windowSize;
            MinimalPeriodBetweenGestures = 0;
        }

        protected List<Entry> Entries
        {
            get { return entries; }
        }

        public int WindowSize
        {
            get { return windowSize; }
        }

        public virtual void Add(Vector position, SkeletonEngine engine)
        {
            Entry newEntry = new Entry { Position = position.ToVector3(), Time = DateTime.Now };
            Entries.Add(newEntry);
            LookForGesture();
        }
        protected void getCurrentPoint()
        {
            Entries.ForEach(e =>
            {
                gestureData = new InputData(e.Position);
            });
            Entries.Clear();
        }

        protected void RaiseGestureDetected(int gesture)
        {
            if (DateTime.Now.Subtract(lastGestureDate).TotalMilliseconds > MinimalPeriodBetweenGestures)
            {
                if (OnGestureDetected != null)
                    OnGestureDetected(gesture);

                lastGestureDate = DateTime.Now;
            }
            Entries.ForEach(e =>
            {
                gestureData = new InputData(e.Position, gesture);
            });
            Entries.Clear();
        }
        
        bool ScanPositions(Func<Vector3, Vector3, bool> heightFunction, Func<Vector3, Vector3, bool> directionFunction, Func<Vector3, Vector3, bool> lengthFunction, int minTime, int maxTime)
        {
            int start = 0;

            for (int index = 1; index < Entries.Count - 1; index++)
            {
                if (!heightFunction(Entries[0].Position, Entries[index].Position) || !directionFunction(Entries[index].Position, Entries[index + 1].Position))
                {
                    start = index;
                }

                if (lengthFunction(Entries[index].Position, Entries[start].Position))
                {
                    double totalMilliseconds = (Entries[index].Time - Entries[start].Time).TotalMilliseconds;
                    if (totalMilliseconds >= minTime && totalMilliseconds <= maxTime)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        protected void LookForGesture()
        {
            // Swipe to right
            if (ScanPositions((p1, p2) => Math.Abs(p2.Y - p1.Y) < SwipeMaximalHeight, // Height
                (p1, p2) => p2.X - p1.X > -0.01f, // Progression to right
                (p1, p2) => Math.Abs(p2.X - p1.X) > SwipeMinimalLength, // Length
                SwipeMininalDuration, SwipeMaximalDuration)) // Duration
            {
                RaiseGestureDetected(1);
                return;
            }

            // Swipe to left
            if (ScanPositions((p1, p2) => Math.Abs(p2.Y - p1.Y) < SwipeMaximalHeight,  // Height
                (p1, p2) => p2.X - p1.X < 0.01f, // Progression to left
                (p1, p2) => Math.Abs(p2.X - p1.X) > SwipeMinimalLength, // Length
                SwipeMininalDuration, SwipeMaximalDuration))// Duration
            {
                RaiseGestureDetected(2);
                return;
            }

            // Swipe down to up
            if (ScanPositions((p1, p2) => Math.Abs(p2.X - p1.X) < SwipeMaximalWidth, // Width
                (p1, p2) => p2.Y - p1.Y > -0.01f, // Progression up
                (p1, p2) => Math.Abs(p2.Y - p1.Y) > SwipeMinimalLength, // Length
                SwipeMininalDuration, SwipeMaximalDuration)) // Duration
            {
                RaiseGestureDetected(3);
                return;
            }
            // Swipe down to up
            if (ScanPositions((p1, p2) => Math.Abs(p2.X - p1.X) < SwipeMaximalWidth, // Width
                (p1, p2) => p2.Y - p1.Y < 0.01f, // Progression down
                (p1, p2) => Math.Abs(p2.Y - p1.Y) > SwipeMinimalLength, // Length
                SwipeMininalDuration, SwipeMaximalDuration)) // Duration
            {
                RaiseGestureDetected(4);
                return;
            }
        }
    }
}