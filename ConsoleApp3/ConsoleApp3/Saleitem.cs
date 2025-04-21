using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ConsoleApp3
{
    public class Saleitemset
    {
        Player Sale = new Player();
        GameLobbyset SaGameLobby = new GameLobbyset();
        
        // 상점 판매 구현
        public void Saleitem()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 판매\n" +
                                   "원하는 아이템을 판매 할 수 있습니다.\n\n" +
                                   "[보유 골드]\n" +
                                   $"{Sale.Gold}\n\n" +
                                   $"[아이템 목록]\n");
                if (Sale.InventoryItems.Count == 0)
                {
                    Console.WriteLine("보유 중인 아이템이 없습니다.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    SaGameLobby.GameLobby();
                }
                else
                {
                    for (int i = 0; i < Sale.InventoryItems.Count; i++)
                    {
                        Console.WriteLine($" {i + 1}. {Sale.InventoryItems[i]}");
                    }
                    Console.WriteLine();
                }
                try
                {
                    int input = int.Parse(Console.ReadLine());

                    if (input == 0)
                    {
                        Console.Clear();
                        SaGameLobby.GameLobby();
                    }


                    if (input < 1 || input > Sale.InventoryItems.Count)
                    {
                        Console.WriteLine("잘못된 번호입니다.");
                        Thread.Sleep(1000);
                        continue;
                    }

                    Inventory select = Sale.InventoryItems[input - 1];

                    Sale.OffensivePower -= select.OffensivePower;
                    Sale.DeffensivePower -= select.DefensivePower;
                    select.IsEquipped = true;
                    Console.WriteLine($"판매 완료!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Saleitem();
                }
                catch (Exception e)
                {
                    Console.WriteLine("숫자를 입력해주세요!");
                    Thread.Sleep(1000);
                    Console.Clear();
                    Saleitem();
                }
            }
        }
    }
}
