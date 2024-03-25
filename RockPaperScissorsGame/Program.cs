using System;
using System.Collections.Generic;

class RockPaperScissorsGame
{
    enum GameStats
    {
        GamesPlayed,
        WinsInRound,
        LossesInRound,
        WinsInGames
    }

    static Dictionary<GameStats, int> stats = new Dictionary<GameStats, int>
    {
        { GameStats.GamesPlayed, 0 },
        { GameStats.WinsInRound, 0 },
        { GameStats.LossesInRound, 0 },
        { GameStats.WinsInGames, 0 }
    };

    static string playerName;
    static int playerAge;

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the 'Rock, Paper, Scissors' game!");
        Console.WriteLine("+-----------------------------------------------+");
        Console.WriteLine("|                   Game Rules                  |");
        Console.WriteLine("+-----------------------------------------------+");
        Console.WriteLine("| Rock defeats scissors.                        |");
        Console.WriteLine("| Scissors defeat paper.                        |");
        Console.WriteLine("| Paper defeats rock.                           |");
        Console.WriteLine("+-----------------------------------------------+");

        Console.Write("\nPlease, enter your Nickname: ");
        playerName = Console.ReadLine();

        do
        {
            Console.Write("Enter your age (12+ only): ");
        }
        while (!int.TryParse(Console.ReadLine(), out playerAge) || playerAge < 12);

        bool continuePlaying = true;
        while (continuePlaying)
        {
            PlayGame();
            continuePlaying = AskToContinue();
        }
    }

    static void PlayGame()
    {
        int roundWins = 0;

        int roundsToPlay = 3;
        while (roundsToPlay > 0)
        {
            int playerChoice = PlayerTurn();
            int opponentChoice = ProgressOfDefeat();
            int result = RoundResult(playerChoice, opponentChoice);

            if (result != 0) // Если не ничья
            {
                roundsToPlay--;
                if (result == 1) roundWins++;
            }
        }

        if (roundWins >= 2)
        {
            stats[GameStats.WinsInGames]++;
            Console.WriteLine($"You won {roundWins} round(s) out of 3.");
        }

        stats[GameStats.GamesPlayed]++;
        DisplayStats();
    }

    static bool AskToContinue()
    {
        Console.WriteLine("Would you like to continue the duel? (yes/no)");
        string answer = Console.ReadLine().Trim().ToLower();
        if (answer == "yes")
        {
            Console.Clear();
            DisplayStats();
            return true;
        }
        else
        {
            return false;
        }
    }

    static void DisplayStats()
    {
        Console.WriteLine("\n+-------------------------------------------------+");
        Console.WriteLine("|                  Player and their data           |");
        Console.WriteLine("+------------+------------+                       |");
        Console.WriteLine($"| Name       | {playerName,10} |                     |");
        Console.WriteLine($"| Age        | {playerAge,10} |                        |");
        Console.WriteLine("+------------+------------+                       |");
        Console.WriteLine("|                  Scoreboard                      |");
        Console.WriteLine("+------------+------------+------------+------------+");
        Console.WriteLine("| Games      | Wins in    | Losses in  | Wins in    |");
        Console.WriteLine("| played     | rounds     | rounds     | games      |");
        Console.WriteLine("+------------+------------+------------+------------+");
        Console.WriteLine($"| {stats[GameStats.GamesPlayed],10} | {stats[GameStats.WinsInRound],10} | {stats[GameStats.LossesInRound],10} | {stats[GameStats.WinsInGames],8}   |");
        Console.WriteLine("+------------+------------+------------+------------+");
    }

    static int PlayerTurn()
    {
 
        int playerChoice;
        do
        {
            Console.WriteLine("Make your choice, Your move: 1 - Rock, 2 - Scissors, 3 - Paper");
            Console.Write("Your choice: ");
        }
        while (!int.TryParse(Console.ReadLine(), out playerChoice) || playerChoice < 1 || playerChoice > 3);

        VisualizeChoice(playerChoice, "Your choice");
        return playerChoice;
    }

    static int ProgressOfDefeat()
    {
        Random random = new Random();
        int opponentChoice = random.Next(1, 4);
        VisualizeChoice(opponentChoice, "Choosing your opponent, Billy");
        return opponentChoice;
    }

    static void VisualizeChoice(int choice, string owner)
    {
        Console.WriteLine($"{owner}:");
        switch (choice)
        {
            case 1:
                Console.WriteLine("    _______");
                Console.WriteLine("---'   ____)");
                Console.WriteLine("      (_____)");
                Console.WriteLine("      (_____)");
                Console.WriteLine("      (____)");
                Console.WriteLine("---.__(___)");
                break;
            case 2:
                Console.WriteLine("    _______");
                Console.WriteLine("---'   ____)____");
                Console.WriteLine("          ______)");
                Console.WriteLine("       __________)");
                Console.WriteLine("      (____)");
                Console.WriteLine("---.__(___)");
                break;
            case 3:
                Console.WriteLine("    _______");
                Console.WriteLine("---'   ____)____");
                Console.WriteLine("          ______)");
                Console.WriteLine("          _______)");
                Console.WriteLine("         _______)");
                Console.WriteLine("---.__________)");
                break;
        }
    }

    static int RoundResult(int playerChoice, int opponentChoice)
    {
        if (playerChoice == opponentChoice)
        {
            Console.WriteLine("It's a tie! Play again.");
            return 0; // Ничья
        }
        else if ((playerChoice == 1 && opponentChoice == 2) ||
                 (playerChoice == 2 && opponentChoice == 3) ||
                 (playerChoice == 3 && opponentChoice == 1))
        {
            Console.WriteLine("You won the round!");
            stats[GameStats.WinsInRound]++;
            return 1; // Win
        }
        else
        {
            Console.WriteLine("You lost the round.");
            stats[GameStats.LossesInRound]++;
            return -1; // Game over, baby
        }
    }
}