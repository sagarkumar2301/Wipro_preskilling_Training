//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//steps for creating a file handling in c#
//step 1: import the system.io namespace
using System.IO;

//step 2: create a file
string filePath = "example.txt";
string copypath = "copy_example.txt";

try
{
   
    //create a file and write some text to it
    File.WriteAllText(filePath, "This is an example of file handling in C#.");
    //step 3: read the file
    string content = File.ReadAllText(filePath);
    Console.WriteLine("File Content: " + content);
    //step 4: copy the file
    File.Copy(filePath, copypath);
    Console.WriteLine("File copied successfully.");
    //step 5: delete the original file
    File.Delete(filePath);
    Console.WriteLine("Original file deleted.");

}
catch (Exception ex)
{
    Console.WriteLine("An error occurred: " + ex.Message);
}