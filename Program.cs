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
                    Console.WriteLine("Путь к файлу: " +  filePath);
                    Console.Write("Введите количество чисел в файле: ");
                    int count = CheckType.Integer();
                    FileOperation.FillRandNumOneStr(count, filePath);
                    double average = FileOperation.AverageMinMax(filePath);
                    Console.WriteLine("Среднее арифметическое = " + average);

                    break;
                }
            case 2:
                {
                    string filePath = "C:\\Users\\Пользователь\\Desktop\\lab7\\f2.txt";
                    Console.WriteLine("Путь к файлу: " + filePath);
                    Console.Write("Введите количество строк в файле: ");
                    int count = CheckType.Integer();
                    FileOperation.FillRandNumSevStr(count, filePath);
                    long mul = FileOperation.MulEvenNum(filePath);
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
                    Console.Write("Введите количество игрушек: ");
                    int count = CheckType.Integer();
                    string name = "toy";
                    double price = 0.0;
                    int minAge = 0;
                    int maxAge = 0;
                    while (count != 0)
                    {
                        Console.Write("Введите название игрушки: ");
                        name = Console.ReadLine();
                        Console.Write("Введите стоимость игрушки: ");
                        price = CheckType.Double();
                        Console.Write("Введите минимальный возраст для игрушки: ");
                        minAge = CheckType.Integer();
                        Console.Write("Введите максимальный возраст для игрушки: ");
                        maxAge = CheckType.Integer();
                        toys.Add(new Toy(name, price, minAge, maxAge));
                        count--;
                    }
                    for (int i = 0; i < toys.Count; i++)
                    {
                        Console.WriteLine(toys[i].ToString());
                    }
                    FileOperation.FillToysXml(file, toys);
                    Console.WriteLine("Файл с игрушками успешно создан и заполнен.");
                    string expensiveToy = FileOperation.ExpensiveToy(file);
                    Console.WriteLine("Самая дорогая игрушка для детей до 4 лет: " + expensiveToy);

                    break;
                }
            case 6:
                {
                    Console.Write("Введите количество элементов в 1 списке: ");
                    int count = CheckType.Integer();
                    int num = 0;
                    List<int> L1 = new List<int>();
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write("Введите значение элемента: ");
                        num = CheckType.Integer();
                        L1.Add(num);
                    }

                    Console.Write("Введите количество элементов во 2 списке: ");
                    count = CheckType.Integer();
                    List<int> L2 = new List<int>();
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write("Введите значение элемента: ");
                        num = CheckType.Integer();
                        L2.Add(num);
                    }

                    Console.WriteLine("Первый список: ");
                    ListOperation.PrintList(L1);
                    Console.WriteLine("Второй список: ");
                    ListOperation.PrintList(L2);

                    List<int> L = ListOperation.GetIntersection(L1, L2);
                    Console.WriteLine("Результирующий список: ");
                    ListOperation.PrintList(L);

                    break;
                }
            case 7:
                {
                    Console.Write("Введите количество элементов в списке: ");
                    int count = CheckType.Integer();
                    int num = 0;
                    LinkedList<int> L = new LinkedList<int>();
                    for (int i = 0; i < count; i++)
                    {
                        Console.Write("Введите значение элемента: ");
                        num = CheckType.Integer();
                        L.AddLast(num);
                    }

                    Console.WriteLine("Исходный список: ");
                    foreach (int x in L)
                    {
                        Console.Write(x + " ");
                    }
                    Console.WriteLine();

                    ListOperation.DuplicateReverseLinked(L);

                    Console.WriteLine("Результат: ");
                    foreach (int x in L)
                    {
                        Console.Write(x + " ");
                    }
                    Console.WriteLine();

                    break;
                }
            case 8:
                {
                    HashSet<string> allMalls = new HashSet<string>();
                    Console.Write("Сколько всего ТРЦ: ");
                    int count = CheckType.Integer();
                    string name = "Планета";
                    while (count != 0)
                    {
                        Console.Write("Введите название ТРЦ: ");
                        name = Console.ReadLine();
                        allMalls.Add(name);
                        count--;
                    }
                    Console.WriteLine("Все ТРЦ: " + string.Join(", ", allMalls));

                    List<HashSet<string>> studentVisits = new List<HashSet<string>>();
                    Console.Write("Сколько всего студентов: ");
                    count = CheckType.Integer();
                    int countPlaces = 0;
                    for (int j = 1; j <= count; j++)
                    {
                        HashSet<string> stud = new HashSet<string> ();
                        Console.Write($"Сколько ТРЦ посетил студент{j}: ");
                        countPlaces = CheckType.Integer();
                        for (int i = 0; i < countPlaces; i++)
                        {
                            Console.Write($"Введите название ТРЦ, которое посетил студент{j}: ");
                            name = Console.ReadLine();
                            stud.Add(name);
                        }
                        studentVisits.Add(stud);
                    }

                    HashSet<string> all = ListOperation.MallsVisitAll(allMalls, studentVisits);
                    HashSet<string> some = ListOperation.MallsVisitSome(allMalls, studentVisits);
                    HashSet<string> none = ListOperation.MallsVisitNone(allMalls, studentVisits);

                    Console.WriteLine("Ходили все: " + string.Join(", ", all));
                    Console.WriteLine("Ходили некоторые: " + string.Join(", ", some));
                    Console.WriteLine("Никто не ходил: " + string.Join(", ", none));

                    break;
                }
            case 9:
                {
                    string file = "C:\\Users\\Пользователь\\Desktop\\lab7\\text.txt";
                    Console.WriteLine("Путь к файлу: " + file);
                    int count = ListOperation.CountUniqueLettersHashSet(file);
                    Console.WriteLine("Текст из файла: " + 
                        File.ReadAllText(file));
                    Console.WriteLine("Количество уникальных русских букв: " 
                        + count);
                    
                    break;
                }
            case 10:
                {
                    string file = "C:\\Users\\Пользователь\\Desktop\\lab7\\f10.txt";
                    ListOperation.SportsmenResults(file);

                    break;
                }
        }
    }
}
