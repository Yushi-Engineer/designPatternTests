using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DesignPatternTest
{
    [TestClass]
    public class TemplateMethodTest
    {
        [TestMethod]
        public void TemplateMethodTest1()
        {
            BattleCommands ryuCommand = new MyOwnBattleCommands("リュウ");
            string[] ryuCommandLogs = ryuCommand.Battle();
            foreach (var log in ryuCommandLogs)
            {
                Debug.WriteLine(log);
            }

            Debug.WriteLine("\r\n-----Character Changed-----\r\n");

            BattleCommands gokuCommand = new MyOwnBattleCommands("悟空");
            string[] gokuCommandLogs = gokuCommand.Battle();
            foreach (var log in gokuCommandLogs)
            {
                Debug.WriteLine(log);
            }
        }

        public abstract class BattleCommands
        {
            public abstract void Start();

            public abstract void AttackCommandA();

            public abstract void AttackCommandB();

            public abstract void SuperAttackCommand();

            public abstract void FinalAttackCommand();

            public abstract void Finish();

            public abstract string[] DiaplayCommandLogs();

            public string[] Battle()
            {
                this.Start();

                this.AttackCommandA();
                this.AttackCommandB();
                for (int i = 0; i < 2; i++)
                {
                    this.AttackCommandA();
                }
                this.SuperAttackCommand();
                for (int i = 0; i < 4; i++)
                {
                    this.AttackCommandA();
                    this.AttackCommandB();
                }
                this.SuperAttackCommand();
                this.FinalAttackCommand();

                this.Finish();

                return this.DiaplayCommandLogs();
            }
        }

        public class MyOwnBattleCommands : BattleCommands
        {
            private string PlayerName { get; set; }

            private int Width { get; set; }

            private List<string> BattleCommandLogs { get; set; }

            public MyOwnBattleCommands(string playerName)
            {
                this.PlayerName = playerName;
                Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
                this.Width = sjisEnc.GetByteCount(playerName);
            }

            public override void Start()
            {
                BattleCommandLogs = new List<string>();
                if (PlayerName == "リュウ")
                {
                    BattleCommandLogs.Add($"俺は{PlayerName}だ！俺と勝負しろ！");
                }
                else if(PlayerName == "悟空")
                {
                    BattleCommandLogs.Add($"オッス！おら{PlayerName}！おらワクワクすっぞ！");
                }
                else
                {
                    BattleCommandLogs.Add("試合開始！");
                }
            }

            public override void Finish()
            {
                if (PlayerName == "リュウ")
                {
                    BattleCommandLogs.Add("試合終了！俺の勝ちだ！");
                }
                else if (PlayerName == "悟空")
                {
                    BattleCommandLogs.Add("試合終了！おらが勝ったみてえだな！");
                }
                else
                {
                    BattleCommandLogs.Add("試合終了！");
                }
            }

            public override void AttackCommandA()
            {
                BattleCommandLogs.Add("パンチ！");
            }

            public override void AttackCommandB()
            {
                BattleCommandLogs.Add("キック！");
            }

            public override void SuperAttackCommand()
            {
                if (PlayerName == "リュウ")
                {
                    BattleCommandLogs.Add("波動拳！！");
                }
                else if (PlayerName == "悟空")
                {
                    BattleCommandLogs.Add("かーめーはーめー波ーーー！！");
                }
                else
                {
                    BattleCommandLogs.Add("必殺技をくらえ！！");
                }
            }

            public override void FinalAttackCommand()
            {
                if (PlayerName == "リュウ")
                {
                    BattleCommandLogs.Add("昇竜拳！！！");
                }
                else if (PlayerName == "悟空")
                {
                    BattleCommandLogs.Add("みんな！おらに元気を分けてくれ！元気玉！！！");
                }
                else
                {
                    BattleCommandLogs.Add("これが最終奥義だ！！！");
                }
            }

            public override string[] DiaplayCommandLogs()
            {
                return BattleCommandLogs.ToArray();
            }
        }
    }
}
