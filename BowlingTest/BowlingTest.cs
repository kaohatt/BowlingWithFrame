using BowlingWithFrame;

namespace BowlingTest
{
    [TestFixture]
    
    public class BowlingTest : Assert
    {
        BowlingGame game;

        //constructor
        public BowlingTest() 
        {

        }
        //setup
        //�e�X�g���Ƀ{�[�����O�̃C���X�^���X�𐶐�����
        [SetUp]
        public void SetUp()
        {
            game = new BowlingGame();
        }
        
        //test1
        //NUnit�̃��C�u�������g���Ă��邩�̃`�F�b�N
        [Test]
        public void Hookup()
        {
            Assert.True(true);
        }

        //test2
        //�K�^�\�F�s�����O���Ă���Ƃ��A�O�_
        //���Ғl�F0�_
        [Test]
        public void GutterBalls()
        {
            ManyOpenFrames(10,0,0);

            Assert.That(game.Score(), Is.EqualTo(0));
        }

        //test3
        //10�t���[�����i3�{3�j�i�{�[�i�X�Ȃ��j
        //���Ғl�F60�_
        [Test]public void Threes()
        {
            ManyOpenFrames(10, 3, 3);

            Assert.That(game.Score(), Is.EqualTo(60));
        }

        //test4
        //1��ڃX�y�A�i�S�{�U�j�{2��ځi�R�{�Q�j�{�c���8��͂O�_�i�{�[�i�X�Ȃ��j
        //���Ғl�F21�_
        [Test]
        public void Spare()
        {
            game.Spare(4, 6);
            game.OpenFrame(3, 5);
            ManyOpenFrames(8, 0, 0);

            Assert.That(game.Score(), Is.EqualTo(21));
        }

        //test5
        //1��ڃX�y�A�i6�{4�j�{2��ځi5�{3�j�{�c���8��͂O�_�i�{�[�i�X�Ȃ��j
        //���Ғl�F23�_
        [Test]
        public void Spare2()
        {
            game.Spare(4, 6);
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);

            Assert.That(game.Score(), Is.EqualTo(23));
        }

        //test6
        //1��ڃX�g���C�N�i10�j�{2��ځi5�{3�j�{�c���8��͂O�_�i�{�[�i�X�Ȃ��j
        //���Ғl�F26�_
        [Test]
        public void Strike() {
            game.Strike();
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);

            Assert.That(game.Score(), Is.EqualTo(26));
        }
        //test7
        //�ŏ���9���0�_�{�P�O��ڂ̓X�g���C�N�{�{�[�i�X1���5�_�{�{�[�i�X2���3�_
        //���Ғl�F18�_
        [Test]
        public void StrikeFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Strike();
            game.BonusRoll(5);
            game.BonusRoll(3);

            Assert.That(game.Score(), Is.EqualTo(18));
        }

        //test8
        //�ŏ���9��ڂ�0�_�{10��ڃX�y�A�i4�{6�j�{�{�[�i�X5�_
        //���Ғl�F15�_
        [Test]
        public void SpareFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Spare(4, 6);
            game.BonusRoll(5);

            Assert.That(game.Score(), Is.EqualTo(15));
        }

        //test9
        //�p�[�t�F�N�g(10��X�g���C�N�{�{�[�i�X2��@10�_����
        //���Ғl�F300�_
        [Test]
        public void Perfect()
        {
            for(int i=0; i<10; i++)
            {
                game.Strike();
                game.BonusRoll(10);
                game.BonusRoll(10);
            }

            Assert.That(game.Score(), Is.EqualTo(300));
        }

        //test10
        //�ŏ���10��̓X�g���C�N�ƃX�y�A�����{�{�[�i�X1��@10�_
        //���Ғl�F200�_
        [Test]
        public void Alternating()
        {
            for (int i = 0; i < 5; i++)
            {
                game.Strike();
                game.Spare(4, 6);
            }
            game.BonusRoll(10);

            Assert.That(game.Score(), Is.EqualTo(200));
        }

        //test11
        //�ŏ���10��̓X�y�A�ƃX�g���C�N�����{�{�[�i�X2��@�X�y�A
        //���Ғl�F200�_
        [Test]
        public void Alternating2()
        {
            for (int i = 0; i < 5; i++)
            {
                game.Spare(4, 6);
                game.Strike();
            }
            game.BonusRoll(4);
            game.BonusRoll(6);

            Assert.That(game.Score(), Is.EqualTo(200));
        }

        //method
        private void ManyOpenFrames(int count, int firstThrow, int secondThrow)
        {
            for (int frameNumber = 0; frameNumber < 10; frameNumber++)
            {
                game.OpenFrame(firstThrow, secondThrow);
            }
        }
    }
}