using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class Sellitemset
    {
        // 상점 구매 구현
        public void Sellitem()
        {
            Player Seplayer = new Player();
            itemstatus SeItem = new itemstatus();
            GameLobbyset SeGameLobby = new GameLobbyset();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 구매\n" +
                         "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                         "[보유 골드]\n" +
                         $"{Seplayer.Gold} G\n\n" +
                         $"[아이템 목록]\n" +
                         $"- 1 수련자 갑옷    | 방어력 +{SeItem.TrainingDeffensivePower}  | 수련에 도움을 주는 갑옷입니다.             |  {(SeItem.TtrainingGlod == 0 ? "구매완료" : SeItem.TtrainingGlod + " G")}\n" +
                         $"- 2 무쇠 갑옷      | 방어력 +{SeItem.IronDeffensivePower}  | 무쇠로 만들어져 튼튼한 갑옷입니다.           | {(SeItem.IronGlod == 0 ? "구매완료" : SeItem.IronGlod + " G")} \n" +
                         $"- 3 스파르타의 갑옷 | 방어력 +{SeItem.SpartarDeffensivePower} | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  {(SeItem.SpartarGold == 0 ? "구매완료" : SeItem.SpartarGold + " G")}\n" +
                         $"- 4 알파메일의 갑옷 | 방어력 +{SeItem.AlphaMaleDeffensivePower} | 전설의 알파메일이 사용했다고 전해지는 갑옷입니다.|  {(SeItem.SpartarGold == 0 ? "구매완료" : SeItem.AlphaMaleGold + " G")}\n" +
                         $"- 5 낡은 검      | 공격력 +{SeItem.OldSwordOffensivePower}  | 쉽게 볼 수 있는 낡은 검 입니다.            |  {(SeItem.OldSwordGold == 0 ? "구매완료" : SeItem.OldSwordGold + " G")}\n" +
                         $"- 6 청동 도끼     | 공격력 +{SeItem.BronzeSwordOffensivePower}  |  어디선가 사용됐던거 같은 도끼입니다.        |  {(SeItem.BronzeSwordGold == 0 ? "구매완료" : SeItem.BronzeSwordGold + " G")}\n" +
                         $"- 7 스파르타의 창  | 공격력 +{SeItem.SpartarSpearOffensivePower}  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  {(SeItem.SpartarSpearGold == 0 ? "구매완료" : SeItem.SpartarSpearGold + " G")}\n" +
                         $"- 8 알파메일의 검  | 공격력 +{SeItem.AlphaMaleSwordOffensivePower}  |  전설의 알파메일이 사용했다고 전해지는 검입니다..|  {(SeItem.SpartarSpearGold == 0 ? "구매완료" : SeItem.AlphaMaleSwordGold + " G")}\n\n" +
                         $"0. 나가기\n\n" +
                         "원하시는 행동을 입력해주세요.\n>>");
                try
                {
                    int? input = int.Parse(Console.ReadLine());
                    if (input == 0)
                    {
                        Console.Clear();
                        SeGameLobby.GameLobby();
                    }
                    else if (input == 1)
                    {
                        if (SeItem.TtrainingGlod <= 0)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.\n");
                        }
                        else if (Seplayer.Gold < SeItem.TtrainingGlod)
                        {
                            Console.WriteLine("소지금이 부족합니다!\n");
                        }
                        else
                        {
                            Seplayer.Gold -= SeItem.TtrainingGlod;
                            SeItem.TtrainingGlod = 0;
                            Seplayer.InventoryItems.Add(new Inventory($"수련자 갑옷    |", "방어력", 0, SeItem.TrainingDeffensivePower));
                            Console.WriteLine("구매가 완료되었습니다.\n");
                        }
                        Thread.Sleep(3000);
                        Sellitem();
                    }
                    else if (input == 2)
                    {
                        if (SeItem.IronGlod <= 0)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.\n");
                        }
                        else if (Seplayer.Gold < SeItem.IronGlod)
                        {
                            Console.WriteLine("소지금이 부족합니다!\n");
                        }
                        else
                        {
                            Seplayer.Gold -= SeItem.IronGlod;
                            SeItem.IronGlod = 0;
                            Seplayer.InventoryItems.Add(new Inventory($"무쇠 갑옷    |", "방어력", 0, SeItem.IronDeffensivePower));
                            Console.WriteLine("구매가 완료되었습니다.\n");
                        }
                        Thread.Sleep(3000);
                        Sellitem();
                    }

                    else if (input == 3)
                    {
                        if (SeItem.SpartarGold <= 0)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.\n");
                        }
                        else if (Seplayer.Gold < SeItem.SpartarGold)
                        {
                            Console.WriteLine("소지금이 부족합니다!\n");
                        }
                        else
                        {
                            Seplayer.Gold -= SeItem.SpartarGold;
                            SeItem.SpartarGold = 0;
                            Seplayer.InventoryItems.Add(new Inventory($"스파르타의 갑옷 |", "방어력", 0, SeItem.SpartarDeffensivePower));
                            Console.WriteLine("구매가 완료되었습니다.\n");
                        }
                        Thread.Sleep(3000);
                        Sellitem();
                    }
                    else if (input == 4)
                    {
                        if (SeItem.AlphaMaleGold <= 0)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.\n");
                        }
                        else if (Seplayer.Gold < SeItem.AlphaMaleGold)
                        {
                            Console.WriteLine("소지금이 부족합니다!\n");
                        }
                        else
                        {
                            Seplayer.Gold -= SeItem.AlphaMaleGold;
                            SeItem.AlphaMaleGold = 0;
                            Seplayer.InventoryItems.Add(new Inventory($"스파르타의 갑옷 |", "방어력", 0, SeItem.AlphaMaleDeffensivePower));
                            Console.WriteLine("구매가 완료되었습니다.\n");
                        }
                        Thread.Sleep(3000);
                        Sellitem();
                    }

                    else if (input == 5)
                    {
                        if (SeItem.OldSwordGold <= 0)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.\n");
                        }
                        else if (Seplayer.Gold < SeItem.OldSwordGold)
                        {
                            Console.WriteLine("소지금이 부족합니다!\n");
                        }
                        else
                        {
                            Seplayer.Gold -= SeItem.OldSwordGold;
                            SeItem.OldSwordGold = 0;
                            Seplayer.InventoryItems.Add(new Inventory($"낡은 검 |", "공격력", SeItem.OldSwordOffensivePower, 0));
                            Console.WriteLine("구매가 완료되었습니다.\n");
                        }
                        Thread.Sleep(3000);
                        Sellitem();
                    }

                    else if (input == 6)
                    {
                        if (SeItem.BronzeSwordGold <= 0)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.\n");
                        }
                        else if (Seplayer.Gold < SeItem.BronzeSwordGold)
                        {
                            Console.WriteLine("소지금이 부족합니다!\n");
                        }
                        else
                        {
                            Seplayer.Gold -= SeItem.BronzeSwordGold;
                            SeItem.BronzeSwordGold = 0;
                            Seplayer.InventoryItems.Add(new Inventory($"청동 검 |", "공격력", SeItem.BronzeSwordOffensivePower, 0));
                            Console.WriteLine("구매가 완료되었습니다.\n");
                        }
                        Thread.Sleep(3000);
                        Sellitem();
                    }

                    else if (input == 7)
                    {
                        if (SeItem.SpartarSpearGold <= 0)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.\n");
                        }
                        else if (Seplayer.Gold < SeItem.SpartarSpearGold)
                        {
                            Console.WriteLine("소지금이 부족합니다!\n");
                        }
                        else
                        {
                            Seplayer.Gold -= SeItem.SpartarSpearGold;
                            SeItem.SpartarSpearGold = 0;
                            Seplayer.InventoryItems.Add(new Inventory($"스파르타의 창 |", "공격력", SeItem.SpartarSpearOffensivePower, 0));
                            Console.WriteLine("구매가 완료되었습니다.\n");
                        }
                        Thread.Sleep(3000);
                        Sellitem();
                    }
                    else if (input == 8)
                    {
                        if (SeItem.AlphaMaleSwordGold <= 0)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.\n");
                        }
                        else if (Seplayer.Gold < SeItem.AlphaMaleSwordGold)
                        {
                            Console.WriteLine("소지금이 부족합니다!\n");
                        }
                        else
                        {
                            Seplayer.Gold -= SeItem.AlphaMaleSwordGold;
                            SeItem.AlphaMaleGold = 0;
                            Seplayer.InventoryItems.Add(new Inventory($"알파메일의 검 |", "공격력", SeItem.SpartarSpearOffensivePower, 0));
                            Console.WriteLine("구매가 완료되었습니다.\n");
                        }
                        Thread.Sleep(3000);
                        Sellitem();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("숫자를 입력해주세요!");
                    Thread.Sleep(1000);
                    Sellitem();
                }
            }
        }
    }
}
