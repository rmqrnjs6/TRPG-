using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    public class ShowRestset
    {
        // 휴식 기능 구현
        public void ShowRest()
        {
            Player Rest = new Player();
            GameLobbyset GameLobby = new GameLobbyset();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("휴식하기\n" +
                                  $"500 G 를 내면 체력을 회복할 수 있습니다.\n" +
                                  $"현재 체력{Rest.HP}\n" +
                                  $" (보유 골드 : {Rest.Gold})\n\n" +
                                  $"1. 휴식하기\n" +
                                  $"0. 나가기\n\n" +
                                  $"원하시는 행동을 입력해주세요.\n" +
                                  $">>");
                try
                {
                    int inp = int.Parse(Console.ReadLine());
                    int maxHP = 100;
                    if (inp == 0)
                    {
                        Console.Clear();
                        GameLobby.GameLobby();
                    }
                    else if (inp == 1)
                    {

                        if (Rest.Gold >= 500)
                        {
                            Rest.HP += (int)(Rest.HP * 0.3);
                            if (Rest.HP >= maxHP)
                            {
                                Rest.HP = maxHP;
                            }
                            Console.WriteLine($"휴식을 완료했습니다. 현재 체력 {Rest.HP}");
                            Thread.Sleep(1000);
                            Console.Clear();
                            GameLobby.GameLobby();
                        }
                        else if (Rest.Gold <= 500)
                        {
                            Console.WriteLine("보유 중인 골드가 부족합니다.");
                            Thread.Sleep(1000);
                            Console.Clear();
                            GameLobby.GameLobby();
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("숫자를 입력해주세요!");
                    Thread.Sleep(1000);
                    ShowRest();
                }
            }
        }
    }
}
