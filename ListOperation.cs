internal class ListOperation
{
    public static List<T> GetIntersection<T>(List<T> L1, List<T> L2)
    {
        List<T> L = new List<T>();

        for (int i = 0; i < L1.Count; i++)
        {
            T currentElement = L1[i];
            bool hasInL2 = false;
            for (int j = 0; j < L2.Count; j++)
            {
                if (L2[j].Equals(currentElement))
                {
                    hasInL2 = true;
                    break;
                }
            }
            if (hasInL2)
            {
                bool alreadyInL = false;
                for (int k = 0; k < L.Count; k++)
                {
                    if (L[k].Equals(currentElement))
                    {
                        alreadyInL = true;
                        break;
                    }
                }
                if (!alreadyInL)
                {
                    L.Add(currentElement);
                }
            }
        }
        return L;
    }
    public static void PrintList<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Console.Write(list[i] + " ");
        }
        Console.WriteLine();
    }

    public static void DuplicateReverseLinked<T>(LinkedList<T> L)
    {
        if (L.Count == 0)
        {
            return;
        }
        LinkedListNode<T> currentElement = L.Last;
        int count = L.Count;

        for (int i = 0; i < count; i++)
        {
            L.AddLast(currentElement.Value);
            currentElement = currentElement.Previous;
        }
    }
    
    public static HashSet<string> MallsVisitAll(
        HashSet<string> allMalls, 
        List<HashSet<string>> studentVisits
        )
    {
        HashSet<string> result = new HashSet<string>();
        if (studentVisits.Count == 0)
        {
            return result;
        }
        
        foreach (string mall in allMalls)
        {
            bool visitEveryone = true;
            foreach (HashSet<string> studentList in studentVisits)
            {
                if (!studentList.Contains(mall))
                {
                    visitEveryone = false;
                    break;
                }
            }

            if (visitEveryone)
            {
                result.Add(mall);
            }
        }
        return result;
    }
    public static HashSet<string> MallsVisitSome(
        HashSet<string> allMalls, 
        List<HashSet<string>> studentVisits
        )
    {
        HashSet<string> result = new HashSet<string>();

        foreach (string mall in allMalls)
        {
            foreach (HashSet<string> studentList in studentVisits)
            {
                if (studentList.Contains(mall))
                {
                    result.Add(mall);
                    break;
                }
            }
        }
        return result;
    }
    public static HashSet<string> MallsVisitNone(
        HashSet<string> allMalls, 
        List<HashSet<string>> studentVisits
        )
    {
        HashSet<string> result = new HashSet<string>();

        foreach (string mall in allMalls)
        {
            bool visitAnyone = false;
            foreach (HashSet<string> studentList in studentVisits)
            {
                if (studentList.Contains(mall))
                {
                    visitAnyone = true;
                    break;
                }
            }

            if (!visitAnyone)
            {
                result.Add(mall);
            }
        }
        return result;
    }

    public static int CountUniqueLettersHashSet(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return 0;   
        }
        string text = File.ReadAllText(filePath);

        HashSet<char> uniqueLetters = new HashSet<char>();
        for (int i = 0; i < text.Length; i++)
        {
            char ch = text[i];
            if ((ch >= 'а' && ch <= 'я') || (ch >= 'А' && ch <= 'Я') || ch == 'ё' || ch == 'Ё')
            {
                uniqueLetters.Add(char.ToLower(ch));
            }
        }
        return uniqueLetters.Count;
    }

    public static void SportsmenResults(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        int n = int.Parse(lines[0]);
        int m = int.Parse(lines[1]);

        Dictionary<string, int> results = new Dictionary<string, int>();

        for (int i = 2; i < 2 + n; i++)
        {
            string[] parts = lines[i].Split(' ');
            string fullName = parts[0] + " " + parts[1];

            int sum = 0;
            for (int j = 2; j < 2 + m; j++)
            {
                sum += int.Parse(parts[j]);
            }

            results.Add(fullName, sum);
        }

        List<KeyValuePair<string, int>> sortedList = new List<KeyValuePair<string, int>>();
        foreach (var entry in results)
        {
            sortedList.Add(entry);
        }

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

        Console.WriteLine("\nИтоговая таблица:");
        int currentPlace = 1;
        for (int i = 0; i < sortedList.Count; i++)
        {
            if (i > 0 && sortedList[i].Value < sortedList[i - 1].Value)
            {
                currentPlace = i + 1;
            }
            Console.WriteLine($"{sortedList[i].Key} {sortedList[i].Value} {currentPlace}");
        }
    }
}
