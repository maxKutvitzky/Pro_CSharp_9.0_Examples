using System;


string? nullableString = null;
TestClass? myNullableClass = null;
TestClass myNonNullableClass = myNullableClass;


public class TestClass
{
    public string Name { get; set; }
    public int Age { get; set; }
}