using System.Diagnostics;
using System.Formats.Tar;
using Task2;

namespace Task1
{
    internal class Program
    {
        static void Calculator_GotResult(object sender, EventArgs e)
        {
            Console.WriteLine($"Результат: {((Calculator)sender).Args.Result}\n");
        }

        static bool MyReadLine(out string input)
        {
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Escape)
            {
                // Присваиваем в input любой символ так как
                // в противном случае один символ в финальном сообщении
                // будет съеден
                input = "x";
                return false;
            }
            input = key.KeyChar + Console.ReadLine();
            return true;
        }

        static void GreetingsInfo() 
        {
            Console.WriteLine("Добро пожаловать в приложение Простой Калькулятор!\n");
            Console.WriteLine("Правила использования калькулятора:\n");
            Console.WriteLine("\t1. Вводите 2 числа, после чего нажмите Enter\n");
            Console.WriteLine("\t2. Введите операцию, которую хотите совершить (+, -, *, /) и нажмите Enter\n");
            Console.WriteLine("\t3. Для выхода из приложения нажмите Escape\n");
        }

        static void Main(string[] args)
        {
            var calc = new Calculator();
            string input;
            bool isExit = false;

            calc.GotResult += Calculator_GotResult!;

            GreetingsInfo();            

            while (true)
            {                
                Console.WriteLine("Введите два числа через пробел:");           
                if (!MyReadLine(out input)) break;

                if (input != null)
                {
                    int firstNum, secondNum;

                    if(input.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length == 2)
                    {
                        var numbers = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        if (int.TryParse(numbers[0], out firstNum) && int.TryParse(numbers[1], out secondNum))
                        {
                            while (!isExit)
                            {
                                Console.WriteLine("Введите операцию: +, -, *, /");
                                if (!MyReadLine(out input)) break;
                                string operation = input;

                                if ("+-*/".Contains(operation))
                                {
                                    isExit = true;

                                    switch (operation)
                                    {
                                        case "+":
                                            calc.Add(firstNum, secondNum);
                                            break;
                                        case "-":
                                            calc.Subtract(firstNum, secondNum);
                                            break;
                                        case "*":
                                            calc.Multiply(firstNum, secondNum);
                                            break;
                                        case "/":
                                            calc.Divide(firstNum, secondNum);
                                            break;
                                    }
                                }
                                else Console.WriteLine("Неверный формат ввода");
                            }
                            isExit = false;
                        }
                        else Console.WriteLine("Неверный формат ввода");
                    }
                    else Console.WriteLine("Неверный формат ввода чисел");
                }
            }
            Console.WriteLine(input + "Спасибо, что воспользовались приложением!");
        }
    }
}
