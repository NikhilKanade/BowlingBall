using System;
using System.Collections.Generic;

namespace BowlingBall.Module
{
    public class Ball
    {

        private int _ballScore;
        private BallThrow _ballThrow;

        public int ballScore { get => _ballScore; set => _ballScore = value; }
        public BallThrow ballThrow { get => _ballThrow; set => _ballThrow = value; }

        /// <summary>
        /// Throw ball for roll to get score & find throw result
        /// </summary>
        /// <param name="score"></param>
        /// <param name="balls"></param>
        /// <returns>true - if throw result strike
        /// false - if throw result either none or spare </returns>
        public bool Roll(int score, List<Ball> balls)
        {
            try
            {
                _ballScore = score;
                _ballThrow = BallThrow.NoScore;
                if (score < 10)
                {
                    if (balls.Count == 1 && balls[0].ballScore + _ballScore >= 10)
                    {
                        _ballThrow = BallThrow.Spare;
                    }
                }
                else if (score >= 10 && balls.Count == 1 && balls[0].ballScore + _ballScore >= 10)
                    _ballThrow = BallThrow.Spare;
                else
                {
                    _ballThrow = BallThrow.Strike;
                    balls.Add(this);
                    return true;
                }
                balls.Add(this);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption Occurred {ex.Message}");
            }
            return false;
        }

        /// <summary>
        /// Calculate Frame score with respect to each ball throw
        /// </summary>
        /// <param name="i">nth Frame</param>
        /// <param name="FinalScore"></param>
        /// <param name="j">Ball</param>
        /// <param name="frames">List of frame</param>
        /// <param name="currentFrame">Current Frame</param>
        /// <returns></returns>
        public int Calculate(int i, int FinalScore, int j, List<Frame> frames, Frame currentFrame)
        {
            try
            {
                int currentScore = currentFrame.balls.Count > 1 ? currentFrame.balls[0].ballScore + currentFrame.balls[1].ballScore : 0;
                switch (ballThrow)
                {
                    case BallThrow.NoScore:
                    case BallThrow.Spare:
                        //previous frame contain spare then calculate previous + current ball & total score
                        if (j == 0 && i > 0 && frames[i - 1].balls.Count > 1 && frames[i - 1].balls[1].ballThrow == BallThrow.Spare)
                        {
                            frames[i - 1].frameScore = FinalScore + 10 + ballScore;
                            FinalScore = frames[i - 1].frameScore;
                        }//current frame contain lower score i.e. < 10 then calculate previous ball + current ball & total score
                        if (j == 1 && currentFrame.balls.Count > 0 && currentScore < 10 && currentFrame.frameScore == 0)
                        {
                            currentFrame.frameScore = FinalScore + currentFrame.balls[0].ballScore + ballScore;
                            FinalScore = currentFrame.frameScore;
                        }//previous frame strike then calculate next i.e. current frame ball with total score
                        if (j == 1 && i > 0 && frames[i - 1].balls.Count > 0 && frames[i - 1].balls[0].ballThrow == BallThrow.Strike)
                        {
                            frames[i - 1].frameScore = FinalScore + 10 + currentFrame.balls[0].ballScore + ballScore;
                            FinalScore = frames[i - 1].frameScore;
                        }//previous frame strike & previous of previous i.e. 1 frame before also strike then calculate current ball+ 2 frame scores
                        if (j == 0 && i > 1 && frames[i - 1].balls.Count > 0 && frames[i - 1].balls[0].ballThrow == BallThrow.Strike)
                        {
                            if (j == 0 && i > 2 && frames[i - 2].balls.Count > 0 && frames[i - 2].balls[0].ballThrow == BallThrow.Strike)
                            {
                                frames[i - 2].frameScore = FinalScore + 10 + 10 + ballScore;
                                FinalScore = frames[i - 2].frameScore;
                            }
                        }
                        break;
                    case BallThrow.Strike:
                        //Current frame strike & previous frame spare then calculate current + previous frame score
                        if (j == 0 && i > 1 && frames[i - 1].balls.Count > 1 && frames[i - 1].balls[1].ballThrow == BallThrow.Spare)
                        {
                            frames[i - 1].frameScore = frames[i - 1].balls[0].ballScore + frames[i - 1].balls[1].ballScore + FinalScore + 10;
                            FinalScore = frames[i - 1].frameScore;
                        }//Current frame strike & previous frame strike 
                        if (j == 0 && i > 1 && frames[i - 1].balls.Count > 0 && frames[i - 1].balls[0].ballThrow == BallThrow.Strike)
                        {
                            //1 frame before previous frame spare then calculate both frame with finalscore
                            if (j == 0 && i > 2 && frames[i - 2].balls.Count > 1 && frames[i - 2].balls[1].ballThrow == BallThrow.Spare && frames[i - 2].frameScore == 0)
                            {
                                frames[i - 2].frameScore = FinalScore + 10 + 10;
                                FinalScore = frames[i - 2].frameScore;
                            }// 1 frame before previous frame strike then calculate both frame with current frame ball sore with finalscore
                            else if (j == 0 && i >= 2 && frames[i - 2].balls.Count > 0 && frames[i - 2].balls[0].ballThrow == BallThrow.Strike && frames[i - 2].frameScore == 0)
                            {
                                frames[i - 2].frameScore = FinalScore + 10 + 10 + ballScore;
                                FinalScore = frames[i - 2].frameScore;
                            }
                        }// 10th Frame strike, current ball strike then calculate current ballscore + previous frame score+ final score 
                        else if (i == 9 && frames[i - 1].balls.Count > 0 && frames[i - 1].balls[0].ballThrow == BallThrow.Strike && frames[i - 1].frameScore == 0)
                        {
                            frames[i - 1].frameScore = FinalScore + 10 + 10 + ballScore;
                            FinalScore = frames[i - 1].frameScore;
                        }//10th Frame calculation all three ball score with FinalScore
                        else if (i == 9 && currentFrame.balls.Count > 0 && currentFrame.frameScore == 0)
                        {
                            currentFrame.frameScore = FinalScore + currentFrame.balls[0].ballScore + currentFrame.balls[1].ballScore + ballScore;
                            FinalScore = currentFrame.frameScore;
                        }
                        break;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exeption Occurred {ex.Message}");
            }
            return FinalScore;
        }
    }
}
