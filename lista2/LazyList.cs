using System;

class LazyIntList
{
    protected List<int> list = new List<int>();
    protected int length = 0;
    Random rnd = new Random();
    void next()
    {
        length++;
        list.Add(rnd.Next(Int32.MinValue, Int32.MaxValue));
    }
    public int element(int i)
    {
        while (i > length - 1)
            next();
        return list[i];
    }
    public int size()
    {
        return length;
    }
}

class LazyPrimeList : LazyIntList
{
    
    bool is_prime(int number)
    {
        if (number == 0 || number == 1)
            return false;
        for (int i = 2; i * i <= number; i++)
            if (number % i == 0)
                return false;
        return true;
    }
    void next()
    {
        if(length == 0)
            list.Add(2);
        else
        {
            int Next = list[length - 1] + 1;
            while (is_prime(Next) == false)
                Next++;
            list.Add(Next);
        }
        length++;
    }
    public new int element(int i)
    {
        while (i > length - 1)
            next();
        return list[i];
    }
}

class Program
{
    static void Main(string[] args)
    {
        LazyIntList lista = new LazyIntList();
        Console.WriteLine(lista.size());
        Console.WriteLine(lista.element(40));
        Console.WriteLine(lista.size());
        Console.WriteLine(lista.element(38));
        Console.WriteLine(lista.element(38));
        Console.WriteLine(lista.size());
        LazyPrimeList plista = new LazyPrimeList();
        for (int i = 0; i <12; i++)
              Console.WriteLine(plista.element(i));
        Console.WriteLine(plista.size());
    }
}
