using System.Collections.Generic;

namespace BowlingBall.Module
{
    public class Spare
    {
        private int BallScore { get; set; }
        private int BallCount { get; set; }
        private int FrameCount { get; set; }
        private int FinalScore { get; set; }
        private Frame Frame { get; set; }

        public Spare(int ballScore, int ballCount, int frameCount, int finalScore, Frame frame)
        {
            BallScore = ballScore;
            BallCount = ballCount;
            FrameCount = frameCount;
            FinalScore = finalScore;
            Frame = frame;
        }

        public int SpareCalculation(List<Frame> frames)
        {
            FirstBallPreviousFrame(frames);
            FirstBallTwoPreviousStrike(frames);
            LastBallOnePreviousStrike(frames);
            LastBallCurrentFrame();
            return FinalScore;
        }
        private int FirstBallPreviousFrame(List<Frame> frames)
        {
            //previous frame contain spare then calculate previous + current ball & total score
            if (BallCount == 0 && FrameCount > 0 && frames[FrameCount - 1].Balls.Count > 1 && frames[FrameCount - 1].Balls[1].BallThrow == BallThrow.Spare)
            {
                frames[FrameCount - 1].FrameScore = FinalScore += 10 + BallScore;
            }
            return FinalScore;
        }

        private int LastBallCurrentFrame()
        {
            int currentScore = Frame.Balls.Count > 1 ? Frame.Balls[0].BallScore + Frame.Balls[1].BallScore : 0;
            //current frame contain lower score i.e. < 10 then calculate previous ball + current ball & total score
            if (BallCount == 1 && Frame.Balls.Count > 0 && currentScore < 10 && Frame.FrameScore == 0)
            {
                Frame.FrameScore = FinalScore += BallScore + Frame.Balls[0].BallScore;
            }
            return FinalScore;
        }

        private int LastBallOnePreviousStrike(List<Frame> frames)
        {
            //previous frame strike then calculate next i.e. current frame ball with total score
            if (BallCount == 1 && FrameCount > 0 && frames[FrameCount - 1].Balls.Count > 0 && frames[FrameCount - 1].Balls[0].BallThrow == BallThrow.Strike)
            {
                frames[FrameCount - 1].FrameScore = FinalScore += BallScore + 10 + Frame.Balls[0].BallScore;
            }
            return FinalScore;
        }

        private int FirstBallTwoPreviousStrike(List<Frame> frames)
        {
            //previous frame strike & previous of previous i.e. 1 frame before also strike then calculate current ball+ 2 frame scores
            if (BallCount == 0 && FrameCount > 1 && frames[FrameCount - 1].Balls.Count > 0 && frames[FrameCount - 1].Balls[0].BallThrow == BallThrow.Strike)
            {
                if (BallCount == 0 && FrameCount > 2 && frames[FrameCount - 2].Balls.Count > 0 && frames[FrameCount - 2].Balls[0].BallThrow == BallThrow.Strike)
                {
                    frames[FrameCount - 2].FrameScore = FinalScore += BallScore + 10 + 10;
                }
            }
            return FinalScore;
        }

    }
}
