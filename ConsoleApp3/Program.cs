using System;
using System.Collections.Generic;

namespace CalculatorProject
{
    public interface ICalculator
    {
        void Run();
        void SetColor();
    }
    public abstract class CalculatorBase : ICalculator
    {
        protected List<string> history = new List<string>();
        protected ConsoleColor foregroundColor;
        protected ConsoleColor backgroundColor;

        public abstract void Run();

        public virtual void SetColor()
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
            Console.Clear();
        }

        protected void PrintHistory()
        {
            if (history.Count > 0)
            {
                Console.WriteLine("\n--- История вычислений ---");
                foreach (var item in history)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("---------------------------\n");
            }
        }

        protected void AddToHistory(string operation)
        {
            history.Add($"{DateTime.Now:HH:mm:ss}: {operation}");
        }

        protected void ClearHistory()
        {
            history.Clear();
            Console.WriteLine("История очищена.");
        }

        protected double GetNumber(string prompt)
        {
            double number;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out number))
                    return number;
                Console.WriteLine("Ошибка! Введите корректное число.");
            }
        }
    }

    public class BasicCalculator : CalculatorBase
    {
        public BasicCalculator()
        {
            foregroundColor = ConsoleColor.White;
            backgroundColor = ConsoleColor.DarkBlue;
        }

        public override void Run()
        {
            SetColor();
            Console.WriteLine("=== ОБЫЧНЫЙ РЕЖИМ КАЛЬКУЛЯТОРА ===\n");

            while (true)
            {
                PrintHistory();
                Console.WriteLine("Доступные операции:");
                Console.WriteLine("1. Сложение (+)");
                Console.WriteLine("2. Вычитание (-)");
                Console.WriteLine("3. Умножение (*)");
                Console.WriteLine("4. Деление (/)");
                Console.WriteLine("5. Процент (%)");
                Console.WriteLine("6. Степень числа (^)");
                Console.WriteLine("7. Квадратный корень (√)");
                Console.WriteLine("8. Обратное число (1/x)");
                Console.WriteLine("9. Очистить историю (clear)");
                Console.WriteLine("0. Выйти из режима (exit)");
                Console.Write("\nВыберите операцию: ");

                string choice = Console.ReadLine();

                if (choice == "0" || choice.ToLower() == "exit")
                    break;

                ProcessOperation(choice);
            }
        }

        private void ProcessOperation(string choice)
        {
            try
            {
                double result = 0;
                double num1, num2;
                string operationText = "";

                switch (choice)
                {
                    case "1":
                        num1 = GetNumber("Введите первое число: ");
                        num2 = GetNumber("Введите второе число: ");
                        result = num1 + num2;
                        operationText = $"{num1} + {num2} = {result}";
                        break;

                    case "2":
                        num1 = GetNumber("Введите первое число: ");
                        num2 = GetNumber("Введите второе число: ");
                        result = num1 - num2;
                        operationText = $"{num1} - {num2} = {result}";
                        break;
                    case "3":
                        num1 = GetNumber("Введите первое число: ");
                        num2 = GetNumber("Введите второе число: ");
                        result = num1 * num2;
                        operationText = $"{num1} * {num2} = {result}";
                        break;

                    case "4":
                        num1 = GetNumber("Введите первое число: ");
                        num2 = GetNumber("Введите второе число: ");
                        if (num2 == 0)
                            throw new DivideByZeroException("Деление на ноль невозможно!");
                        result = num1 / num2;
                        operationText = $"{num1} / {num2} = {result}";
                        break;

                    case "5":
                        num1 = GetNumber("Введите число: ");
                        num2 = GetNumber("Введите процент: ");
                        result = (num1 * num2) / 100;
                        operationText = $"{num1}% от {num2} = {result}";
                        break;

                    case "6":
                        num1 = GetNumber("Введите число: ");
                        num2 = GetNumber("Введите степень: ");
                        result = Math.Pow(num1, num2);
                        operationText = $"{num1} ^ {num2} = {result}";
                        break;

                    case "7":
                        num1 = GetNumber("Введите число: ");
                        if (num1 < 0)
                            throw new ArgumentException("Нельзя извлечь корень из отрицательного числа!");
                        result = Math.Sqrt(num1);
                        operationText = $"√{num1} = {result}";
                        break;

                    case "8":
                        num1 = GetNumber("Введите число: ");
                        if (num1 == 0)
                            throw new DivideByZeroException("Обратное число для нуля не существует!");
                        result = 1 / num1;
                        operationText = $"1 / {num1} = {result}";
                        break;

                    case "9":
                    case "clear":
                        ClearHistory();
                        return;

                    default:
                        Console.WriteLine("Неверный выбор операции!");
                        return;
                }

                Console.WriteLine($"Результат: {result}");
                AddToHistory(operationText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    public class EngineeringCalculator : CalculatorBase
    {
        public EngineeringCalculator()
        {
            foregroundColor = ConsoleColor.Green;
            backgroundColor = ConsoleColor.Black;
        }

        public override void Run()
        {
            SetColor();
            Console.WriteLine("=== ИНЖЕНЕРНЫЙ РЕЖИМ КАЛЬКУЛЯТОРА ===\n");

            while (true)
            {
                PrintHistory();
                Console.WriteLine("Доступные операции:");
                Console.WriteLine("1. Синус (sin)");
                Console.WriteLine("2. Косинус (cos)");
                Console.WriteLine("3. Тангенс (tan)");
                Console.WriteLine("4. Котангенс (ctg)");
                Console.WriteLine("5. Логарифм по основанию 10 (log)");
                Console.WriteLine("6. Натуральный логарифм (ln)");
                Console.WriteLine("7. Экспонента (exp)");
                Console.WriteLine("8. Абсолютное значение (abs)");
                Console.WriteLine("9. Очистить историю (clear)");
                Console.WriteLine("0. Выйти из режима (exit)");
                Console.Write("\nВыберите операцию: ");

                string choice = Console.ReadLine();

                if (choice == "0" || choice.ToLower() == "exit")
                    break;
                ProcessOperation(choice);
            }
        }

        private void ProcessOperation(string choice)
        {
            try
            {
                double result = 0;
                double num;
                string operationText = "";

                switch (choice)
                {
                    case "1":
                        num = GetNumber("Введите угол в градусах: ");
                        result = Math.Sin(num * Math.PI / 180);
                        operationText = $"sin({num}°) = {result}";
                        break;

                    case "2":
                        num = GetNumber("Введите угол в градусах: ");
                        result = Math.Cos(num * Math.PI / 180);
                        operationText = $"cos({num}°) = {result}";
                        break;

                    case "3":
                        num = GetNumber("Введите угол в градусах: ");
                        double rad = num * Math.PI / 180;
                        if (Math.Abs(Math.Cos(rad)) < 1e-10)
                            throw new ArgumentException("Тангенс не определен для этого угла!");
                        result = Math.Tan(rad);
                        operationText = $"tan({num}°) = {result}";
                        break;

                    case "4":
                        num = GetNumber("Введите угол в градусах: ");
                        rad = num * Math.PI / 180;
                        if (Math.Abs(Math.Sin(rad)) < 1e-10)
                            throw new ArgumentException("Котангенс не определен для этого угла!");
                        result = 1 / Math.Tan(rad);
                        operationText = $"ctg({num}°) = {result}";
                        break;

                    case "5":
                        num = GetNumber("Введите число: ");
                        if (num <= 0)
                            throw new ArgumentException("Логарифм определен только для положительных чисел!");
                        result = Math.Log10(num);
                        operationText = $"log10({num}) = {result}";
                        break;

                    case "6":
                        num = GetNumber("Введите число: ");
                        if (num <= 0)
                            throw new ArgumentException("Натуральный логарифм определен только для положительных чисел!");
                        result = Math.Log(num);
                        operationText = $"ln({num}) = {result}";
                        break;

                    case "7":
                        num = GetNumber("Введите число: ");
                        result = Math.Exp(num);
                        operationText = $"exp({num}) = {result}";
                        break;

                    case "8":
                        num = GetNumber("Введите число: ");
                        result = Math.Abs(num);
                        operationText = $"|{num}| = {result}";
                        break;

                    case "9":
                    case "clear":
                        ClearHistory();
                        return;

                    default:
                        Console.WriteLine("Неверный выбор операции!");
                        return;
                }

                Console.WriteLine($"Результат: {result}");
                AddToHistory(operationText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    public class DateCalculator : CalculatorBase
    {
        public DateCalculator()
        {
            foregroundColor = ConsoleColor.Yellow;
            backgroundColor = ConsoleColor.DarkMagenta;
        }
        public override void Run()
        {
            SetColor();
            Console.WriteLine("=== РЕЖИМ КАЛЬКУЛЯТОРА ДАТ ===\n");

            while (true)
            {
                PrintHistory();
                Console.WriteLine("Доступные операции:");
                Console.WriteLine("1. Разница между двумя датами");
                Console.WriteLine("2. Дата + количество дней");
                Console.WriteLine("3. Дата - количество дней");
                Console.WriteLine("4. Разница в днях, месяцах, годах");
                Console.WriteLine("9. Очистить историю (clear)");
                Console.WriteLine("0. Выйти из режима (exit)");
                Console.Write("\nВыберите операцию: ");

                string choice = Console.ReadLine();

                if (choice == "0" || choice.ToLower() == "exit")
                    break;

                ProcessOperation(choice);
            }
        }

        private DateTime GetDate(string prompt)
        {
            DateTime date;
            while (true)
            {
                Console.Write(prompt + " (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out date))
                    return date;
                Console.WriteLine("Ошибка! Введите дату в правильном формате.");
            }
        }

        private void ProcessOperation(string choice)
        {
            try
            {
                DateTime date1, date2;
                int days;
                string operationText = "";

                switch (choice)
                {
                    case "1":
                        date1 = GetDate("Введите первую дату");
                        date2 = GetDate("Введите вторую дату");
                        TimeSpan difference = date2 - date1;
                        operationText = $"Разница между {date1:dd.MM.yyyy} и {date2:dd.MM.yyyy}: {difference.TotalDays} дней";
                        Console.WriteLine($"Разница: {Math.Abs(difference.TotalDays)} дней");
                        break;

                    case "2":
                        date1 = GetDate("Введите дату");
                        days = (int)GetNumber("Введите количество дней для добавления: ");
                        date2 = date1.AddDays(days);
                        operationText = $"{date1:dd.MM.yyyy} + {days} дней = {date2:dd.MM.yyyy}";
                        Console.WriteLine($"Результат: {date2:dd.MM.yyyy}");
                        break;

                    case "3":
                        date1 = GetDate("Введите дату");
                        days = (int)GetNumber("Введите количество дней для вычитания: ");
                        date2 = date1.AddDays(-days);
                        operationText = $"{date1:dd.MM.yyyy} - {days} дней = {date2:dd.MM.yyyy}";
                        Console.WriteLine($"Результат: {date2:dd.MM.yyyy}");
                        break;

                    case "4":
                        date1 = GetDate("Введите первую дату");
                        date2 = GetDate("Введите вторую дату");

                        int years = date2.Year - date1.Year;
                        int months = date2.Month - date1.Month;
                        int daysDiff = date2.Day - date1.Day;

                        if (daysDiff < 0)
                        {
                            months--;
                            daysDiff += DateTime.DaysInMonth(date1.Year, date1.Month);
                        }

                        if (months < 0)
                        {
                            years--;
                            months += 12;
                        }

                        operationText = $"Разница между {date1:dd.MM.yyyy} и {date2:dd.MM.yyyy}: {years} лет, {months} месяцев, {daysDiff} дней";
                        Console.WriteLine($"Разница: {years} лет, {months} месяцев, {daysDiff} дней");
                        break;
                    case "9":
                    case "clear":
                        ClearHistory();
                        return;

                    default:
                        Console.WriteLine("Неверный выбор операции!");
                        return;
                }

                AddToHistory(operationText);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }

    class MainCalculator
    {
        static void Main(string[] args)
        {
            Console.Title = "Консольный калькулятор";

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();

                Console.WriteLine("=== ГЛАВНОЕ МЕНЮ КАЛЬКУЛЯТОРА ===\n");
                Console.WriteLine("Выберите режим работы:");
                Console.WriteLine("1. Обычный калькулятор");
                Console.WriteLine("2. Инженерный калькулятор");
                Console.WriteLine("3. Калькулятор дат");
                Console.WriteLine("4. Выйти из программы");
                Console.Write("\nВаш выбор: ");

                string choice = Console.ReadLine();

                ICalculator calculator = null;

                switch (choice)
                {
                    case "1":
                        calculator = new BasicCalculator();
                        break;
                    case "2":
                        calculator = new EngineeringCalculator();
                        break;
                    case "3":
                        calculator = new DateCalculator();
                        break;
                    case "4":
                        Console.WriteLine("Выход из программы...");
                        return;
                    default:
                        Console.WriteLine("Неверный выбор! Нажмите любую клавишу для продолжения...");
                        Console.ReadKey();
                        continue;
                }

                calculator.Run();
            }
        }
    }
}