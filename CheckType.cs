internal class CheckType
{
    public static int Integer()
    {
        bool f = int.TryParse(Console.ReadLine(), out int num);
        while (!f)
        {
            Console.Write("Неверный формат! Повторите попытку: ");
            f = int.TryParse(Console.ReadLine(), out num);
        }
        return num;
    }
}
