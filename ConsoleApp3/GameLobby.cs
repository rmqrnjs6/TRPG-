using System;

public class ＧameLobby
{
    public void GameLobby()
    {
        while (true)
        {
            Console.WriteLine("\n스파르타 마을에 오신 여러분 환영합니다\n" +
                    "이곳에서 던전으로 들어가기전 활동을 정할 수 있습니다.\n" +
                    "1. 상태 보기\n" +
                    "2. 인벤토리\n" +
                    "3. 상점\n\n" +
                    "원하시는 행동을 입력해주세요.(1~3)\n" +
                    ">>");
            int choice = int.Parse(Console.ReadLine());
            switch ((lobbychoice)choice)
            {
                case lobbychoice.Status:
                    ShowStatus();
                    break;
                case lobbychoice.Inventory:
                    ShowInven();
                    break;
                case lobbychoice.Shop:
                    ShowShop();
                    break;
            }
        }
    }
}
