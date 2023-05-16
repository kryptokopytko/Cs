class IntStream
{
    protected int number = 0;
    public int next()
    {
        number++;
        if (eos() == false)
             return number;
        return -1;
    }
    public bool eos()
    {
        if (number > Int32.MaxValue)
            return true;
        return false;
    }
    public void reset()
    {
        number = 0;
    }
}

class PrimeStream : IntStream
{
    bool is_prime()
    {
        if (number == 0 || number == 1)
            return false;
        for (int i = 2; i * i <= number; i++)
            if (number % i == 0)
                return false;
        return true;
    }
    public new int next()
    {
        base.next();
        if (is_prime())
            return number;
        return next();
    }
}

class RandomStream : IntStream
{
    Random rnd = new Random();
    public new bool eos()  { return false; }
    public new int next()
    {
        number = rnd.Next(Int32.MinValue, Int32.MaxValue);
        return number;
    }
    
        
}

class RandomWordStream
{
    string word = "";
    public string get_word() { return word; }
    public void set_word(string name) { word = name; }
    PrimeStream ps = new PrimeStream();
    int length = 2;
    public string next()
    {
        length = ps.next();
        RandomStream rs = new RandomStream();
        string new_word = "";
        for (int i = 0; i < length; i++)
        {
            new_word += (char)((rs.next() % ((char)'z' - (char)'a')) + (char)'a');
        }
        set_word(new_word);
        return get_word();
    }
}

class Program
{
    static void Main(string[] args)
    {
        IntStream s = new IntStream();
        int liczba = s.next();
        for (int i = 0; i < 23; i++)
            liczba = s.next();
        Console.WriteLine("Liczba nr24 z IntStream: ");
        Console.WriteLine(liczba);
        Console.WriteLine("Liczby od 0 do 19 z PrimeStream: ");
        PrimeStream ps = new PrimeStream();
        for (int i = 0; i < 20; i++)
        {
            liczba = ps.next();
            Console.WriteLine(liczba);
        }
        RandomStream rs = new RandomStream();
        Console.WriteLine("Losowe liczby z RandomStream: ");
        for (int i = 0; i < 10; i++)
        {
            liczba = rs.next();
            Console.WriteLine(liczba);
        }
        Console.WriteLine("Losowe slowa: ");
        RandomWordStream rws = new RandomWordStream();
        for (int i = 0; i < 10; i++)
            Console.WriteLine(rws.next());
    }
}