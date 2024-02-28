using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingWithFrame
{
    //Frame superclass 
    abstract public class Frame 
    {
        //field
        protected ArrayList throws;
        protected int startingThrow;

        //constructor
        public Frame(ArrayList throws)
        {
            this.throws = throws;
            this.startingThrow = throws.Count;
        }

        public abstract int Score();
        protected abstract int FrameSize();
        protected int FirstBonusBall()
        {
            return (int)throws[startingThrow + FrameSize()];
        }

        protected int SecondBonusBall()
        {
            return (int)throws[startingThrow + FrameSize()+1];
        }
    }

}
