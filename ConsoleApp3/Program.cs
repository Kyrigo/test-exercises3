namespace ConsoleApp3;

internal class Program
{
    public static void Main(string[] args)
    {
        try
        {
            int selection;
            do
            {
                Console.WriteLine("[1]Словарь из строки\n[2]Считаем числа с консоли до введения -1");
                selection = int.Parse(Console.ReadLine());
            } while (selection is < 0 or > 2);

            switch (selection)
            {
                case 1:
                    Console.WriteLine("Введите строку: ");
                    var word = Console.ReadLine();
                    var dictionary = word.GroupBy(ch => ch).ToDictionary(g => g.Key, g => g.Count());

                    foreach (KeyValuePair<char, int> kvp in dictionary)
                    {
                        Console.WriteLine("{0} - {1}", kvp.Key, kvp.Value);
                    }
                    break;
                case 2:
                    var listOfNums = new Dictionary<int, int>();
                    Console.WriteLine("Вводите числа через нажатие Enter. Когда закончите вводить нужные числа, введите -1, чтобы узнать какие из введенных чисел повторяются");
                    while (true)
                    {
                        var entryLine = Console.ReadLine();
                        if (entryLine == "-1")
                        {
                            break;
                        }
                        var number = Convert.ToInt32(entryLine);
                        if (listOfNums.TryGetValue(number, out var value))
                        {
                            listOfNums[number] = value + 1;
                        }
                        else listOfNums[number] = 1;
                    }
                    foreach (KeyValuePair<int, int> kvp in listOfNums)
                    {
                        if (kvp.Value != 1)
                        {
                            Console.WriteLine("Число {0} повторяется {1} раз(-а)", kvp.Key, kvp.Value);
                        }
                    }
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка в аргументах");
            switch (e)
            {
                case FormatException _:
                    Console.WriteLine("Format Exception - разрешен только ввод чисел");
                    break;
                case OverflowException _:
                    Console.WriteLine("Overflow Exception - число слишком большое");
                    break;
                case IndexOutOfRangeException _:
                    Console.WriteLine("OutofRange exception - выбранное число вне доступа");
                    break;
                default:
                    Console.WriteLine("Unknown error - " + e.Message);
                    break;
            }
        }
        finally
        {
            Console.Write("Press any key to exit");
            Console.ReadKey();
        }
    }
}
