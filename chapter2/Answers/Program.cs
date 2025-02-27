TryAnIf();
TrySomeLoops();
TryAnIfElse();

static void TryAnIf()
{
    int someValue = 4;
    string name = "Bobbo Jr.";
    if ((someValue==3) && (name =="Joe"))
    {
        Console.WriteLine("This");
    }
    Console.WriteLine("Other");
}

static void TryAnIfElse()
{
    int x = 5;
    if (x==10)
    {
        Console.WriteLine("x must be 10");
    }
    else 
    {
        Console.WriteLine("it is not 10");
    }
}

static void TrySomeLoops()
{
    int count = 0;
    while (count < 10 )
    {
        count = count +1;
    }

    for (int i = 0; i <5; i++)
    {
        count = count -1;
    }
    Console.WriteLine("The Answer is..." + count);
}