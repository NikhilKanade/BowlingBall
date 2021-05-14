using BowlingBall.Module;
using System.Collections.Generic;

namespace BowlingBall.Factory
{
    /// <summary>
    /// Objet creational for Ball, Frame & list of frames
    /// </summary>
    public class FactoryService
    {

        /// <summary>
        /// Create a new Frame object for iterations
        /// </summary>
        /// <returns></returns>
        public static Frame GetFrame()
        {
            return new Frame();
        }

        /// <summary>
        /// Create new Ball object for frame's ball wise iterations
        /// </summary>
        /// <returns></returns>
        public static Ball GetBall()
        {
            return new Ball();
        }

        /// <summary>
        /// Initialise list of frames at start 
        /// </summary>
        /// <returns></returns>
        public static List<Frame> GetFrames()
        {
            return new List<Frame>();
        }

        /// <summary>
        /// Initialise list of balls at start 
        /// </summary>
        /// <returns></returns>
        public static List<Ball> GetBalls()
        {
            return new List<Ball>();
        }
    }
}
