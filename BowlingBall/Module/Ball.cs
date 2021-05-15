using BowlingBall.Common;
using BowlingBall.Factory;
using System;
using System.Collections.Generic;

namespace BowlingBall.Module
{
    public class Ball
    {
        public int BallScore { get; set; }
        public BallThrow BallThrow { get; set; }

        /// <summary>
        /// Throw ball for roll to get score & find throw result
        /// </summary>
        /// <param name="score"></param>
        /// <param name="balls"></param>
        /// <returns>true - if throw result strike
        /// false - if throw result either none or spare </returns>
        public int Roll(int score, int frameCount, int finalScore, int ballCount, List<Frame> frames, Frame frame, out bool isSingle)
        {
            try
            {
                BallScore = score;
                if (score < Constants.Score10)
                {
                    BallThrow = BallThrow.NoScore;
                    if (frame.Balls.Count == Constants.One && frame.Balls[Constants.Zero].BallScore + BallScore >= Constants.Score10)
                        BallThrow = BallThrow.Spare;
                }
                else if (score >= Constants.Score10 && frame.Balls.Count == Constants.One && frame.Balls[Constants.Zero].BallScore + BallScore >= Constants.Score10)
                    BallThrow = BallThrow.Spare;
                else
                {
                    BallThrow = BallThrow.Strike;
                    frame.Balls.Add(this);
                    isSingle = true;
                    return Calculate(frameCount, finalScore, ballCount, frames, frame);
                }
                frame.Balls.Add(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption Occurred {ex.Message}");
            }
            isSingle = false;
            return Calculate(frameCount, finalScore, ballCount, frames, frame);
        }

        /// <summary>
        /// Calculate Frame score with respect to each ball throw
        /// </summary>
        /// <param name="FrameCount">nth Frame</param>
        /// <param name="FinalScore"></param>
        /// <param name="BallCount">Ball</param>
        /// <param name="frames">List of frame</param>
        /// <param name="currentFrame">Current Frame</param>
        /// <returns></returns>
        private int Calculate(int frameCount, int finalScore, int ballCount, List<Frame> frames, Frame frame)
        {
            try
            {
                switch (BallThrow)
                {
                    case BallThrow.NoScore:
                    case BallThrow.Spare:
                        Spare spare = BowlingFactoryService.GetSpare(BallScore, ballCount, frameCount, finalScore, frame);
                        if (spare != null)
                            finalScore = spare.SpareCalculation(frames);
                        break;
                    case BallThrow.Strike:
                        Strike strike = BowlingFactoryService.GetStrike(BallScore, ballCount, frameCount, finalScore, frame);
                        if (strike != null)
                            finalScore = strike.StrikeCalculation(frames);
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption Occurred {ex.Message}");
            }
            return finalScore;
        }

    }
}
