using BowlingWithFrame;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace BowlingTestMSTest
{
    [TestClass]
    public class BowlingMSTest
    {
        BowlingGame game;

        //constructor
        public BowlingMSTest()
        {

        }

        [TestInitialize]
        public void Setup()
        {
            WriteSeparatorLine();
            game = new BowlingGame();
            Debug.WriteLine("TestInitialize Setup: done");
        }
        [TestMethod]
        public void HookTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void AllGutter()
        {
            ManyOpenFrames(10, 0, 0);

            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void Threes()
        {
            ManyOpenFrames(10, 3, 3);

            Assert.AreEqual(60, game.Score());
        }

        //test4
        //1回目スペア（４＋６）＋2回目（３＋２）＋残りの8回は０点（ボーナスなし）
        //期待値：21点
        [TestMethod]
        public void Spare()
        {
            game.Spare(4, 6);
            game.OpenFrame(3, 5);
            ManyOpenFrames(8, 0, 0);

            Assert.AreEqual(21, game.Score());
        }

        //test5
        //1回目スペア（6＋4）＋2回目（5＋3）＋残りの8回は０点（ボーナスなし）
        //期待値：23点
        [TestMethod]
        public void Spare2()
        {
            game.Spare(4, 6);
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);

            Assert.AreEqual(23, game.Score());
        }

        //test6
        //1回目ストライク（10）＋2回目（5＋3）＋残りの8回は０点（ボーナスなし）
        //期待値：26点
        [TestMethod]
        public void Strike()
        {
            game.Strike();
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);

            Assert.AreEqual(26, game.Score());
        }
        //test7
        //最初の9回は0点＋１０回目はストライク＋ボーナス1回目5点＋ボーナス2回目3点
        //期待値：18点
        [TestMethod]
        public void StrikeFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Strike();
            game.BonusRoll(5);
            game.BonusRoll(3);

            Assert.AreEqual(18, game.Score());
        }

        //test8
        //最初の9回目は0点＋10回目スペア（4＋6）＋ボーナス5点
        //期待値：15点
        [TestMethod]
        public void SpareFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Spare(4, 6);
            game.BonusRoll(5);

            Assert.AreEqual(15, game.Score());
        }

        //test9
        //パーフェクト(10回ストライク＋ボーナス2回　10点ずつ
        //期待値：300点
        [TestMethod]
        public void Perfect()
        {
            for (int i = 0; i < 10; i++)
            {
                game.Strike();
                game.BonusRoll(10);
                game.BonusRoll(10);
            }

            Assert.AreEqual(300, game.Score());
        }

        //test10
        //最初の10回はストライクとスペアずつ交代＋ボーナス1回　10点
        //期待値：200点
        [TestMethod]
        public void Alternating()
        {
            for (int i = 0; i < 5; i++)
            {
                game.Strike();
                game.Spare(4, 6);
            }
            game.BonusRoll(10);

            Assert.AreEqual(200, game.Score());
        }

        //test11
        //最初の10回はスペアとストライクずつ交代＋ボーナス2回　スペア
        //期待値：200点
        [TestMethod]
        public void Alternating2()
        {
            for (int i = 0; i < 5; i++)
            {
                game.Spare(4, 6);
                game.Strike();
            }
            game.BonusRoll(4);
            game.BonusRoll(6);

            Assert.AreEqual(200, game.Score());
        }


        private static void WriteSeparatorLine()
        {
            Debug.WriteLine("---------------------------");
        }

        private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < 10; frameNumber++)
            {
                game.OpenFrame(firstThrow, secondThrow);
            }
        }
    }
}