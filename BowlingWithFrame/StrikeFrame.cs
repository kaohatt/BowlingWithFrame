using System.Collections;

namespace BowlingWithFrame
{
    //StrikeFrame class extends Frame superclass
    public class StrikeFrame : Frame
    {
        //constructor
        public StrikeFrame(ArrayList throws):base(throws)
        {
            throws.Add(10);
        }

        override public int Score()
        {
            return 10 + FirstBonusBall() + SecondBonusBall(); 
        }

        protected override int FrameSize()
        {
            return 1;
        }

    }
}