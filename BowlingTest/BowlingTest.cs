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
        //テスト毎にボーリングのインスタンスを生成する
        [SetUp]
        public void SetUp()
        {
            game = new BowlingGame();
        }
        
        //test1
        //NUnitのライブラリを使っているかのチェック
        [Test]
        public void Hookup()
        {
            Assert.True(true);
        }

        //test2
        //ガタ―：ピンを外しているとき、０点
        //期待値：0点
        [Test]
        public void GutterBalls()
        {
            ManyOpenFrames(10,0,0);

            Assert.That(game.Score(), Is.EqualTo(0));
        }

        //test3
        //10フレームｘ（3＋3）（ボーナスなし）
        //期待値：60点
        [Test]public void Threes()
        {
            ManyOpenFrames(10, 3, 3);

            Assert.That(game.Score(), Is.EqualTo(60));
        }

        //test4
        //1回目スペア（４＋６）＋2回目（３＋２）＋残りの8回は０点（ボーナスなし）
        //期待値：21点
        [Test]
        public void Spare()
        {
            game.Spare(4, 6);
            game.OpenFrame(3, 5);
            ManyOpenFrames(8, 0, 0);

            Assert.That(game.Score(), Is.EqualTo(21));
        }

        //test5
        //1回目スペア（6＋4）＋2回目（5＋3）＋残りの8回は０点（ボーナスなし）
        //期待値：23点
        [Test]
        public void Spare2()
        {
            game.Spare(4, 6);
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);

            Assert.That(game.Score(), Is.EqualTo(23));
        }

        //test6
        //1回目ストライク（10）＋2回目（5＋3）＋残りの8回は０点（ボーナスなし）
        //期待値：26点
        [Test]
        public void Strike() {
            game.Strike();
            game.OpenFrame(5, 3);
            ManyOpenFrames(8, 0, 0);

            Assert.That(game.Score(), Is.EqualTo(26));
        }
        //test7
        //最初の9回は0点＋１０回目はストライク＋ボーナス1回目5点＋ボーナス2回目3点
        //期待値：18点
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
        //最初の9回目は0点＋10回目スペア（4＋6）＋ボーナス5点
        //期待値：15点
        [Test]
        public void SpareFinalFrame()
        {
            ManyOpenFrames(9, 0, 0);
            game.Spare(4, 6);
            game.BonusRoll(5);

            Assert.That(game.Score(), Is.EqualTo(15));
        }

        //test9
        //パーフェクト(10回ストライク＋ボーナス2回　10点ずつ
        //期待値：300点
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
        //最初の10回はストライクとスペアずつ交代＋ボーナス1回　10点
        //期待値：200点
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
        //最初の10回はスペアとストライクずつ交代＋ボーナス2回　スペア
        //期待値：200点
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