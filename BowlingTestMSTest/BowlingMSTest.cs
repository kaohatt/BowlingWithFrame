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
        //1��ڃX�y�A�i�S�{�U�j�{2��ځi�R�{�Q�j�{�c���8��͂O�_�i�{�[�i�X�Ȃ��j
        //���Ғl�F21�_
        [TestMethod]
        public void Spare()
        {
            game.Spare(4, 6);
            game.OpenFrame(3, 5);
            ManyOpenFrames(8, 0, 0);

            Assert.AreEqual(21, game.Score());
        }

        //test5
        //1��ڃX�y�A�i6�{4�j�{2��ځi5�{3�j�{�c���8��͂O�_�i�{�[�i�X�Ȃ��j
        //���Ғl�F23�_
        [TestMethod]
        public void Spare2()
        {
            game.Spare(4, 6);
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);

            Assert.AreEqual(23, game.Score());
        }

        //test6
        //1��ڃX�g���C�N�i10�j�{2��ځi5�{3�j�{�c���8��͂O�_�i�{�[�i�X�Ȃ��j
        //���Ғl�F26�_
        [TestMethod]
        public void Strike()
        {
            game.Strike();
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);

            Assert.AreEqual(26, game.Score());
        }
        //test7
        //�ŏ���9���0�_�{�P�O��ڂ̓X�g���C�N�{�{�[�i�X1���5�_�{�{�[�i�X2���3�_
        //���Ғl�F18�_
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
        //�ŏ���9��ڂ�0�_�{10��ڃX�y�A�i4�{6�j�{�{�[�i�X5�_
        //���Ғl�F15�_
        [TestMethod]
        public void SpareFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Spare(4, 6);
            game.BonusRoll(5);

            Assert.AreEqual(15, game.Score());
        }

        //test9
        //�p�[�t�F�N�g(10��X�g���C�N�{�{�[�i�X2��@10�_����
        //���Ғl�F300�_
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
        //�ŏ���10��̓X�g���C�N�ƃX�y�A�����{�{�[�i�X1��@10�_
        //���Ғl�F200�_
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
        //�ŏ���10��̓X�y�A�ƃX�g���C�N�����{�{�[�i�X2��@�X�y�A
        //���Ғl�F200�_
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