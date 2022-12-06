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
                    new Stack<char> (), new Stack<char> (), new Stack<char> ()
                };

                while (line != null)
                {
                    if (line.Contains('['))
                    {
                        var spaceCounter = 0;
                        var stackCounter = 0;
                        for(int i = 0; i < line.Length; i++)
                        {
                            if (line[i] == ' ')
                                spaceCounter++;
                            
                            if (spaceCounter == 3)
                            {
                                spaceCounter = 0;
                                stackCounter++;
                            }
                            
                            if (Char.IsLetter(line[i]))
                            {
                                stacks[stackCounter].Push(line[i]);
                                spaceCounter = 0;
                                stackCounter++;
                            }
                        }
                    }
                    else if (line.Contains("move"))
                    {
                        var instruction = GetInstruction(line);
                        for(int i = 0; i < instruction.count; i++)
                            stacks[instruction.to - 1].Push(stacks[instruction.from - 1].Pop());
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

                Console.WriteLine(res);
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
