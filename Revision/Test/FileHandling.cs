using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class FileHandling
    {


        public void MainFunction()
        {
            string path = "D:\\source\\repos\\TechnofexTest\\Test\\TextFile2.txt";
            if (File.Exists(path))
            {
                //Write content to existing file
                File.AppendAllTextAsync(path, "Helloworld");

                //Read all data
                var data = File.ReadAllLines(path);
                foreach (var line in data)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                //To create file
                File.Create(path);

                //Overwrites every thing with the content
                File.WriteAllTextAsync(path,"hello world");
                
                Console.WriteLine("file does not exist");

                //To delete file
                File.Delete(path);
            }
        }
    }
}
