using BowlingBall.Common;
using BowlingBall.Factory;
using BowlingBall.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingBall
{
    /// <summary>
    /// Bowling Ball Game
    /// </summary>
    public class Game
    {
        private readonly List<Frame> Frames;
        private int FinalScore = Constants.Zero;
        private int FrameCount = Constants.Zero;
        private int BallCount = Constants.Zero;
        private Frame Frame = null;
        
        public Game()
        {
            Frames = BowlingFactoryService.GetFrames();
        }

        /// <summary>
        /// call to Throw a ball to Roll & store score & calculate final result
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            //get new frame if frame 
            if (Frame == null)
                Frame = BowlingFactoryService.GetFrame();

            //to detect next frame
            if (Constants.Two <= BallCount)
            {
                FrameCount++;
                BallCount = Constants.Zero;
                //get new frame for current result 
                Frame = BowlingFactoryService.GetFrame();
            }

            //call to get ball object
            Ball ball = BowlingFactoryService.GetBall();
            bool isSingleBall = false;
            //Validate & Convert inputs to integer
            //check ball score & balls collection
            // if score is 10 in first ball then it is strike, then you can get 2 ball roll to score current frame
            // if score is 10 in both balla then it is spare, then you can get one ball roll to score for current frame
            // if score is less than 10 in both balls then no next calculation, it will calculate current frame only
            FinalScore = ball.Roll(pins, FrameCount, FinalScore, BallCount, Frames, Frame, out isSingleBall);
            if(isSingleBall)
                BallCount = Constants.Two;

            //Add frames after ball throw for roll & store the result
            if (BallCount >= Constants.One)
                Frames.Add(Frame);
            //increase to check for next ball/frame
            BallCount++;

        }

        /// <summary>
        /// Get final score
        /// </summary>
        /// <returns></returns>
        public int GetScore()
        {
            // Returns the final score of the game.
            return FinalScore;
        }
    }
}
