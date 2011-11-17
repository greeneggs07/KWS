using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InputData
{
    public class InputData
    {

        protected int action;
        protected Vector3 point;

        public InputData(Vector3 point = new Vector3(), int action = 0)
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
