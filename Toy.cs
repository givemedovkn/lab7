[Serializable]
public struct Toy
{
    private string name;
    private double price;
    private int minAge;
    private int maxAge;

    public Toy(string name, double price, int minAge, int maxAge)
    {
        this.name = name;
        this.price = price;
        this.minAge = minAge;
        this.maxAge = maxAge;
    }
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }
    public double Price
    {
        get
        {
            return price;
        }
        set
        {
            price = value;
        }
    }
    public int MinAge
    {
        get
        {
            return minAge;
        }
        set
        {
            minAge = value;
        }
    }
    public int MaxAge
    {
        get
        {
            return maxAge;
        }
        set
        {
            maxAge = value;
        }
    }
    public override string ToString()
    {
        return "Игрушка " + name + ", цена = " + price
            + ", возраст от " + minAge + " до " + maxAge;

    }
}