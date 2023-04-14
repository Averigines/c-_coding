using System;
using System.Globalization;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

class Program {

    static string[] callsigns = new string[] {
        "ABC", "TEST", "BCC", "BMT"
    };

    static void Main(string[] args) {
        WorkWithText();
    }

    static void WorkWithText() {
        string textFile = Combine(CurrentDirectory, "streams.txt");

        //create a text file and return a helper writer
        StreamWriter text = File.CreateText(textFile);

        foreach (string item in callsigns) {
            text.WriteLine(item);
        }
        text.Close();

        //release the resource
    }
}