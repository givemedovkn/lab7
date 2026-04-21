using System.Xml.Serialization;
internal class FileOperation
{
    public static void FillRandNumOneStr(int count, string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return;
        }
        Random rnd = new Random();
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < count; i++)
            {
                writer.WriteLine(rnd.Next(-1000, 1001));
            }
        }
    }
    public static double AverageMinMax(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return 0;
        }
        var numbers = File.ReadLines(filePath).Select(int.Parse).ToList();
        if (numbers.Count == 0)
        {
            return 0;
        }
        else
        {
            return (numbers.Min() + numbers.Max()) / 2.0;
        }
    }
    public static void FillRandNumSevStr(int countStr, string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return;
        }
        Random rnd = new Random();
        int countNum = 0;
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            for (int i = 0; i < countStr; i++)
            {
                countNum = rnd.Next(1, 6);
                for (int j = 0; j < countNum; j++)
                {
                    writer.Write(rnd.Next(-20, 21) + " ");
                }
                writer.WriteLine();
            }
        }
    }
    public static long MulEvenNum(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return 0;
        }

        long mult = 1;
        bool hasEven = false;

        string[] lines = File.ReadAllLines(filePath);

        foreach (string line in lines)
        {
            string[] parts = line.Split(' ');
            foreach (string part in parts)
            {
                if (int.TryParse(part, out int num))
                {
                    if (num % 2 == 0 && num != 0)
                    {
                        mult *= num;
                        hasEven = true;
                    }
                }
            }
        }

        return hasEven ? mult : 0;
    }
    public static void CopyWithoutLatin(string file, string copyFile)
    {
        if (!File.Exists(file)) 
        {
            Console.WriteLine("Файл не найден");
            return; 
        }
        string[] lines = File.ReadAllLines(file);
        bool hasLatin = false;
        using (StreamWriter writer = new StreamWriter(copyFile))
        {
            foreach (string line in lines)
            {
                hasLatin = false;
                foreach (char ch in line)
                {
                    if ((ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z'))
                    {
                        hasLatin = true;
                        break;
                    }
                }
                if (!hasLatin)
                {
                    writer.WriteLine(line);
                }
            }
        }
    }
    public static void FillBinFile(int count, string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return;
        }
        Random rnd = new Random();
        using (BinaryWriter writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
        {
            for (int i = 0; i < count; i++)
            {
                writer.Write(rnd.Next(1, 101));
            }
        }
    }
    public static int CountSquarOdd(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return 0;
        } 
        int count = 0;
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                int num = reader.ReadInt32();
                if (IsSquarOdd(num))
                {
                    count++;
                }
            }
        }
        return count;
    }
    private static bool IsSquarOdd(int n)
    {
        if (n < 0)
        {
            return false;
        }
        int root = (int)Math.Sqrt(n);
        return (root * root == n) && (root % 2 != 0);
    }
    public static void PrintBinFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return;
        }
        int num = 0;
        using (BinaryReader reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
        {
            while (reader.BaseStream.Position < reader.BaseStream.Length)
            {
                num = reader.ReadInt32();
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }
    }
    public static void FillToysXml(string filePath, List<Toy> toys)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return;
        }
        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        using (FileStream fs = new FileStream(filePath, FileMode.Create))
        {
            serializer.Serialize(fs, toys);
        }
    }
    public static string ExpensiveToy(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Файл не найден");
            return "";
        }
        XmlSerializer serializer = new XmlSerializer(typeof(List<Toy>));
        List<Toy> toysList;

        using (FileStream fs = new FileStream(filePath, FileMode.Open))
        {
            toysList = (List<Toy>)serializer.Deserialize(fs);
        }

        string expensiveName = "Не найдено";
        double maxPrice = -1.0;

        for (int i = 0; i < toysList.Count; i++)
        {
            Toy currentToy = toysList[i];

            if (currentToy.MaxAge <= 4)
            {
                if (currentToy.Price > maxPrice)
                {
                    maxPrice = currentToy.Price;
                    expensiveName = currentToy.Name;
                }
            }
        }

        return expensiveName;
    }
}
