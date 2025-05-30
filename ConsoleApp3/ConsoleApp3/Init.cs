﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp3.enumset;

namespace ConsoleApp3
{
    public class Initset
    {
        public void Init()
        {
            GameLobbyset GameLobby = new GameLobbyset();
            Player _player = new Player();

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
                _player.name = playerName;
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
            GameLobby.GameLobby();
        }
    }
}
