using System;
using System.Globalization;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

WorkWithDirectories();

static void WorkWithDirectories() {
    // define a directory path for a new folder
    string newFolder = Combine(GetFolderPath(SpecialFolder.Desktop), "MyNewFolder");
    Console.WriteLine("Working with: {newFolder}");
    Console.WriteLine($"Does it exist? {Directory.Exists(newFolder)}");

    //Create a directory

    Console.WriteLine("Creating the folder...");
    CreateDirectory(newFolder);
    Console.WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
    Console.WriteLine("Confirm the directory exist, and then press ENTER:");
    Console.ReadLine();

    //Delete directory

    Console.WriteLine("Deleteing the folder...");
    Delete(newFolder, recursive: true);
    Console.WriteLine($"Does it exist? {Directory.Exists(newFolder)}");
}