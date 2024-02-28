using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingWithFrame
{
    //SpareFrame class extends Frame superclass
    public class SpareFrame : Frame
    {
        //constructor
        public SpareFrame(ArrayList throws, int firstThrow,int secondThrow):base (throws)
        {
            throws.Add(firstThrow);
            throws.Add(secondThrow);
        }

        override public int Score()
        {
            return 10 + FirstBonusBall();
        }

        protected override int FrameSize()
        {
            return 2;
        }
    }
}
