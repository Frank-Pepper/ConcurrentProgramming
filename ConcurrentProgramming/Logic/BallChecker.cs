using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class BallChecker : IChecker
    {
        public BallChecker() { }

        void IChecker.Check(List<IBall> Balls)
        {
            for (int i = 0; i < Balls.Count; i++)
            {
                bool collision = false;
                int ballRadius = 0; // TODO Find nice number
                for (int j = i+1;  j < Balls.Count; j++)
                {
                    
                    Double distance
                }
            }
        }
    }
}
