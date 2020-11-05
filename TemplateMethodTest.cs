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
            BattleCommands command1 = new MyOwnBattleCommands("リュウ");
            string[] battleCommandLogs = command1.Battle();
            foreach (var log in battleCommandLogs)
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
                BattleCommandLogs.Add($"俺は{PlayerName}だ！俺と勝負しろ！");
            }

            public override void Finish()
            {
                BattleCommandLogs.Add("試合終了！俺の勝ちだ！");
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
                BattleCommandLogs.Add("波動拳！！");
            }

            public override void FinalAttackCommand()
            {
                BattleCommandLogs.Add("昇竜拳！！！");
            }

            public override string[] DiaplayCommandLogs()
            {
                return BattleCommandLogs.ToArray();
            }
        }
    }
}
