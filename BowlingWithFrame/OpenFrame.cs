using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingWithFrame
{
    //OpenFrame class extends Frame superclass
    public class OpenFrame : Frame
    {
        
        //constructor
        public OpenFrame(ArrayList throws, int firstThrow , int secondThrow) : base(throws)
        {
            throws.Add(firstThrow);
            throws.Add(secondThrow);
        }

        //method
        override public int Score()
        {
            return (int) throws[startingThrow] + (int) throws[startingThrow + 1];
        }

        protected override int FrameSize()
        {
            return 2;
        }
    }
}
