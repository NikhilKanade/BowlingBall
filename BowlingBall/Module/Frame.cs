using BowlingBall.Factory;
using System.Collections.Generic;

namespace BowlingBall.Module
{
    /// <summary>
    /// Frame with list of balls & Frame wise score 
    /// </summary>
    public class Frame
    {
        private List<Ball> _balls;
        private int _frameScore;
        public Frame()
        {
            _balls = FactoryService.GetBalls();
        }

        public List<Ball> balls { get => _balls; set => _balls = value; }
        public int frameScore { get => _frameScore; set => _frameScore = value; }

    }
}
