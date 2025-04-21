using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class ShowStatusset
    {
        //상태 정보 창 구현
        public void ShowStatus()
        {
            Player Splayer = new Player();
            GameLobbyset GameLobby = new GameLobbyset();

            Console.Clear();
            int bonusOff = Splayer.InventoryItems.Where(i => i.IsEquipped).Sum(i => i.OffensivePower);
            int bonusDff = Splayer.InventoryItems
                .Where(i => i.IsEquipped)
                .Sum(i => i.DefensivePower);



            Console.WriteLine("상태 보기\n" +
                              "캐릭터의 정보가 표시됩니다.\n\n" +
                              $"이름: {Splayer.name}\n" +
                              $"직업: {Splayer.job}\n" +
                              $"레벨: {Splayer.level}\n" +
                              $"공격력: {Splayer.OffensivePower} (+{bonusOff})\n" +
                              $"방어력: {Splayer.DeffensivePower} (+{bonusDff})\n" +
                              $"체력: {Splayer.HP}\n" +
                              $"Gold: {Splayer.Gold}\n");

            Console.WriteLine("0. 로비로 가기");


            bool input = int.TryParse(Console.ReadLine(), out int inp);
            if (input)
            {
                if (inp == 0)
                {
                    Console.Clear();
                    GameLobby.GameLobby();  // 로비로 돌아가게 처리
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    Thread.Sleep(1000); // 1초 후, 다시 상태를 출력할 수 있도록 해야 함
                    ShowStatus();  // 잘못된 입력 후 다시 상태를 출력
                }
            }
            else
            {
                Console.WriteLine("숫자를 입력해주세요.");
                Thread.Sleep(1000);
                ShowStatus();  // 잘못된 입력 후 다시 상태를 출력
            }
        }
    }
}
