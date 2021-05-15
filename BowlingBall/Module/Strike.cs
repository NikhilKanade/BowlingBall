using BowlingBall.Common;
using System.Collections.Generic;

namespace BowlingBall.Module
{
    public class Strike
    {
        private int BallScore { get; set; }
        private int BallCount { get; set; }
        private int FrameCount { get; set; }
        private int FinalScore { get; set; }
        private Frame Frame { get; set; }

        public Strike(int ballScore, int ballCount, int frameCount, int finalScore, Frame frame)
        {
            BallScore = ballScore;
            BallCount = ballCount;
            FrameCount = frameCount;
            FinalScore = finalScore;
            Frame = frame;
        }

        public int StrikeCalculation(List<Frame> frames)
        {
            FirstBallPreviousFrame(frames);
            FirstBallCurrentPreviousFrame(frames);
            LastFrame(frames);
            return FinalScore;
        }
        private int FirstBallPreviousFrame(List<Frame> frames)
        {
            //Current frame strike & previous frame spare then calculate current + previous frame score
            if (BallCount == 0 && FrameCount > 1 && frames[FrameCount - 1].Balls.Count > 1 && frames[FrameCount - 1].Balls[1].BallThrow == BallThrow.Spare)
            {
                frames[FrameCount - 1].FrameScore = FinalScore += frames[FrameCount - 1].Balls[0].BallScore + frames[FrameCount - 1].Balls[1].BallScore + 10;
            }
            return FinalScore;
        }

        private int FirstBallCurrentPreviousFrame(List<Frame> frames)
        {
            Frame previous = FrameCount > Constants.One ? frames[FrameCount - Constants.One] : null;
            bool previousBalls = previous != null ? previous.Balls.Count > Constants.Zero : false;

            Frame twoPrevious = FrameCount >= Constants.Two ? frames[FrameCount - Constants.Two] : null;
            bool twoPreviousBalls = twoPrevious != null ? twoPrevious.Balls.Count > Constants.One : false;
            bool twoPreviousFrameBalls = twoPrevious != null ? twoPrevious.Balls.Count > Constants.Zero: false;

            //Current frame strike & previous frame strike 
            if (BallCount == 0 && previousBalls && previous.Balls[Constants.Zero].BallThrow == BallThrow.Strike)
            {
                if (twoPreviousBalls && twoPrevious.Balls[Constants.One].BallThrow == BallThrow.Spare && twoPrevious.FrameScore == 0)
                {//Spare
                    twoPrevious.FrameScore = FinalScore += Constants.Score20;
                }
                else if (twoPreviousFrameBalls && twoPrevious.Balls[Constants.Zero].BallThrow == BallThrow.Strike && twoPrevious.FrameScore == 0)
                {//Strike
                    twoPrevious.FrameScore = FinalScore += Constants.Score20 + BallScore;
                }
            }
            return FinalScore;
        }

        private int LastFrame(List<Frame> frames)
        {
            Frame previous = FrameCount == 9 ? frames[FrameCount - Constants.One] : null;
            bool previousBalls = previous != null ? previous.Balls.Count > Constants.Zero : false;

            // 10th Frame strike, current ball strike then calculate current ballscore + previous frame score+ final score 
            if (previousBalls && previous.Balls[Constants.Zero].BallThrow == BallThrow.Strike && previous.FrameScore == Constants.Zero)
            {
                previous.FrameScore = FinalScore += Constants.Score20 + BallScore;
            }//10th Frame calculation all three ball score with FinalScore
            else if (FrameCount == 9 && Frame.Balls.Count > Constants.Zero && Frame.FrameScore == Constants.Zero)
            {
                Frame.FrameScore = FinalScore += Frame.Balls[0].BallScore + Frame.Balls[1].BallScore + BallScore;
            }
            return FinalScore;
        }

    }
}
