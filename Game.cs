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
        private readonly List<Frame> _frames;
        private int FinalScore = 0;
        private int i = 0;
        private int j = 0;
        private Frame frame = null;
        
        public Game()
        {
            _frames = FactoryService.GetFrames();
        }

        /// <summary>
        /// call to Throw a ball to Roll & store score & calculate final result
        /// </summary>
        /// <param name="pins"></param>
        public void Roll(int pins)
        {
            //get new frame if frame 
            if (frame == null)
                frame = FactoryService.GetFrame();

            //to detect next frame
            if (2 <= j)
            {
                i++;
                j = 0;
                //get new frame for current result 
                frame = FactoryService.GetFrame();
            }

            //call to get ball object
            Ball ball = FactoryService.GetBall();

            //Validate & Convert inputs to integer
            //check ball score & balls collection
            // if score is 10 in first ball then it is strike, then you can get 2 ball roll to score current frame
            // if score is 10 in both balla then it is spare, then you can get one ball roll to score for current frame
            // if score is less than 10 in both balls then no next calculation, it will calculate current frame only
            if (ball.Roll(pins, frame?.balls))
            {
                //here strike, now check previous frames ball scores for calculation if any exist
                //else continue for next calculation or next ball roll
                FinalScore = ball.Calculate(i, FinalScore, j, _frames, frame);
                
                //strike no need to add next ball
                j = 2;
            }
            else//here none/spare, check previous frames ball scores for calculation if any exist else continue for next calculation or next ball roll
                FinalScore = ball.Calculate(i, FinalScore, j, _frames, frame);

            //Add frames after ball throw for roll & store the result
            if (j >= 1)
                _frames.Add(frame);
            //increase to check for next ball/frame
            j++;

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
