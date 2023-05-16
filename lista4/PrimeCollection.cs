using System;
using System.Collections;

public class PrimeCollection : IEnumerable
{
    IEnumerator IEnumerable.GetEnumerator()
    { return new PrimeEnum(); }
    public PrimeEnum GetEnumerator()
    {
        return new PrimeEnum();
    }

}

public class PrimeEnum : IEnumerator
{
    public int Current { get; private set; } = 1;
    object IEnumerator.Current => Current;
    void next()
    {
        Current++;
        for (int i = 2; i * i <= Current; i++)
            if (Current % i == 0)
            {
                Current++;
                i = 2;
            }
    }
    public bool MoveNext()
    {
        next();
        if (Current < 0)
            return false;
        return true;
    }
    public void Reset()
    {
        Current = 1;
    }
}
class Program
{
    static void Main()
    {
        PrimeCollection pc = new PrimeCollection();
        foreach (int p in pc)
            Console.WriteLine(p);
    }
}
