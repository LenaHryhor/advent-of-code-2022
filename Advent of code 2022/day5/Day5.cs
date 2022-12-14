using System;

namespace Advent_of_code_2022
{
   internal class Day5
   {
        private static List<Stack<char>> InitializeListOfStacks(int count)
        {
            List<Stack<char>> stacks = new List<Stack<char>>(count);
            for (int i = 0; i < count; i++)
                stacks[i] = new Stack<char>();
            return stacks;
        }
        struct Instruction
        {
            public int count;
            public int from;
            public int to;
        }
        private static Instruction GetInstruction(string line)
        {
            var list = line.Split(' ');
            return new Instruction { count = int.Parse(list[1]), from = int.Parse(list[3]), to = int.Parse(list[5]) };
        }

        private static Stack<char> GetReverseStack(Stack<char> stack)
        {
            var newStack = new Stack<char>();
            int count = stack.Count;
            for (int i = 0; i< count; i++)
                newStack.Push(stack.Pop());

            return newStack;
        }

        public static void Run()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\dev\\advent-of-code-2022\\Advent of code 2022\\day5\\day5.txt");
                String line = sr.ReadLine();
                List<Stack<char>> stacks = new List<Stack<char>>()
                {
                    new Stack<char> (), new Stack<char> (), new Stack<char> (),
                    new Stack<char> (), new Stack<char> (), new Stack<char> (),
                    new Stack<char> (), new Stack<char> (), new Stack<char> ()
                };

                char[,] data = new char[2, 3];
                int row = 0;
                while (line != null)
                {
                    if (line.Contains('['))
                    {
                        var stackCounter = 0;
                        //columns - 1 5 9 13 17 21 25 29 33
                        for (int j = 1; j < line.Length; j = j + 4)
                        {
                            var item = line[j];
                            if (item != ' ')
                                stacks[stackCounter].Push(item);
                            
                            stackCounter++;
                        }
                        row++;
                    }
                    else if (line.Contains("move"))
                    {
                        var instruction = GetInstruction(line);

                        //part1
                        //for (int i = 0; i < instruction.count; i++)
                        //    stacks[instruction.to - 1].Push(stacks[instruction.from -1].Pop());

                        //part2
                        var additionalStack = new Stack<char>();
                        for(int i = 0; i < instruction.count; i++)
                            additionalStack.Push(stacks[instruction.from - 1].Pop());

                        for (int i = 0; i < instruction.count; i++)
                            stacks[instruction.to - 1].Push(additionalStack.Pop()); 
                        

                    }
                    else if (line.Contains('1'))
                    {
                        for (int i = 0; i < stacks.Count; i++)
                            stacks[i] = GetReverseStack(stacks[i]);
                    }

                    line = sr.ReadLine();
                }
                sr.Close();

                string res = "";
                foreach (var stack in stacks)
                    res = stack.TryPop(out char c) ? res + c : res;

                Console.WriteLine(res); // BSDMQFLSP
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }

        }
   }
}
