using System;
using System.Globalization;
using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Xml;
using System.Xml.Serialization;

class Program {

    static string[] callsigns = new string[] {
        "ABC", "TEST", "BCC", "BMT"
    };

    static void Main(string[] args) {
        //WorkWithText();

        List<Person> people = new List<Person> {
            new Person("Yun", 1),
            new Person("Antoine", -23),
            new Person("Alica", 9999)
        };

        //create object that formats a list of Person as XML
        XmlSerializer xs = new XmlSerializer(typeof(List<Person>));

        string path = Combine(CurrentDirectory, "people.xml");

        using (FileStream stream = File.Create(path)) {
            //Serialize the object graph to the stream
            xs.Serialize(stream, people);
        }
    }

    static void WorkWithText() {
        string textFile = Combine(CurrentDirectory, "streams.txt");

        //create a text file and return a helper writer
        StreamWriter text = File.CreateText(textFile);

        foreach (string item in callsigns) {
            text.WriteLine(item);
        }
        //release the resource
        text.Close();

        Console.WriteLine("{0} contains {1:N0} bytes.", arg0: textFile, arg1: new FileInfo(textFile).Length);
        Console.WriteLine(File.ReadAllText(textFile));
    }

    static void WorkWithXml() {
        //define a file to write to
        string xmlFile = Combine(CurrentDirectory, "streams.xml");

        FileStream xmlFileStream = File.Create(xmlFile);
        XmlWriter xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings {Indent = true});

        //Write the xml declaration
        xml.WriteStartDocument();

        //Write root element
        xml.WriteStartElement("callsigns");

        foreach(string item in callsigns) {
            xml.WriteElementString("callsign", item);
        }

        xml.WriteEndElement();
        xml.Close();
        xmlFileStream.Close();

        Console.WriteLine("{0} contains {1:N0} bytes.", arg0: xmlFile, arg1: new FileInfo(xmlFile).Length);
        Console.WriteLine(File.ReadAllText(xmlFile));

        using (XmlReader reader = XmlReader.Create("streams.xml")) {
            while (reader.Read()) {
                //check if on element node named callsign
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign")) {
                    reader.Read();
                    Console.WriteLine($"{reader.Value}");
                }
            }
        }
    }
}