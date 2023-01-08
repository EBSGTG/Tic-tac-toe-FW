using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.Sockets;
using System.Xml;

namespace Program;

internal class Program
{
    static void Main(string[] args)
    {
        
        if (GameMode())
        {
            var playerOne = new GameAccount("Bender");
            var playerTwo = new VipAccount("BOT");
            var g1 = VsBot.ReturningClass.MatchmakingG(playerOne, playerTwo);
            g1.Process();
            g1.Process();
            Console.WriteLine(playerOne.GetStats());
            Console.WriteLine(playerTwo.GetStats());
        }
        else
        {
            var playerOne = new GameAccount("Bender");
            var playerTwo = new VipAccount("Stepan");
            var g2 = Matchmaking.ReturningClass.MatchmakingG(playerOne, playerTwo);
            g2.Process();
            g2.Process();
            Console.WriteLine(playerOne.GetStats());
            Console.WriteLine(playerTwo.GetStats());
        }
    }
    static bool GameMode()
    {
        bool choose = false;
        Console.WriteLine("Hello<з pls write which game mode u want to play:\n" +
                          "1 - vs BOT\n" +
                          "2 - vs another player ");
        var a = int.Parse(Console.ReadLine());
        choose = (a == 1) ? true : false;
        return choose;
    }
}