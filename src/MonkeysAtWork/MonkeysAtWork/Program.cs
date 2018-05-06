/*
*
*  Copyright 2018 PHP2ASAP
*
*     Licensed under the Apache License, Version 2.0 (the "License");
*     you may not use this file except in compliance with the License.
*     You may obtain a copy of the License at
*
*         http://www.apache.org/licenses/LICENSE-2.0
*
*     Unless required by applicable law or agreed to in writing, software
*     distributed under the License is distributed on an "AS IS" BASIS,
*     WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
*     See the License for the specific language governing permissions and
*     limitations under the License.
*
*/

using System;
using System.Diagnostics;

namespace MonkeysAtWork
{
    class Program
    {
        #region PRIVATE PROPERTIES

        private static char[] possibleLetters = "abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        //private static char[] possibleLetters = "abcdefghijklmnopqrstuvwxyz ".ToCharArray();
        private static int lettersCount = possibleLetters.Length;
        private static Random random = new Random((int)DateTime.Now.Ticks);
        private static ulong monkies = 0;
        private static ulong totalMonkies = 0;
        private static int numOfTest = 10;

        #endregion

        #region FIRST OPTION - USING FULL WORD

        /// <summary>
        /// Random a word based on the length you specify
        /// </summary>
        /// <param name="lenOfWord"></param>
        /// <returns>Word</returns>
        static string monkeysWord(int lenOfWord)
        {
            char[] builder = new char[lenOfWord];
            for (int i = 0; i < lenOfWord; i++)
            {
                builder[i] = possibleLetters[random.Next(0, lettersCount)];
            }

            return new string(builder);
        }
        /// <summary>
        /// See if a monkey can generate a rondom word that matches your specified one
        /// </summary>
        /// <param name="wordToCheck"></param>
        /// <returns>True if the random word matches your expect result/returns>
        static bool monkeyFoundWord(string wordToCheck)
        {
            if (monkeysWord(wordToCheck.Length) == wordToCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Did the monkey find all the words in your array of words
        /// </summary>
        /// <param name="words"></param>
        /// <returns>True if all words you specify been matched</returns>
        static bool monkeyFoundSentance(string[] words)
        {
            int nextWordIndex = 0;
            while (nextWordIndex < words.Length)
            {
                if (monkeyFoundWord(words[nextWordIndex]))
                {
                    //Console.WriteLine(words[nextWordIndex]);
                    nextWordIndex++;
                }
                else
                {
                    monkies++;
                    totalMonkies++;
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region SECOND OPTION - USING CHAR

        /// <summary>
        /// Monkey will return a single random char
        /// </summary>
        /// <returns></returns>
        static char monkeyLetter()
        {
            return possibleLetters[random.Next(0, lettersCount)];
        }
        /// <summary>
        /// See if a monkey can generate a random char that matches your expect input
        /// </summary>
        /// <param name="charToCheck"></param>
        /// <returns>True if monkey generate your input</returns>
        static bool monkeyFoundLetter(char charToCheck)
        {
            if (monkeyLetter() == charToCheck)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Check char for char and see if the monkey can write your letters
        /// </summary>
        /// <param name="letters"></param>
        /// <returns>True if all the letters in sequence where matched</returns>
        static bool monkeyFoundCharSentance(char[] letters)
        {
            int nextWordIndex = 0;
            string totalFind = string.Empty;

            while (nextWordIndex < letters.Length)
            {
                if (monkeyFoundLetter(letters[nextWordIndex]))
                {
                    nextWordIndex++;
                }
                else
                {
                    monkies++;
                    totalMonkies++;
                    return false;
                }
            }

            return true;
        }

        #endregion

        /// <summary>
        /// Test run using char-array for words - matching one char at time
        /// </summary>
        static void testRunWithChar(string message)
        {            
            char[] letterForLetter = message.ToCharArray();
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch totalTime = new Stopwatch();

            totalTime.Start();
            for (int i = 0; i < numOfTest; i++)
            {
                monkies = 0;
                stopwatch.Reset();
                stopwatch.Start();

                while (true)
                {
                    if (monkeyFoundCharSentance(letterForLetter))
                    {
                        break;
                    }
                }
                stopwatch.Stop();

                Console.WriteLine(i.ToString().PadRight(4) + " " + stopwatch.Elapsed + " - [" + monkies.ToString().PadLeft(9) + "] Nr of Monkey's to write [" + message + "]");
            }
            totalTime.Stop();
            Console.WriteLine("");
            Console.WriteLine("After [" + numOfTest + "] tests, running for [" + totalTime.Elapsed + "] required [" + totalMonkies + "] Monkey's to write [" + message + "]");

            double avgTime = totalTime.ElapsedMilliseconds / numOfTest;
            Console.WriteLine("Avg time: " + avgTime + "ms with avg monkie count [" + totalMonkies / numOfTest + "]");
        }
        /// <summary>
        /// Test run using string array for words - matching full words at time
        /// </summary>
        static void testRunWithStrings(string message)
        {
            string[] wordList = message.Split(' ');
            Stopwatch stopwatch = new Stopwatch();
            Stopwatch totalTime = new Stopwatch();

            totalTime.Start();
            for (int i = 0; i < numOfTest; i++)
            {
                monkies = 0;
                stopwatch.Reset();
                stopwatch.Start();

                while (true)
                {
                    if (monkeyFoundSentance(wordList))
                    {
                        break;
                    }
                }
                stopwatch.Stop();

                Console.WriteLine(i.ToString().PadRight(4) + " " + stopwatch.Elapsed + " - [" + monkies.ToString().PadLeft(9) + "] Nr of Monkey's to write [" + message + "]");
            }
            totalTime.Stop();
            Console.WriteLine("");
            Console.WriteLine("After [" + numOfTest + "] tests, running for [" + totalTime.Elapsed + "] required [" + totalMonkies + "] monkey's to write [" + message + "]");

            double avgTime = totalTime.ElapsedMilliseconds / numOfTest;
            Console.WriteLine("Avg time: " + avgTime + "ms with avg monkey count [" + totalMonkies / numOfTest + "]");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("MonkeysAtWork - Load testing tool V0.0.2");
            Console.WriteLine("");
            Console.WriteLine(ulong.MaxValue);

            if (args.Length <= 0)
            {
                Console.WriteLine("MonkeysAtWork [numoftimes] [method] \"[message]\"");
                Console.WriteLine("");
                Console.WriteLine("   [numoftimes] - Provide a starting number between 0 and 32767 for how many times you want to run the test");
                Console.WriteLine("   [method] - We provide two methods for running your load - CTest or STest");
                Console.WriteLine("   [message] - This will be the message the monkey's need to try and type");
                Console.WriteLine("");
                Console.WriteLine("Example of running your MonkeysAtWork for CTest method:");
                Console.WriteLine("   MonkeysAtWork 100 CTest \"Foxy\"");
                Environment.Exit(0);
            }

            try
            {
                numOfTest = Int32.Parse(args[0]);
                string method = args[1].ToLower();
                string message = args[2];

                switch (method)
                {
                    case "ctest":
                        Console.WriteLine("Starting [CTest] method, and will be running [" + numOfTest + "] times, trying to type [" + message + "]");
                        Console.WriteLine("");
                        testRunWithChar(message);
                        break;

                    case "stest":
                        Console.WriteLine("Starting [STest] method, and will be running [" + numOfTest + "] times, trying to type [" + message + "]");
                        Console.WriteLine("");
                        testRunWithStrings(message);
                        break;

                    default:
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("OOPS - Monkey's stole your input...or did they now?");
                Console.WriteLine("Please make sure your input is in the correct format, and we also provided the error message below");
                Console.WriteLine("");
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
    }
}
