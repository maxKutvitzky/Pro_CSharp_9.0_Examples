using System;

Console.WriteLine(AddWrapperWithSideEffect(1, 1)); 


static int Add(int x, int y)
{
    //Do some validation here
    return x + y;
}

static int AddWrapper(int x, int y)
{
    //Do some validation here
    return Add();
    int Add()
    {
        return x + y;
    }
}

static int AddWrapperWithSideEffect(int x, int y)
{
    //Do some validation here
    return Add(); 
    int Add()
    {
        x += 1;
        return x + y;
    }
}

static int AddWrapperWithStatic(int x, int y)
{
    //Do some validation here
    return Add(x, y);
    static int Add(int x, int y)
    {
        return x + y;
    }
}