using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class showinvenset
    {
        // 인벤토리 구현
        public void ShowInven()
        {
            Player _player = new Player();
            InsMentset InsMent = new InsMentset();
            GameLobbyset GameLobby = new GameLobbyset();
            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("인벤토리\n" +
                              "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
                              $"[아이템 목록]\n");
                    if (_player.InventoryItems.Count == 0)
                    {
                        Console.WriteLine("보유 중인 아이템이 없습니다.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        GameLobby.GameLobby();
                    }
                    else
                    {
                        for (int i = 0; i < _player.InventoryItems.Count; i++)
                        {
                            Console.WriteLine($" {i + 1}. {_player.InventoryItems[i]}");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"1. 장착 관리\n" +
                              $"2. 나가기\n\n" +
                              $"원하시는 행동을 입력해주세요.\n" +
                              $">>");

                    int? input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        InsMent.InsMent();
                    }
                    else if (input == 2)
                    {
                        GameLobby.GameLobby();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                    Thread.Sleep(1000);
                    ShowInven();
                }
            }
        }
    }
}
