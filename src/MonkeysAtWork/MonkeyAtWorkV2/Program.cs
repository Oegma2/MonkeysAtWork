using System;
using System.Diagnostics;

namespace MonkeyAtWorkV2
{
    public class WorkerMonkey
    {
        Random random;
        private char[] possibleLetters = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

        public WorkerMonkey()
        {            
        }
        public WorkerMonkey(Random random)
        {
            this.random = random;
        }

        private char nextChar()
        {
            char nextRandChr = possibleLetters[random.Next(0, possibleLetters.Length)];
            return nextRandChr;
        }

        public bool CheckMonkeyKey(char charToCheck)
        {
            if (nextChar() == charToCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Program
    {
        #region PRIVATE PROPERTIES

        private static Random random = new Random();
        private static long monkeyCount = 0;
        private static long totalCount = 0;

        #endregion

        #region PRIVATE STATIC METHODS

        static void keepTrackOfMillions(int indexPassed, string message)
        {
            monkeyCount++;

            if (monkeyCount > 10000000)  //print out every 1mil attempts
            {
                monkeyCount = 0;
                totalCount += 10;

                //Mark area blue that's been matched by some monkey for visual update
                Console.ResetColor();
                Console.Write(totalCount.ToString().PadLeft(14) + " million - Searching: [");
                Console.BackgroundColor = ConsoleColor.DarkBlue;
                for (int i = 0; i < indexPassed; i++)
                {
                    Console.Write(message[i]);
                }
                Console.ResetColor();
                for (int i = indexPassed; i < message.Length; i++)
                {
                    Console.Write(message[i]);
                }
                Console.WriteLine("]");                
            }
        }

        #endregion

        static void Main(string[] args)
        {
            string message = "";

            Console.WriteLine("MonkeysAtWorkV2 - Load testing tool V2.0.1");
            Console.WriteLine("");

            if (args.Length <= 0)
            {
                Console.WriteLine("MonkeysAtWorkV2 \"[message]\"");
                Console.WriteLine("");
                Console.WriteLine("   [message] - This will be the message the monkey's need to try and type");
                Console.WriteLine("");
                Console.WriteLine("Example of running your MonkeysAtWork for CTest method:");
                Console.WriteLine("   MonkeysAtWorkV2 \"Foxy Lady\"");
                Environment.Exit(0);
            }

            message = args[0];

            if(message.Length == 0)
            {
                Environment.Exit(0);
            }

            Stopwatch stopwatch = new Stopwatch();
            WorkerMonkey monkey = new WorkerMonkey(random);

            char[] letters = message.ToCharArray();
            int nextCharIndex = 0;
            int howFarIndex = 0;
            stopwatch.Start();
            while (true)
            {
                keepTrackOfMillions(howFarIndex, message);

                if (monkey.CheckMonkeyKey(letters[nextCharIndex]))
                {
                    if (nextCharIndex < letters.Length-1)
                    {
                        nextCharIndex++;

                        if(howFarIndex < nextCharIndex)
                        {
                            howFarIndex = nextCharIndex;
                        }
                    }
                    else
                    {
                        stopwatch.Stop();
                        break;
                    }
                }
                else
                {
                    nextCharIndex = 0;
                }
            }

            Console.WriteLine("");
            Console.Write("Found all the worlds in [" + stopwatch.Elapsed + "] time and required [" + totalCount + "] million monkeys to find: [");
            Console.WriteLine(message + "]");
            Console.ReadLine();
        }
    }
}
