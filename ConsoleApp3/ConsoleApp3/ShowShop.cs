using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class ShowShopset
    {
        // 상점 구현
        public void ShowShop()
        {
            Player Shplayer = new Player();
            itemstatus _item = new itemstatus();
            Sellitemset Sellitem = new Sellitemset();
            Saleitemset Saleitem = new Saleitemset(); 
            GameLobbyset GameLobby = new GameLobbyset();
            while (true)
            {


                Console.Clear();

                Console.WriteLine("상점\n" +
                                  "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                                  "[보유 골드]\n" +
                                  $"{Shplayer.Gold} G\n\n" +
                                  $"[아이템 목록]\n" +
                                  $"- 1 수련자 갑옷    | 방어력 +{_item.TrainingDeffensivePower}  | 수련에 도움을 주는 갑옷입니다.             |  {(_item.TtrainingGlod == 0 ? "구매완료" : _item.TtrainingGlod + " G")}\n" +
                                  $"- 2 무쇠갑옷      | 방어력 +{_item.IronDeffensivePower}  | 무쇠로 만들어져 튼튼한 갑옷입니다.           | {(_item.IronGlod == 0 ? "구매완료" : _item.IronGlod + " G")} \n" +
                                  $"- 3 스파르타의 갑옷 | 방어력 +{_item.SpartarDeffensivePower} | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  {(_item.SpartarGold == 0 ? "구매완료" : _item.SpartarGold + " G")}\n" +
                                  $"- 4 알파메일의 갑옷 | 방어력 +{_item.AlphaMaleDeffensivePower} | 전설의 알파메일이 사용했다고 전해지는 갑옷입니다.|  {(_item.SpartarGold == 0 ? "구매완료" : _item.AlphaMaleGold + " G")}\n" +
                                  $"- 5 낡은 검      | 공격력 +{_item.OldSwordOffensivePower}  | 쉽게 볼 수 있는 낡은 검 입니다.            |  {(_item.OldSwordGold == 0 ? "구매완료" : _item.OldSwordGold + " G")}\n" +
                                  $"- 6 청동 도끼     | 공격력 +{_item.BronzeSwordOffensivePower}  |  어디선가 사용됐던거 같은 도끼입니다.        |  {(_item.BronzeSwordGold == 0 ? "구매완료" : _item.BronzeSwordGold + " G")}\n" +
                                  $"- 7 스파르타의 창  | 공격력 +{_item.SpartarSpearOffensivePower}  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  {(_item.SpartarSpearGold == 0 ? "구매완료" : _item.SpartarSpearGold + " G")}\n" +
                                  $"- 8 알파메일의 검  | 공격력 +{_item.AlphaMaleSwordOffensivePower}  |  전설의 알파메일이 사용했다고 전해지는 검입니다..|  {(_item.SpartarSpearGold == 0 ? "구매완료" : _item.AlphaMaleSwordGold + " G")}\n\n" +
                                  $"1. 아이템 구매\n" +
                                  $"2. 아이템 판매\n" +
                                  $"0. 나가기\n\n" +
                                  "원하시는 행동을 입력해주세요.\n>>");
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                    {
                        Console.Clear();
                        GameLobby.GameLobby();
                    }
                    else if (input == 1)
                    {
                        Console.Clear();
                        Sellitem.Sellitem();
                    }
                    else if (input == 2)
                    {
                        Console.Clear();
                        Saleitem.Saleitem();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 시도해주세요.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("숫자를 입력해주세요!");
                    Thread.Sleep(1000);
                    ShowShop();
                }
            }
        }
    }
}
