using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class InsMentset
    {
        // 장착 관리 구현
        public void InsMent()
        {
            Player Ins = new Player();
            GameLobbyset insGameLobby = new GameLobbyset();
            while (true)
            {
                Console.WriteLine("인벤토리 - 장착 관리\n");
                Console.WriteLine("[장착 가능한 아이템]");
                for (int i = 0; i < Ins.InventoryItems.Count; i++)
                {
                    Console.WriteLine($"- {i + 1}. {Ins.InventoryItems[i]}\n");
                }
                Console.WriteLine("0. 나가기\n");
                Console.Write("원하시는 행동을 입력해주세요.\n>> ");

                try
                {
                    int input = int.Parse(Console.ReadLine());

                    if (input == 0)
                    {
                        Console.Clear();
                        insGameLobby.GameLobby();
                    }


                    if (input < 1 || input > Ins.InventoryItems.Count)
                    {
                        Console.WriteLine("잘못된 번호입니다.");
                        Thread.Sleep(1000);
                        continue;
                    }

                    Inventory select = Ins.InventoryItems[input - 1];

                    Ins.OffensivePower += select.OffensivePower;
                    Ins.DeffensivePower += select.DefensivePower;
                    select.IsEquipped = true;
                    Console.WriteLine($"장착 완료!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    InsMent();
                }
                catch (Exception e)
                {
                    Console.WriteLine("숫자를 입력해주세요!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    InsMent();
                }
            }
        }
    }
}

