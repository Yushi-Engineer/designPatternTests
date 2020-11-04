using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DesignPatternTest
{
    [TestClass]
    public class AdapterTest_AdditionalVersion
    {
        [TestMethod]
        public void AdapterTestIn2010()
        {
            Gratitude gratitude = new Gratitude("お父さん、お母さん");
            string message = gratitude.ExpressMyFeeling();
        }

        [TestMethod]
        public void AdapterTestIn2020()
        {
            Express<string> express = new AdaptExpressToGratitude("お父さん、お母さん、2020年も");
            string newMessageIn2020 = express.ExpressMyGratitudeTo();
            // 下記の要望通り、新メソッド名の"ExpressMyGratitudeTo"で処理が呼べるようになった！▼
        }

        #region 2010年の出来事
        /// <summary>
        /// 引数で感謝したい人の氏名を入力し、その人に感謝気持ちを伝えるアプリが開発された▼
        /// </summary>

        public class Gratitude
        {
            private string Someone;

            public Gratitude(string someone)
            {
                this.Someone = someone;
            }

            public string ExpressMyFeeling()
            {
                return $"{Someone}、ありがとう！";
            }
        }
        #endregion 2010年の出来事

        // ----- 時は流れ10年後 -----

        #region 2020年の出来事
        /// <summary>
        /// 「誰かに感謝を伝えるアプリだから"ExpressMyFeeling"ではなく"ExpressMyGratitudeTo"というメソッド名に変更してほしい」との要望があった▼
        /// しかし、10年前のソースコードは残っておらず、Gratitudeクラスに修正を加えるのは不可能だ...▼
        /// よし、新しくインターフェースを作り、そのメソッド名を"ExpressMyGratitudeTo"としよう▼
        /// そして旧メソッドの"ExpressMyFeeling"と新メソッドの"ExpressMyGratitudeTo"を適合させるアダプタークラスを作ろう！▼
        /// </summary>

        /// <summary>
        /// インターフェース
        /// </summary>
        public interface Express<T>
        {
            T ExpressMyGratitudeTo();
        }

        /// <summary>
        /// アダプタークラス
        /// </summary>
        public class AdaptExpressToGratitude : Express<string>
        {
            public Gratitude Gratitude;

            public AdaptExpressToGratitude(string someone)
            {
                this.Gratitude = new Gratitude(someone);
            }

            public string ExpressMyGratitudeTo()
            {
                return this.Gratitude.ExpressMyFeeling();
            }
        }
        #endregion 2020年の出来事
    }
}
