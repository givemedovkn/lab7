internal class ListOperation
{
    public static List<int> GetIntersection(List<int> L1, List<int> L2)
    {
        List<int> L = new List<int>();

        for (int i = 0; i < L1.Count; i++)
        {
            int currentElement = L1[i];

            // 1. Проверяем, есть ли этот элемент во ВТОРОМ списке (L2)
            bool existsInL2 = false;
            for (int j = 0; j < L2.Count; j++)
            {
                if (L2[j] == currentElement)
                {
                    existsInL2 = true;
                    break;
                }
            }

            // 2. Если он есть в L2, нужно проверить, не добавили ли мы его уже в L
            // (так как по условию нужно включить "по одному разу")
            if (existsInL2)
            {
                bool alreadyInL = false;
                for (int k = 0; k < L.Count; k++)
                {
                    if (L[k] == currentElement)
                    {
                        alreadyInL = true;
                        break;
                    }
                }

                // Если в L его еще нет — добавляем!
                if (!alreadyInL)
                {
                    L.Add(currentElement);
                }
            }
        }

        return L;
    }
    public static void PrintList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }
    public static void PrintList(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }
    public static void DuplicateReverseLinked(LinkedList<int> L)
    {
        // Если список пустой, ничего не делаем
        if (L.Count == 0) return;

        // 1. Находим самый последний узел (ноду) исходного списка
        LinkedListNode<int> current = L.Last;

        // 2. Нам нужно запомнить, сколько элементов было изначально,
        // чтобы не уйти в бесконечный цикл.
        int count = L.Count;

        // 3. Проходим по списку ровно столько раз, сколько в нем было элементов
        for (int i = 0; i < count; i++)
        {
            // Добавляем значение текущего узла в самый конец списка
            L.AddLast(current.Value);

            // Переходим к ПРЕДЫДУЩЕМУ узлу
            current = current.Previous;
        }
    }
    // 1. ТРЦ, в которые ходили ВСЕ (Пересечение)
    public static HashSet<string> GetMallsVisitedByAll(HashSet<string> allMalls, List<HashSet<string>> studentVisits)
    {
        HashSet<string> result = new HashSet<string>();

        // Если студентов нет, то и результата нет
        if (studentVisits.Count == 0) return result;

        // Сначала допустим, что все ТРЦ из перечня подходят
        foreach (string mall in allMalls)
        {
            bool visitedByEveryone = true;
            foreach (HashSet<string> studentList in studentVisits)
            {
                // HashSet.Contains работает молниеносно!
                if (!studentList.Contains(mall))
                {
                    visitedByEveryone = false;
                    break;
                }
            }

            if (visitedByEveryone) result.Add(mall);
        }
        return result;
    }

    // 2. ТРЦ, в которые ходили НЕКОТОРЫЕ (Объединение тех, кто в списке города)
    public static HashSet<string> GetMallsVisitedBySome(HashSet<string> allMalls, List<HashSet<string>> studentVisits)
    {
        HashSet<string> result = new HashSet<string>();

        foreach (string mall in allMalls)
        {
            foreach (HashSet<string> studentList in studentVisits)
            {
                if (studentList.Contains(mall))
                {
                    result.Add(mall);
                    break; // Достаточно одного студента
                }
            }
        }
        return result;
    }

    // 3. ТРЦ, в которые НЕ ходил НИКТО (Разность)
    public static HashSet<string> GetMallsVisitedByNone(HashSet<string> allMalls, List<HashSet<string>> studentVisits)
    {
        HashSet<string> result = new HashSet<string>();

        foreach (string mall in allMalls)
        {
            bool visitedByAnyone = false;
            foreach (HashSet<string> studentList in studentVisits)
            {
                if (studentList.Contains(mall))
                {
                    visitedByAnyone = true;
                    break;
                }
            }

            if (!visitedByAnyone) result.Add(mall);
        }
        return result;
    }
    public static int CountUniqueLettersHashSet(string filePath)
    {
        // Читаем весь текст из файла
        string text = File.ReadAllText(filePath);

        // Создаем HashSet для хранения уникальных символов
        HashSet<char> uniqueLetters = new HashSet<char>();

        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];

            // Проверяем, что это русская буква (кириллица)
            if ((ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё')
            {
                // Добавляем букву в нижнем регистре. 
                // HashSet сам проигнорирует её, если она там уже есть.
                uniqueLetters.Add(char.ToLower(ch));
            }
        }

        // Количество элементов в HashSet и есть число разных букв
        return uniqueLetters.Count;
    }
    public static void ProcessSportsmen(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        int n = int.Parse(lines[0]); // Число спортсменов
        int m = int.Parse(lines[1]); // Число видов спорта

        // Используем Dictionary: Ключ - Полное имя, Значение - Сумма баллов
        Dictionary<string, int> results = new Dictionary<string, int>();

        for (int i = 2; i < 2 + n; i++)
        {
            string[] parts = lines[i].Split(' ');
            string fullName = parts[0] + " " + parts[1];

            int sum = 0;
            // Суммируем баллы (начинаются с 2-го индекса в строке)
            for (int j = 2; j < 2 + m; j++)
            {
                sum += int.Parse(parts[j]);
            }

            results.Add(fullName, sum);
        }

        // Чтобы отсортировать Dictionary по убыванию баллов, 
        // создаем список из его элементов
        List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>();
        foreach (var entry in results)
        {
            sortedList.Add(entry);
        }

        // Сортировка методом пузырька (чтобы точно без LINQ!)
        for (int i = 0; i < sortedList.Count - 1; i++)
        {
            for (int j = 0; j < sortedList.Count - i - 1; j++)
            {
                if (sortedList[j].Value < sortedList[j + 1].Value)
                {
                    var temp = sortedList[j];
                    sortedList[j] = sortedList[j + 1];
                    sortedList[j + 1] = temp;
                }
            }
        }

        // Вывод с учетом мест
        Console.WriteLine("\nИтоговая таблица:");
        int currentPlace = 1;
        for (int i = 0; i < sortedList.Count; i++)
        {
            // Логика мест: если баллы равны предыдущему, место то же самое
            if (i > 0 && sortedList[i].Value < sortedList[i - 1].Value)
            {
                currentPlace = i + 1;
            }

            Console.WriteLine($"{sortedList[i].Key} {sortedList[i].Value} {currentPlace}");
        }
    }
}
