using System;
using System.IO;

namespace SurveyShips
{
    public class Program
    {
        /// <summary>
        /// Return codes for Main. Using standard convention of 0 is success.
        /// </summary>
        private enum ReturnCode
        {
            Success = 0,
            Error = 1
        }

        /// <summary>
        /// Main.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static int Main(string[] args)
        {
            ReturnCode returnCode = ReturnCode.Error;

            try
            {
                if (args.Length != 1)
                {
                    Console.WriteLine("Expecting 1 argument - path to input file");
                }
                else if (!File.Exists(args[0]))
                {
                    Console.WriteLine("File does not exist!");
                }
                else
                {
                    string[] lines = File.ReadAllLines(args[0]);
                    string[] output = InputHandler.ProcessInput(lines);
                    foreach (string line in output)
                    {
                        Console.WriteLine(line);
                    }
                    returnCode = ReturnCode.Success;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured:");
                Console.WriteLine(ex);
            }

            return (int)returnCode;
        }
    }
}
