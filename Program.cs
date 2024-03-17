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

    // Новые поля для хранения имени и возраста
    static string playerName;
    static int playerAge;

    static void Main(string[] args)
    {
        Console.WriteLine("Добро пожаловать в игру 'Камень, ножницы, бумага'!");
        Console.WriteLine("+-----------------------------------------------+");
        Console.WriteLine("|                   Правила игры                |");
        Console.WriteLine("+-----------------------------------------------+");
        Console.WriteLine("| Камень побеждает ножницы.                     |");
        Console.WriteLine("| Ножницы побеждают бумагу.                     |");
        Console.WriteLine("| Бумага побеждает камень.                      |");
        Console.WriteLine("+-----------------------------------------------+");

        Console.Write("\nПожалуйста, введите ваш никнейм: ");
        playerName = Console.ReadLine();

        do
        {
            Console.Write("Введите ваш возраст (только 12+): ");
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
        int roundWins = 0; // Счетчик побед в раундах

        int roundsToPlay = 3;
        while (roundsToPlay > 0)
        {
            int playerChoice = PlayerTurn();
            int opponentChoice = ProgressOfDefeat();
            int result = RoundResult(playerChoice, opponentChoice);

            if (result != 0) // Если не ничья
            {
                roundsToPlay--;
                if (result == 1) roundWins++; // Подсчет побед
            }
        }

        if (roundWins >= 2)
        {
            stats[GameStats.WinsInGames]++;
            Console.WriteLine($"Вы выиграли {roundWins} раунд(ов) из 3.");
        }

        stats[GameStats.GamesPlayed]++;
        DisplayStats();
    }

    static bool AskToContinue()
    {
        Console.WriteLine("Хотите продолжить поединок? (да/нет)");
        string answer = Console.ReadLine().Trim().ToLower();
        if (answer == "да")
        {
            Console.Clear();
            DisplayStats(); // Выводим статистику снова после очистки экрана
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
        Console.WriteLine("|                  Игрок и его данные             |");
        Console.WriteLine("+------------+------------+                       |");
        Console.WriteLine($"| Имя        | {playerName,10}|                  |");
        Console.WriteLine($"| Возраст    | {playerAge,10} |                  |");
        Console.WriteLine("+------------+------------+                       |");
        Console.WriteLine("|                  Рейтинговая таблица            |");
        Console.WriteLine("+------------+------------+------------+------------+");
        Console.WriteLine("| Игр сыграно| Побед в    | Проигрышей | Побед в    |");
        Console.WriteLine("|            | раундах    | в раундах  | играх      |");
        Console.WriteLine("+------------+------------+------------+------------+");
        Console.WriteLine($"| {stats[GameStats.GamesPlayed],10} | {stats[GameStats.WinsInRound],10} | {stats[GameStats.LossesInRound],10} | {stats[GameStats.WinsInGames],8}   |");
        Console.WriteLine("+------------+------------+------------+------------+");
    }

    static int PlayerTurn()
    {
 
        int playerChoice;
        do
        {
            Console.WriteLine("Выберите ваш ход: 1 - Камень, 2 - Ножницы, 3 - Бумага");
            Console.Write("Ваш выбор: ");
        }
        while (!int.TryParse(Console.ReadLine(), out playerChoice) || playerChoice < 1 || playerChoice > 3);

        VisualizeChoice(playerChoice, "Ваш выбор");
        return playerChoice;
    }

    static int ProgressOfDefeat()
    {
        Random random = new Random();
        int opponentChoice = random.Next(1, 4);
        VisualizeChoice(opponentChoice, "Выбор противника, Билли");
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
            Console.WriteLine("Ничья! Играйте еще раз.");
            return 0; // Ничья
        }
        else if ((playerChoice == 1 && opponentChoice == 2) ||
                 (playerChoice == 2 && opponentChoice == 3) ||
                 (playerChoice == 3 && opponentChoice == 1))
        {
            Console.WriteLine("Вы победили раунд!");
            stats[GameStats.WinsInRound]++;
            return 1; // Победа
        }
        else
        {
            Console.WriteLine("Вы проиграли раунд.");
            stats[GameStats.LossesInRound]++;
            return -1; // Проигрыш
        }
    }
}