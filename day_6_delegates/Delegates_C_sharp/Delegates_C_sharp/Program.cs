// See https://aka.ms/new-console-template for more information
using Delegates_C_sharp;
using static Delegates_C_sharp.DelegatesDemo;


Console.WriteLine("Welcome to C_sharp Delegate!");

//Creating an instance of the "MathOperation" delegate and assigning it the "Add" method.
MathOperation operation = DelegatesDemo.Add;
Console.WriteLine("Delegate ref is created and currently it is pointing to Add()");
//invoking the delegate with two integers and displaying the result.
int result = operation(10, 5);
Console.WriteLine("Since Delegate is pointing to Add() so the result of Addition is " + result);

//Changing the delegate assignment to the "Subtract" method and invoking it again with the same integers, displaying the result.
operation = DelegatesDemo.Subtract;
Console.WriteLine("Now the delegate ref is changed and currently it is pointing to Subtract()");
result = operation(10, 5);
Console.WriteLine("Since Delegate is pointing to Subtract() so the result of Subtraction is " + result);

operation = DelegatesDemo.Multiply;
Console.WriteLine("Now the delegate ref is changed and currently it is pointing to Multiply()");
result = operation(10, 5);
Console.WriteLine("Since Delegate is pointing to Multiply() so the result of Multiplication is " +result);
