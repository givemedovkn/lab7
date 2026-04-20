using System.Net.NetworkInformation;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Введите номер задания(1-10): ");
        int task = CheckType.Integer();
        switch (task)
        {
            case 1:
            {
                string filePath = "C:\\Users\\Пользователь\\Desktop\\lab7\\f1.txt";
                Console.Write("Введите количество чисел в файле: ");
                int count = CheckType.Integer();
                FileOperation.FillRandNumOneStr(count, filePath);
                double average = FileOperation.AverageMinMax(filePath);
                Console.WriteLine("Файл f1 заполнен случайными целыми числами");
                Console.WriteLine("Среднее арифметическое = " + average);
                break;
            }
            case 2:
            {
                string filePath = "C:\\Users\\Пользователь\\Desktop\\lab7\\f2.txt";
                Console.Write("Введите количество строк в файле: ");
                int count = CheckType.Integer();
                FileOperation.FillRandNumSevStr(count, filePath);
                long mul = FileOperation.MulEvenNum(filePath);
                Console.WriteLine("Файл f2 заполнен случайными целыми числами");
                Console.WriteLine("Произведение всех четных элементов = " + mul);
                break;
            }
            case 3:
            {
                string file = "C:\\Users\\Пользователь\\Desktop\\lab7\\f3.txt";
                string copyFile = "C:\\Users\\Пользователь\\Desktop\\lab7\\f3 copy.txt";
                FileOperation.CopyWithoutLatin(file, copyFile);
                Console.WriteLine("Строки без латинских букв из файла f3 скопированы в файл copy f3");
                break;
            }
            case 4:
            {
                string file = "C:\\Users\\Пользователь\\Desktop\\lab7\\f4.bin";
                Console.Write("Введите количество чисел в файле: ");
                int count = CheckType.Integer();
                FileOperation.FillBinFile(count, file);
                Console.WriteLine("Содержимое файла: ");
                FileOperation.PrintBinFile(file);
                Console.WriteLine("Количество квадратов нечетных чисел = " + FileOperation.CountSquarOdd(file));
                break;
            }
            case 5:
            {
                string file = "C:\\Users\\Пользователь\\Desktop\\lab7\\toys.xml";
                List<Toy> toys = new List<Toy>();
                toys.Add(new Toy("Мяч", 800.50, 1, 4));
                toys.Add(new Toy("Кубики", 500.00, 1, 3));
                toys.Add(new Toy("Машинка", 1500.00, 2, 5));
                FileOperation.FillToysXml(file, toys);
                Console.WriteLine("Файл с игрушками успешно создан и заполнен.");
                string expensiveToy = FileOperation.GetExpensiveToyForToddlers(file);
                Console.WriteLine("Самая дорогая игрушка для детей до 4 лет: " + expensiveToy);
                break;
            }
            case 6:
            {
                // Создаем два списка для примера (L1 и L2)
                List<int> L1 = new List<int>();
                L1.Add(1); L1.Add(2); L1.Add(3); L1.Add(2); L1.Add(5); // Двойка повторяется

                List<int> L2 = new List<int>();
                L2.Add(2); L2.Add(5); L2.Add(8); L2.Add(10);

                    
                Console.WriteLine("Первый список: ");
                ListOperation.PrintList(L1);
                Console.WriteLine("Второй список: ");
                ListOperation.PrintList(L2);

                List<int> L = ListOperation.GetIntersection(L1, L2);

                    // Печатаем результат
                    Console.WriteLine("Результирующий список: ");
                    ListOperation.PrintList(L);

                break;
            }
            case 7:
                {
                    // Создаем связный список
                    LinkedList<int> L = new LinkedList<int>();
                    L.AddLast(1);
                    L.AddLast(2);
                    L.AddLast(3);

                    Console.WriteLine("Исходный LinkedList:");
                    foreach (int x in L) Console.Write(x + " ");
                    Console.WriteLine();

                    // Вызываем откат-задание
                    ListOperation.DuplicateReverseLinked(L);

                    Console.WriteLine("Результат (1 2 3 3 2 1):");
                    foreach (int x in L) Console.Write(x + " ");
                    Console.WriteLine();

                    break;
                }
            case 8: // Задача про ТРЦ
                {
                    // Общий перечень ТРЦ (теперь это HashSet)
                    HashSet<string> allMalls = new HashSet<string> { "Гринвич", "Пассаж", "Мега", "Алатырь", "Карнавал" };

                    // Список посещений студентов (каждый студент - тоже HashSet)
                    List<HashSet<string>> studentVisits = new List<HashSet<string>>();

                    HashSet<string> s1 = new HashSet<string> { "Гринвич", "Мега" };
                    HashSet<string> s2 = new HashSet<string> { "Гринвич", "Пассаж", "Алатырь" };

                    studentVisits.Add(s1);
                    studentVisits.Add(s2);

                    // Вычисляем
                    HashSet<string> all = ListOperation.GetMallsVisitedByAll(allMalls, studentVisits);
                    HashSet<string> some = ListOperation.GetMallsVisitedBySome(allMalls, studentVisits);
                    HashSet<string> none = ListOperation.GetMallsVisitedByNone(allMalls, studentVisits);

                    // Вывод (HashSet тоже можно перебирать через foreach)
                    Console.WriteLine("Ходили все: " + string.Join(", ", all));
                    Console.WriteLine("Ходили некоторые: " + string.Join(", ", some));
                    Console.WriteLine("Никто не ходил: " + string.Join(", ", none));
                    break;
                }
            case 9:
                {
                    string file = "C:\\Users\\Пользователь\\source\\repos\\lab7\\lab7\\text.txt";

                    if (File.Exists(file))
                    {
                        int count = ListOperation.CountUniqueLettersHashSet(file);
                        Console.WriteLine("Текст из файла: " + File.ReadAllText(file));
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Количество уникальных русских букв (через HashSet): " + count);
                    }
                    else
                    {
                        Console.WriteLine("Файл не найден!");
                    }
                    break;
                }
            case 10:
                {
                    string path = "sports.txt"; // Путь к файлу
                    ListOperation.ProcessSportsmen(path);
                    break;
                }
        }
    }
}