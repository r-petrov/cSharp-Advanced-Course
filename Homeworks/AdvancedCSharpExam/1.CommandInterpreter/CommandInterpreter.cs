using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _1.CommandInterpreter
{
    class CommandInterpreter
    {
        static void Main(string[] args)
        {
            //int testcount = 2000000000;
            //int testLength = 3;
            //Console.WriteLine(testcount%testLength);

            string input = Console.ReadLine();
            string[] stringElements = input.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            List<string[]> commands = new List<string[]>();

            for (int i = 0; i < 20; i++)
            {
                string command = Console.ReadLine();
                string[] commandArr = command.Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);

                if (command == "end")
                {
                    break;
                }

                if ((commandArr[0] == "reverse" || commandArr[0] == "sort") &&
                    ((int.Parse(commandArr[2]) < 0 || int.Parse(commandArr[4]) < 0) || (int.Parse(commandArr[2]) + int.Parse(commandArr[4]) > stringElements.Length)))
                {
                    Console.WriteLine("Invalid input parameters.");
                    continue;
                }

                commands.Add(commandArr);
            }

            List<string> resultList = new List<string>();

            for (int i = 0; i < commands.Count; i++)
            {
                string[] command = commands[i];
                
                if (command[0] == "reverse")
                {
                    int start = int.Parse(command[2]);
                    int count = int.Parse(command[4]);
                    resultList = ReverseElements(stringElements, start, count);
                }
                else if(command[0] == "sort")
                {
                    int start = int.Parse(command[2]);
                    int count = int.Parse(command[4]);
                    resultList = SortElements(stringElements, start, count);
                }
                else if(command[0] == "rollLeft")
                {
                    int rollCount = int.Parse(command[1]);
                    resultList = RollLeftElements(stringElements, rollCount);
                }
                else if(command[0] == "rollRight")
                {
                    int rollCount = int.Parse(command[1]);
                    resultList = RollRight(stringElements, rollCount);
                }
            }

            if (resultList.Count == 0)
            {
                for (int i = 0; i < stringElements.Length; i++)
                {
                    resultList.Add(stringElements[i]);
                }
            }
            PrintStrings(resultList);
        }

        private static void PrintStrings(List<string> resultList)
        {
            Console.Write("[");
            for (int i = 0; i < resultList.Count; i++)
            {
                if (i == resultList.Count - 1)
                {
                    Console.WriteLine(resultList[i] + "]");
                }
                else
                {
                    Console.Write("{0}, ", resultList[i]);
                }
            }
        }

        static List<string> ReverseElements(string[] elements, int start, int count)
        {
            List<string> resultList = new List<string>();

            for (int i = 0; i < start; i++)
            {
                resultList.Add(elements[i]);
            }

            for (int i = start + count - 1; i >= start; i--)
            {
                resultList.Add(elements[i]);
            }

            for (int i = start + count; i < elements.Length; i++)
            {
                resultList.Add(elements[i]);
            }

            return resultList;
        }

        static List<string> SortElements(string[] elements, int start, int count)
        {
            List<string> resultList = new List<string>();
            List<string> sortedList = new List<string>();

            for (int i = 0; i < start; i++)
            {
                resultList.Add(elements[i]);
            }

            for (int i = start; i < start + count; i++)
            {
                sortedList.Add(elements[i]);
            }

            sortedList.Sort();

            for (int i = 0; i < sortedList.Count; i++)
            {
                resultList.Add(sortedList[i]);
            }

            for (int i = start + count; i < elements.Length; i++)
            {
                resultList.Add(elements[i]);
            }

            return resultList;
        }

        static List<string> RollLeftElements(string[] elements, int count)
        {
            List<string> resultList = new List<string>();
            List<string> rolledElementsList = new List<string>();
            int counter = count % elements.Length;

            for (int i = 0; i < counter; i++)
            {
                rolledElementsList.Add(elements[i]);
            }

            for (int i = counter; i < elements.Length; i++)
            {
                resultList.Add(elements[i]);
            }

            for (int i = 0; i < rolledElementsList.Count; i++)
            {
                resultList.Add(rolledElementsList[i]);
            }

            return resultList;
        }

        static List<string> RollRight(string[] elements, int count)
        {
            List<string> resultList = new List<string>();
            List<string> rolledElementsList = new List<string>();
            int counter = count % elements.Length;

            for (int i = elements.Length - 1; i >= elements.Length - counter; i--)
            {
                rolledElementsList.Add(elements[i]);
            }

            for (int i = rolledElementsList.Count - 1; i >= 0; i--)
            {
                resultList.Add(rolledElementsList[i]);
            }

            for (int i = 0; i < elements.Length - counter; i++)
            {
                resultList.Add(elements[i]);
            }

            return resultList;
        }
    }
}
