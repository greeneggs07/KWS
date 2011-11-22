using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KWS
{
    public class InputData
    {

        public int action;
        public Vector3 point;

        public InputData(Vector3 point, int action = 0)
        {
            this.action = action;
            this.point = point;
        }

        public int getAction()
        {
            return action;
        }

        public Vector3 getPoint()
        {
            return point;
        }
    }
}
