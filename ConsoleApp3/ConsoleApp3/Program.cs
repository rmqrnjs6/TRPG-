using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace CSharpDay;

class Program
{
    static void Main(string[] args)
    {
        var gameLogic = new GameLogic();
        gameLogic.StartGame();
    }
}

class GameLogic
{
    private Player _player;
    private itemstatus _item;
    private Inventory _inven;

    private bool _isGameOver = false;

    public void StartGame()
    {
        _item = new itemstatus();
        Init();

        while (!_isGameOver)
        {
            InputHandler();
        }

        Console.WriteLine("게임이 종료되었습니다.");
    }

    private void InputHandler()
    {
        var input = Console.ReadKey();
        if (input.Key == ConsoleKey.Escape)
        {
            _isGameOver = true;
        }
    }

    private void Init()
    {
        Console.Clear();
        Console.WriteLine("스파르타 던전에 오신것을 환영합니다.\n이름을 입력하세요.");
        string? playerName = Console.ReadLine();

        if (string.IsNullOrEmpty(playerName))
        {
            Console.WriteLine("잘못된 이름입니다.");
            Thread.Sleep(1000);
            Init(); // 실제로 이렇 사용하시면 않됨, 재귀호출
        }
        else
        {
            _player = new Player(playerName);
            Console.WriteLine($"{_player.name}님, 입장하셨습니다.");
        }

        // 직업선택
        Console.WriteLine("직업을 선택하세요. [1:전사 | 2:마법사 | 3:궁수]");
        int job = int.Parse(Console.ReadLine());

        if (job >= 1 && job <= 3)  // if (job is >=1 and <=3) 패턴매칭 C# 9.0 ?
        {
            _player.job = (Job)job;

            switch (_player.job)
            {
                case Job.전사:
                    Console.WriteLine($"{_player.job}를 선택했습니다.");
                    break;
                case Job.마법사:
                    Console.WriteLine($"{_player.job}를 선택했습니다.");
                    break;
                case Job.궁수:
                    Console.WriteLine($"{_player.job}를 선택했습니다.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("1~3의 숫자만 입력가능 합니다. 다시 입력해 주십시요.");
        }

        Thread.Sleep(5000);
        Console.Clear();
        Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$=$$$$=$=$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*~=$=*~;~:$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$~=~=.*:$$$$$$$$$$$$$$$$$$$$$$=~~~$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$==~= ~$$$$$$$$$$$$$$$$$$$$$$=  ,=$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$=:=.:$$$$$$$$$$$$$$$$$$$$$*  .=$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$=;  .*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$=,  !*$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$,   *$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$=$$$$$$$$=$..$$$$$$$$$$$$*,  :$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$!!*!$$$$*;!, !=$$$$$$$##;   :$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$-!;.$$$$*-!*.;;$$$$$$#$!, ~!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$=$$=$$$$$$$$$$$$$$$$$#=:,-$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#$##;;:$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$;;###$$#$#=!$#$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$*.=##:##$#$$##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$=~#.-$$$#####$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$=.  ,$####$*##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$;~  :$####; ;##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$~   !#####=~ .$#$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$! =.;.####$~   ~##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$##!$. !-,###*,,,,.!##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$##$$#, !#;###$;=#;-!##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#####  .$####=-;#  ,=#$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$##$##   ::;=#$;;# .  ##$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#$$#,   *~*##*:$.-. -:#$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#$$$$-  .*###*~=-,. ;!#$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#$$$#!  .=###$:,, :*,,,$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#.*###$!$##=-  ~! $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#~#####*--,,     !=$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$######$**;,      :$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#####;:==*.    =$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#######::~#~    $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#####$#:.:$    :$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$######$*$~ =   :$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#####=;;$-~  :$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$####=~,:$~  :$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$##$##=~...;-.;!:$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$###$#*:.. -$*~ $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#####$$~.  =,. $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$##$#$#$!  .!. $$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$##$###$*. .$#;$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$##$$$$$$-  ;$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$##$$$$$$=~  ~$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$##$$$$$$!  ~$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$#$$$$$$$$$. ~$$$$$$!!$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$:$$$$$$$$$$: ~$$$$$$!;$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$,.*$$$$$$$$$$  !$$$$$$=$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$===;   *#$$$$$===:    ====$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$=:~---~~*#$##$!:~~~~------~~$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$\r\n");
        Thread.Sleep(5000);
        Console.Clear();
        GameLobby();
    }

    // 게임 로비 구현 
    private void GameLobby()
    {
        while (true)
        {
            Console.WriteLine("\n스파르타 마을에 오신 여러분 환영합니다\n" +
                    "이곳에서 던전으로 들어가기전 활동을 정할 수 있습니다.\n" +
                    "1. 상태 보기\n" +
                    "2. 인벤토리\n" +
                    "3. 상점\n" +
                    "4. 휴식하기\n\n" +
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
                case lobbychoice.Rest:
                    ShowRest();
                    break;
            }
        }
    }

    // 휴식 기능 구현

    private void ShowRest()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("휴식하기\n" +
                              $"500 G 를 내면 체력을 회복할 수 있습니다.\n" +
                              $"현재 체력{_player.HP}\n" +
                              $" (보유 골드 : {_player.Gold})\n\n" +
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
                    GameLobby();
                }
                else if (inp == 1)
                {

                    if (_player.Gold >= 500)
                    {
                        _player.HP += (int)(_player.HP * 0.3);
                        if (_player.HP >= maxHP)
                        {
                            _player.HP = maxHP;
                        }
                        Console.WriteLine($"휴식을 완료했습니다. 현재 체력 {_player.HP}");
                        Thread.Sleep(1000);
                        Console.Clear();
                        GameLobby();
                    }
                    else if (_player.Gold <= 500)
                    {
                        Console.WriteLine("보유 중인 골드가 부족합니다.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        GameLobby();
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

    // 상점 구현
    private void ShowShop()
    {

        while (true)
        {
            Console.Clear();

            Console.WriteLine("상점\n" +
                              "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                              "[보유 골드]\n" +
                              $"{_player.Gold} G\n\n" +
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
                    GameLobby();
                }
                else if (input == 1)
                {
                    Console.Clear();
                    Sellitem();
                }
                else if (input == 2)
                {
                    Console.Clear();
                    Saleitem();
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

    // 상점 판매 구현
    private void Saleitem()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 판매\n" +
                               "원하는 아이템을 판매 할 수 있습니다.\n\n" +
                               "[보유 골드]\n" +
                               $"{_player.Gold}\n\n" +
                               $"[아이템 목록]\n");
            if (_player.Inven.Count == 0)
            {
                Console.WriteLine("보유 중인 아이템이 없습니다.");
                Thread.Sleep(1000);
                Console.Clear();
                GameLobby();
            }
            else
            {
                for (int i = 0; i < _player.Inven.Count; i++)
                {
                    Console.WriteLine($" {i + 1}. {_player.Inven[i]}");
                }
                Console.WriteLine();
            }
            try
            {
                int input = int.Parse(Console.ReadLine());

                if (input == 0)
                {
                    Console.Clear();
                    GameLobby();
                }


                if (input < 1 || input > _player.Inven.Count)
                {
                    Console.WriteLine("잘못된 번호입니다.");
                    Thread.Sleep(1000);
                    continue;
                }

                Inventory select = _player.Inven[input - 1];

                _player.OffensivePower -= select.OffensivePower;
                _player.DeffensivePower -= select.DefensivePower;
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


    // 상점 구매 구현
    private void Sellitem()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("상점 - 아이템 구매\n" +
                     "필요한 아이템을 얻을 수 있는 상점입니다.\n\n" +
                     "[보유 골드]\n" +
                     $"{_player.Gold} G\n\n" +
                     $"[아이템 목록]\n" +
                     $"- 1 수련자 갑옷    | 방어력 +{_item.TrainingDeffensivePower}  | 수련에 도움을 주는 갑옷입니다.             |  {(_item.TtrainingGlod == 0 ? "구매완료" : _item.TtrainingGlod + " G")}\n" +
                     $"- 2 무쇠갑옷      | 방어력 +{_item.IronDeffensivePower}  | 무쇠로 만들어져 튼튼한 갑옷입니다.           | {(_item.IronGlod == 0 ? "구매완료" : _item.IronGlod + " G")} \n" +
                     $"- 3 스파르타의 갑옷 | 방어력 +{_item.SpartarDeffensivePower} | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.|  {(_item.SpartarGold == 0 ? "구매완료" : _item.SpartarGold + " G")}\n" +
                     $"- 4 알파메일의 갑옷 | 방어력 +{_item.AlphaMaleDeffensivePower} | 전설의 알파메일이 사용했다고 전해지는 갑옷입니다.|  {(_item.SpartarGold == 0 ? "구매완료" : _item.AlphaMaleGold + " G")}\n" +
                     $"- 5 낡은 검      | 공격력 +{_item.OldSwordOffensivePower}  | 쉽게 볼 수 있는 낡은 검 입니다.            |  {(_item.OldSwordGold == 0 ? "구매완료" : _item.OldSwordGold + " G")}\n" +
                     $"- 6 청동 도끼     | 공격력 +{_item.BronzeSwordOffensivePower}  |  어디선가 사용됐던거 같은 도끼입니다.        |  {(_item.BronzeSwordGold == 0 ? "구매완료" : _item.BronzeSwordGold + " G")}\n" +
                     $"- 7 스파르타의 창  | 공격력 +{_item.SpartarSpearOffensivePower}  | 스파르타의 전사들이 사용했다는 전설의 창입니다. |  {(_item.SpartarSpearGold == 0 ? "구매완료" : _item.SpartarSpearGold + " G")}\n" +
                     $"- 8 알파메일의 검  | 공격력 +{_item.AlphaMaleSwordOffensivePower}  |  전설의 알파메일이 사용했다고 전해지는 검입니다..|  {(_item.SpartarSpearGold == 0 ? "구매완료" : _item.AlphaMaleSwordGold + " G")}\n\n" +
                     $"0. 나가기\n\n" +
                     "원하시는 행동을 입력해주세요.\n>>");
            try
            {
                int? input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    Console.Clear();
                    GameLobby();
                }
                else if (input == 1)
                {
                    if (_item.TtrainingGlod <= 0)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                    }
                    else if (_player.Gold < _item.TtrainingGlod)
                    {
                        Console.WriteLine("소지금이 부족합니다!\n");
                    }
                    else
                    {
                        _player.Gold -= _item.TtrainingGlod;
                        _item.TtrainingGlod = 0;
                        _player.Inven.Add(new Inventory($"수련자 갑옷    |", "방어력", 0, _item.TrainingDeffensivePower));
                        Console.WriteLine("구매가 완료되었습니다.\n");
                    }
                    Thread.Sleep(3000);
                    Sellitem();
                }
                else if (input == 2)
                {
                    if (_item.IronGlod <= 0)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                    }
                    else if (_player.Gold < _item.IronGlod)
                    {
                        Console.WriteLine("소지금이 부족합니다!\n");
                    }
                    else
                    {
                        _player.Gold -= _item.IronGlod;
                        _item.IronGlod = 0;
                        _player.Inven.Add(new Inventory($"무쇠 갑옷 |", "방어력", 0, _item.IronDeffensivePower));
                        Console.WriteLine("구매가 완료되었습니다.\n");
                    }
                    Thread.Sleep(3000);
                    Sellitem();
                }

                else if (input == 3)
                {
                    if (_item.SpartarGold <= 0)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                    }
                    else if (_player.Gold < _item.SpartarGold)
                    {
                        Console.WriteLine("소지금이 부족합니다!\n");
                    }
                    else
                    {
                        _player.Gold -= _item.SpartarGold;
                        _item.SpartarGold = 0;
                        _player.Inven.Add(new Inventory($"스파르타의 갑옷 |", "방어력", 0, _item.SpartarDeffensivePower));
                        Console.WriteLine("구매가 완료되었습니다.\n");
                    }
                    Thread.Sleep(3000);
                    Sellitem();
                }
                else if (input == 4)
                {
                    if (_item.AlphaMaleGold <= 0)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                    }
                    else if (_player.Gold < _item.AlphaMaleGold)
                    {
                        Console.WriteLine("소지금이 부족합니다!\n");
                    }
                    else
                    {
                        _player.Gold -= _item.AlphaMaleGold;
                        _item.AlphaMaleGold = 0;
                        _player.Inven.Add(new Inventory($"스파르타의 갑옷 |", "방어력", 0, _item.AlphaMaleDeffensivePower));
                        Console.WriteLine("구매가 완료되었습니다.\n");
                    }
                    Thread.Sleep(3000);
                    Sellitem();
                }

                else if (input == 5)
                {
                    if (_item.OldSwordGold <= 0)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                    }
                    else if (_player.Gold < _item.OldSwordGold)
                    {
                        Console.WriteLine("소지금이 부족합니다!\n");
                    }
                    else
                    {
                        _player.Gold -= _item.OldSwordGold;
                        _item.OldSwordGold = 0;
                        _player.Inven.Add(new Inventory($"낡은 검 |", "공격력", _item.OldSwordOffensivePower, 0));
                        Console.WriteLine("구매가 완료되었습니다.\n");
                    }
                    Thread.Sleep(3000);
                    Sellitem();
                }

                else if (input == 6)
                {
                    if (_item.BronzeSwordGold <= 0)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                    }
                    else if (_player.Gold < _item.BronzeSwordGold)
                    {
                        Console.WriteLine("소지금이 부족합니다!\n");
                    }
                    else
                    {
                        _player.Gold -= _item.BronzeSwordGold;
                        _item.BronzeSwordGold = 0;
                        _player.Inven.Add(new Inventory($"청동 검 |", "공격력", _item.BronzeSwordOffensivePower, 0));
                        Console.WriteLine("구매가 완료되었습니다.\n");
                    }
                    Thread.Sleep(3000);
                    Sellitem();
                }

                else if (input == 7)
                {
                    if (_item.SpartarSpearGold <= 0)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                    }
                    else if (_player.Gold < _item.SpartarSpearGold)
                    {
                        Console.WriteLine("소지금이 부족합니다!\n");
                    }
                    else
                    {
                        _player.Gold -= _item.SpartarSpearGold;
                        _item.SpartarSpearGold = 0;
                        _player.Inven.Add(new Inventory($"스파르타의 창 |", "공격력", _item.SpartarSpearOffensivePower, 0));
                        Console.WriteLine("구매가 완료되었습니다.\n");
                    }
                    Thread.Sleep(3000);
                    Sellitem();
                }
                else if (input == 8)
                {
                    if (_item.AlphaMaleSwordGold <= 0)
                    {
                        Console.WriteLine("이미 구매한 아이템입니다.\n");
                    }
                    else if (_player.Gold < _item.AlphaMaleSwordGold)
                    {
                        Console.WriteLine("소지금이 부족합니다!\n");
                    }
                    else
                    {
                        _player.Gold -= _item.AlphaMaleSwordGold;
                        _item.AlphaMaleGold = 0;
                        _player.Inven.Add(new Inventory($"알파메일의 검 |", "공격력", _item.SpartarSpearOffensivePower, 0));
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


    //상태 정보 창 구현

    private void ShowStatus()
    {
        Console.Clear();
        int bonusOff = _player.Inven.Where(i => i.IsEquipped).Sum(i => i.OffensivePower);
        int bonusDff = _player.Inven
            .Where(i => i.IsEquipped)
            .Sum(i => i.DefensivePower);



        Console.WriteLine("상태 보기\n" +
                          "캐릭터의 정보가 표시됩니다.\n\n" +
                          $"이름: {_player.name}\n" +
                          $"직업: {_player.job}\n" +
                          $"레벨: {_player.level}\n" +
                          $"공격력: {_player.OffensivePower} (+{bonusOff})\n" +
                          $"방어력: {_player.DeffensivePower} (+{bonusDff})\n" +
                          $"체력: {_player.HP}\n" +
                          $"Gold: {_player.Gold}\n");

        Console.WriteLine("0. 로비로 가기");


        bool input = int.TryParse(Console.ReadLine(), out int inp);
        if (input)
        {
            if (inp == 0)
            {
                Console.Clear();
                GameLobby();  // 로비로 돌아가게 처리
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

    // 인벤토리 구현
    private void ShowInven()
    {
        while (true)
        {
            try
            {
                Console.Clear();
                Console.WriteLine("인벤토리\n" +
                          "보유 중인 아이템을 관리할 수 있습니다.\n\n" +
                          $"[아이템 목록]\n");
                if (_player.Inven.Count == 0)
                {
                    Console.WriteLine("보유 중인 아이템이 없습니다.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    GameLobby();
                }
                else
                {
                    for (int i = 0; i < _player.Inven.Count; i++)
                    {
                        Console.WriteLine($" {i + 1}. {_player.Inven[i]}");
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
                    InsMent();
                }
                else if (input == 2)
                {
                    GameLobby();
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


    // 장착 관리 구현
    private void InsMent()
    {
        while (true)
        {
            Console.WriteLine("인벤토리 - 장착 관리\n");
            Console.WriteLine("[장착 가능한 아이템]");
            for (int i = 0; i < _player.Inven.Count; i++)
            {
                Console.WriteLine($"- {i + 1}. {_player.Inven[i]}\n");
            }
            Console.WriteLine("0. 나가기\n");
            Console.Write("원하시는 행동을 입력해주세요.\n>> ");

            try
            {
                int input = int.Parse(Console.ReadLine());

                if (input == 0)
                {
                    Console.Clear();
                    GameLobby();
                }


                if (input < 1 || input > _player.Inven.Count)
                {
                    Console.WriteLine("잘못된 번호입니다.");
                    Thread.Sleep(1000);
                    continue;
                }

                Inventory select = _player.Inven[input - 1];

                _player.OffensivePower += select.OffensivePower;
                _player.DeffensivePower += select.DefensivePower;
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






class Player
{
    public string name;
    public Job job;
    public int level = 1;
    public int OffensivePower { get; set; } = 10;
    public int DeffensivePower { get; set; } = 5;
    public int HP = 50;
    public int Gold = 100000;

    public List<Inventory> InventoryItems { get; set; }

    public Player(int Offpower, int Defenspower)
    {
        OffensivePower = Offpower;
        DeffensivePower = Defenspower;
        InventoryItems = new List<Inventory>();
    }

    public int TotalOffpower
    {
        get
        {
            return OffensivePower + InventoryItems
                .Where(item => item.IsEquipped)
                .Sum(item => item.OffensivePower);

        }
    }
    public int TotalDefenspower
    {
        get
        {
            return DeffensivePower + InventoryItems
                .Where(item => item.IsEquipped)
                .Sum(item => item.DefensivePower);

        }
    }



    public List<Inventory> Inven { get; } = new List<Inventory>();

    public Player(string name)
    {
        this.name = name;
    }
}


class itemstatus
{
    public int TrainingDeffensivePower = 5;
    public int TtrainingGlod = 1000;

    public int IronDeffensivePower = 9;
    public int IronGlod = 1500;

    public int SpartarDeffensivePower = 15;
    public int SpartarGold = 3500;

    public int AlphaMaleDeffensivePower = 999;
    public int AlphaMaleGold = 1000000;

    public int OldSwordOffensivePower = 2;
    public int OldSwordGold = 600;

    public int BronzeSwordOffensivePower = 5;
    public int BronzeSwordGold = 1500;

    public int SpartarSpearOffensivePower = 7;
    public int SpartarSpearGold = 2100;

    public int AlphaMaleSwordOffensivePower = 999;
    public int AlphaMaleSwordGold = 1000000;



}

public class Inventory
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int OffensivePower { get; set; }
    public int DefensivePower { get; set; }
    public bool IsEquipped { get; set; }

    public Inventory(string name, string type, int OffPower, int DeffPower)
    {
        Name = name;
        Type = type;
        OffensivePower = OffPower;
        DefensivePower = DeffPower;
        IsEquipped = false;
    }

    public override string ToString()
    {
        string equippedText = IsEquipped ? "(장착 중)" : "";
        return $"{Name}{equippedText} 타입: {Type} | 공격력 +{OffensivePower} | 방어력 +{DefensivePower}";
    }
}


public enum invenchoice
{
    traning = 1,
    iron = 2,
    sp1 = 3,
    old = 4,
    bronze = 5,
    sp2 = 6
}

public enum Job
{
    전사 = 1,
    마법사 = 2,
    궁수 = 3
}

public enum lobbychoice
{
    Status = 1,
    Inventory = 2,
    Shop = 3,
    Rest = 4
}
