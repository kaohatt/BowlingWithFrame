using System.Collections;

namespace BowlingWithFrame
{
    //class
    public class BowlingGame
    {
        //fields
        ArrayList throws;
        ArrayList frames;

        //constructor
        public BowlingGame() {
            throws = new ArrayList();
            frames = new ArrayList();
        }

        //method
        public void OpenFrame(int firstThrow, int secondThrow)
        {
            frames.Add(new OpenFrame(throws, firstThrow,secondThrow));
        }

        //method
        public void Spare(int firstThrow, int secondThrow)
        {
            frames.Add(new SpareFrame(throws, firstThrow,secondThrow));
        }

        //method
        public void Strike()
        {
            frames.Add(new StrikeFrame(throws));
        }

        //method
        public void BonusRoll(int roll)
        {
            frames.Add(new BonusRoll(throws, roll));
        }

        //method
        public int Score()
        {
            int total = 0;
            foreach (Frame frame in frames)
                total += frame.Score();
            return total;
        }
    }
}