using MineDevLibrary;
using System;
Console.WriteLine("Start");

B a = (B)(new A());

Delegates.SimpleDelegateUse();

Console.WriteLine("The end");
Console.ReadLine();


public class A 
{

}

public class B : A { }