using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingWithFrame
{
    public class BonusRoll : Frame
    {
        //constructor
        public BonusRoll(ArrayList throws, int firstThrow): base(throws)
        {
            throws.Add(firstThrow);
        }

        public override int Score()
        {
            return 0;
        }

        protected override int FrameSize()
        {
            return 0;
        }
    }
    
}
