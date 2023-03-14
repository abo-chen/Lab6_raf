using System.IO;
using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab6_raf;
class Program
{
    static void Main(string[] args)
    {
        // 2 Create an object
        Event eventToWrite = new Event(1, "Calgary");

        //3 serialize the object to a file
        using (FileStream fileStreamWrite = File.OpenWrite("event.txt"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStreamWrite, eventToWrite);
        }

        //4 deserialize and display
        using (FileStream fileStreamRead = File.OpenRead("event.txt"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Event eventToRead = (Event)binaryFormatter.Deserialize(fileStreamRead);
            fileStreamRead.Close();

            Console.WriteLine(eventToRead.EventNumber);
            Console.WriteLine(eventToRead.Location);
        }

        //5
        readFromFile();
    }

    static void readFromFile()
    {
        Console.Write("In Word: ");
        string inWord = Console.ReadLine();

        //
        using (StreamWriter sw = new StreamWriter("iw.txt"))
        {
            sw.Write(inWord);
        }

        //
        using (FileStream fileStreamReadIW = File.OpenRead("iw.txt"))
        {
            fileStreamReadIW.Seek(0, SeekOrigin.Begin);
            int firstChar = fileStreamReadIW.ReadByte();
            Console.WriteLine($"First character: {(char)firstChar}");

            // Read the middle character
            fileStreamReadIW.Seek(fileStreamReadIW.Length / 2, SeekOrigin.Begin);
            int middleChar = fileStreamReadIW.ReadByte();
            Console.WriteLine($"Middle character: {(char)middleChar}");

            // Read the last character
            fileStreamReadIW.Seek(-1, SeekOrigin.End);
            int lastChar = fileStreamReadIW.ReadByte();
            Console.WriteLine($"Last character: {(char)lastChar}");
        }
    }
}





