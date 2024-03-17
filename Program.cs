﻿using System;
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

    // Словарь для хранения статистики
    static Dictionary<GameStats, int> stats = new Dictionary<GameStats, int>
    {
        { GameStats.GamesPlayed, 0 },
        { GameStats.WinsInRound, 0 },
        { GameStats.LossesInRound, 0 },
        { GameStats.WinsInGames, 0 }
    };

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
        string nickname = Console.ReadLine();
        int age;
        do
        {
            Console.Write("Введите ваш возраст (только 12+): ");
        }
        while (!int.TryParse(Console.ReadLine(), out age) || age < 12);

        // Вывод рейтинговой таблицы
        DisplayStats();

        int playerChoice = PlayerTurn();
        int opponentChoice = ProgressOfDefeat();
        RoundResult(playerChoice, opponentChoice);
    }

    static void DisplayStats()
    {
        Console.WriteLine("\n+---------------------------------------------------+");
        Console.WriteLine("|                  Рейтинговая таблица              |");
        Console.WriteLine("+------------+------------+------------+------------+");
        Console.WriteLine("| Игр сыграно| Побед в    | Проигрышей | Побед в    |");
        Console.WriteLine("|            | раундах    | в раундах  | играх      |");
        Console.WriteLine("+------------+------------+------------+------------+");
        Console.WriteLine($"| {stats[GameStats.GamesPlayed],10} | {stats[GameStats.WinsInRound],10} | {stats[GameStats.LossesInRound],10} | {stats[GameStats.WinsInGames],8}   |");
        Console.WriteLine("+------------+------------+------------+------------+");
    }

    static int PlayerTurn()
    {
        Console.WriteLine("\nГотовы ли вы начать? Нажмите Enter, чтобы продолжить...");
        Console.ReadLine();

        int playerChoice;
        do
        {
            Console.WriteLine("Выберите ваш ход: 1 - Камень, 2 - Ножницы, 3 - Бумага");
            Console.Write("Ваш выбор: ");
        } while (!int.TryParse(Console.ReadLine(), out playerChoice) || playerChoice < 1 || playerChoice > 3);

        // Выводим на экран выбор игрока
        VisualizeChoice(playerChoice, "Ваш выбор");
        return playerChoice;
    }

    static int ProgressOfDefeat()
    {
        Random random = new Random();
        int opponentChoice = random.Next(1, 4); // Генерируем выбор от 1 до 3

        // Визуализация выбора противника
        VisualizeChoice(opponentChoice, "Выбор противника, Билли");
        return opponentChoice;
    }
    static void VisualizeChoice(int choice, string owner)
    {
        Console.WriteLine($"{owner}:");
        switch (choice)
        {
            case 1: // Камень
                Console.WriteLine("    _______");
                Console.WriteLine("---'   ____)");
                Console.WriteLine("      (_____)");
                Console.WriteLine("      (_____)");
                Console.WriteLine("      (____)");
                Console.WriteLine("---.__(___)");
                break;
            case 2: // Ножницы
                Console.WriteLine("    _______");
                Console.WriteLine("---'   ____)____");
                Console.WriteLine("          ______)");
                Console.WriteLine("       __________)");
                Console.WriteLine("      (____)");
                Console.WriteLine("---.__(___)");
                break;
            case 3: // Бумага
                Console.WriteLine("    _______");
                Console.WriteLine("---'   ____)____");
                Console.WriteLine("          ______)");
                Console.WriteLine("          _______)");
                Console.WriteLine("         _______)");
                Console.WriteLine("---.__________)");
                break;
        }
    }

    static void RoundResult(int playerChoice, int opponentChoice)
    {
        // Правила определения победителя
        if (playerChoice == opponentChoice)
        {
            Console.WriteLine("Ничья!");
        }
        else if ((playerChoice == 1 && opponentChoice == 2) ||
                 (playerChoice == 2 && opponentChoice == 3) ||
                 (playerChoice == 3 && opponentChoice == 1))
        {
            Console.WriteLine("Вы победили!");
            stats[GameStats.WinsInRound]++;
            stats[GameStats.WinsInGames]++;
        }
        else
        {
            Console.WriteLine("Вы проиграли :(");
            stats[GameStats.LossesInRound]++;
        }

        // Обновление количества сыгранных игр
        stats[GameStats.GamesPlayed]++;

        // Повторный вывод обновленной рейтинговой таблицы
        DisplayStats();
    }
}