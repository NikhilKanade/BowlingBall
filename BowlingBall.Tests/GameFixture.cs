using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingBall.Tests
{
    [TestClass]
    public class GameFixture
    {
        [TestMethod]
        public void Gutter_game_score_should_be_zero_test()
        {
            var game = new Game();
            Roll(game, 0, 20);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_300_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            Roll(game, list);
            Assert.AreEqual(300, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_295_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 5 };
            Roll(game, list);
            Assert.AreEqual(295, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_275_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 0, 5, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            Roll(game, list);
            Assert.AreEqual(275, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_285_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 0, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 5 };
            Roll(game, list);
            Assert.AreEqual(285, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_240_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 0, 10, 10, 10, 10, 10, 5, 5, 10, 10, 10, 5, 10, 5 };
            Roll(game, list);
            Assert.AreEqual(240, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_290_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 0 };
            Roll(game, list);
            Assert.AreEqual(290, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_260_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 10, 10, 10, 0, 10, 10, 10, 10, 10, 10, 10, 10, 0 };
            Roll(game, list);
            Assert.AreEqual(260, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_122_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 8, 1, 0, 9, 2, 8, 10, 6, 3, 7, 0, 5, 2, 10, 0, 6, 2, 8, 10 };
            Roll(game, list);
            Assert.AreEqual(122, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_150_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            Roll(game, list);
            Assert.AreEqual(150, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_68_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1, 2, 3, 4, 5, 5, 4, 3, 2, 1, 1 };
            Roll(game, list);
            Assert.AreEqual(68, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_100_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0, 10, 0 };
            Roll(game, list);
            Assert.AreEqual(100, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_157_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 4, 6, 5, 5, 7, 3, 8, 2, 9, 1, 2, 8, 3, 7, 4, 6, 5, 5, 4, 6, 10 };
            Roll(game, list);
            Assert.AreEqual(157, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_166_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 10, 5, 5, 7, 3, 8, 2, 9, 1, 2, 8, 3, 7, 4, 6, 5, 5, 4, 10, 10 };
            Roll(game, list);
            Assert.AreEqual(166, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_81_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 4, 4, 5, 5, 3, 3, 2, 2, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 10, 10, 10 };
            Roll(game, list);
            Assert.AreEqual(81, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_20_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            Roll(game, list);
            Assert.AreEqual(20, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_40_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 };
            Roll(game, list);
            Assert.AreEqual(40, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_60_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 };
            Roll(game, list);
            Assert.AreEqual(60, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_80_1_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 };
            Roll(game, list);
            Assert.AreEqual(80, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_165_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 10 };
            Roll(game, list);
            Assert.AreEqual(150, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_80_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 8, 1, 0, 9, 2, 8, 10, 6, 3, 7, 0, 5, 2 };
            Roll(game, list);
            Assert.AreEqual(80, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_10_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 7, 2, 8, 2, 3, 5, 0, 7, 10, 2, 3, 5, 5, 9, 1, 9, 1, 4, 5, 0 };
            Roll(game, list);
            Assert.AreEqual(118, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_0_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            Roll(game, list);
            Assert.AreEqual(0, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_187_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 10, 9, 1, 5, 5, 7, 2, 10, 10, 10, 9, 0, 8, 2, 9, 1, 10 };
            Roll(game, list);
            Assert.AreEqual(187, game.GetScore());
        }

        [TestMethod]
        public void Gutter_game_score_should_be_168_test()
        {
            var game = new Game();
            //10th frame contain 3 balls
            List<int> list = new List<int>() { 8, 2, 7, 3, 3, 4, 10, 2, 8, 10, 10, 8, 0, 5, 5, 7, 3, 10 };
            Roll(game, list);
            Assert.AreEqual(168, game.GetScore());
        }

        private void Roll(Game game, List<int> list)
        {
            foreach (int i in list)
            {
                game.Roll(i);
            }
        }
        private void Roll(Game game, int pins, int times)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }
    }
}
