using System;

class RockPaperScissorsGame
{
    static void Main(string[] args)
    {
        // Приветствие
        Console.WriteLine("Добро пожаловать в игру 'Камень, ножницы, бумага'!");

        // Правила игры в виде таблицы
        Console.WriteLine("+-----------------------------------------------+");
        Console.WriteLine("|                   Правила игры                |");
        Console.WriteLine("+-----------------------------------------------+");
        Console.WriteLine("| Камень побеждает ножницы.                     |");
        Console.WriteLine("| Ножницы побеждают бумагу.                     |");
        Console.WriteLine("| Бумага побеждает камень.                      |");
        Console.WriteLine("+-----------------------------------------------+");

        // Запрос никнейма и возраста
        Console.Write("\nПожалуйста, введите ваш никнейм: ");
        string nickname = Console.ReadLine();
        int age;
        do
        {
            Console.Write("Введите ваш возраст (только 12+): ");
        } while (!int.TryParse(Console.ReadLine(), out age) || age < 12);

        // Инициализация переменных для рейтинговой таблицы
        int winsInRound = 0;
        int lossesInRound = 0;
        int gamesPlayed = 0;
        int winsInGames = 0;

        // Вывод рейтинговой таблицы
        Console.WriteLine("\n+---------------------------------------------------+");
        Console.WriteLine("|                  Рейтинговая таблица              |");
        Console.WriteLine("+------------+------------+------------+------------+");
        Console.WriteLine("| Игр сыграно| Побед в    | Проигрышей | Побед в    |");
        Console.WriteLine("|            | раундах    | в раундах  | играх      |");
        Console.WriteLine("+------------+------------+------------+------------+");
        Console.WriteLine($"| {gamesPlayed,10} | {winsInRound,10} | {lossesInRound,10} | {winsInGames,8}   |");
        Console.WriteLine("+------------+------------+------------+------------+");

        playerTurn();
    }
    static void playerTurn()
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
        switch (playerChoice)
        {
            case 1:
                Console.WriteLine("Вы выбрали: Камень");
                break;
            case 2:
                Console.WriteLine("Вы выбрали: Ножницы");
                break;
            case 3:
                Console.WriteLine("Вы выбрали: Бумага");
                break;
        }
        progressOfDefeat();
    }
    static void progressOfDefeat()
    {
        int[] randomValues = new int[3];
        Random random = new Random();
        int sum = 0;

        // Заполнение массива случайными числами и расчет суммы
        for (int i = 0; i < randomValues.Length; i++)
        {
            randomValues[i] = random.Next(1, 91); // Генерация чисел от 1 до 90
            sum += randomValues[i];
        }

        // Среднее значение для определения выбора противника
        int average = sum / randomValues.Length;

        string opponentChoice = "";
        int choice;

        if (average >= 1 && average <= 30)
        {
            opponentChoice = "Камень";
            choice = 1;
        }
        else if (average > 30 && average <= 60)
        {
            opponentChoice = "Ножницы";
            choice = 2;
        }
        else // if (average > 60 && average <= 90)
        {
            opponentChoice = "Бумага";
            choice = 3;
        }

        // Вывод выбора противника
        Console.WriteLine($"У Вашего противника, Билли: {opponentChoice}");

        // Визуализация выбора противника
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
}