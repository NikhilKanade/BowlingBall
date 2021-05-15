using BowlingBall.Factory;
using System.Collections.Generic;

namespace BowlingBall.Module
{
    /// <summary>
    /// Frame with list of balls & Frame wise score 
    /// </summary>
    public class Frame
    {
        public List<Ball> Balls { get; set; }
        public int FrameScore { get; set; }
        public Frame()
        {
            Balls = BowlingFactoryService.GetBalls();
        }

    }
}
