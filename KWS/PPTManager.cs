using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PPT = Microsoft.Office.Interop.PowerPoint;
using Core = Microsoft.Office.Core;

namespace PowerPoint
{
    class PPTManager
    {
        private PPT.Application app;
        private PPT.Presentation pres;
        private PPT.SlideShowSettings sss;
        private PPT.SlideShowWindow ssw;
        private PPT.SlideShowView ssv;

        Boolean loaded = false;
        Boolean visible = false;

        public int loadFile(String filename)
        {
            //Create app and open file
            app = new PPT.Application();
            pres = app.Presentations.Open(filename, Core.MsoTriState.msoFalse,
                Core.MsoTriState.msoFalse, Core.MsoTriState.msoFalse);

            if (pres == null)
            {
                sss = null;
                ssw = null;
                ssv = null;

                loaded = false;
                visible = false;
                return -1;
            }

            app.Visible = Core.MsoTriState.msoFalse;

            sss = pres.SlideShowSettings;
            sss.ShowType = PPT.PpSlideShowType.ppShowTypeKiosk;
            ssw = sss.Run();
            ssv = ssw.View;

            loaded = true;
            visible = true;
            return pres.Slides.Count;
        }

        public void export()
        {
            if (loaded)
            {
                for (int i = 1; i <= pres.Slides.Count; i++)
                {
                    pres.Slides._Index(i).Export("C:\\Users\\tjg3027\\testslides\\Slide" + i + ".jpg", "jpg", 640, 480);
                }
            }
        }

        public void end()
        {
            if (loaded)
            {
                pres.Close();
                app.Quit();

                sss = null;
                ssw = null;
                ssv = null;

                loaded = false;
                visible = false;
            }
        }

        public void setSize(int x, int y)
        {
            if (loaded)
            {
                ssw.Width = x;
                ssw.Height = y;
            }
        }

        public void setPosition(int x, int y)
        {
            if (loaded)
            {
                ssw.Left = x;
                ssw.Top = y;
            }
        }

        public void setSlide(int index)
        {
            if (loaded)
            {
                ssv.GotoSlide(index);
            }
        }

        public void show()
        {
            app.Visible = Core.MsoTriState.msoTrue;
        }

        public void hide()
        {
            app.Visible = Core.MsoTriState.msoFalse;
        }

        public void draw(int x1, int y1, int x2, int y2)
        {
            if (loaded)
            {
                ssv.DrawLine(x1, y1, x2, y2);
            }
        }

        public void erase()
        {
            if (loaded)
            {
                ssv.EraseDrawing();
            }
        }
    }
}
