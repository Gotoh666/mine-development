using MineDevLibrary;
using MineDevLibrary.Algorithms;
using System;
Console.WriteLine("Start");

YieldExample.UseForeach();


var tree = new BinaryTree();
foreach (var item in tree.ToEnumerable())
{
    Console.WriteLine(item);
}

Console.WriteLine("The end");
Console.ReadLine();


public class A 
{

}

public class B : A { }