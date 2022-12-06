using System;

namespace Advent_of_code_2022.day_2
{
    internal static class Day2
    {
        // камінь перемагає ножиці
        // ножиці перемагають папір
        // папір перемагає камінь

        //A - камінь, B - папір, C - ножиці. - opponent
        //X - камінь, Y - папір, Z - ножиці. - I

        //1 - камінь, 2 - папір, and 3 - ножиці
        // outcome of the round (0 if you lost, 3 - was a draw, and 6 - you won


        //part 2
        //X - lose, Y - a draw, and Z - win

        private static int GetWinScores(string opponent, string myAnsw)
        {
            if (opponent == "A" && myAnsw == "X" ||
                opponent == "B" && myAnsw == "Y" ||
                opponent == "C" && myAnsw == "Z") // was a draw
                return 3;

            if (opponent == "A" && myAnsw == "Z" ||
                opponent == "B" && myAnsw == "X" ||
                opponent == "C" && myAnsw == "Y") // lost
                return 0;

            return 6; // you won
        }
        private static int GetShapeScores(string shape)
        {
            if (shape == "X")
                return 1;
            if (shape == "Y")
                return 2;
            return 3; // "Z"
        }

        //part 2
        private static string GetMyAnswer(string roundResult, string opponent)
        {
            if (roundResult == "X") //lose
            {
                if (opponent == "A")
                    return "Z";
                if (opponent == "B")
                    return "X";
                if (opponent == "C")
                    return "Y";
            }
            else if (roundResult == "Y") //draw
            {
                if (opponent == "A")
                    return "X";
                if (opponent == "B")
                    return "Y";
                if (opponent == "C")
                    return "Z";
            }
            else if (roundResult == "Z") //win
            {
                if (opponent == "A")
                    return "Y";
                if (opponent == "B")
                    return "Z";
                if (opponent == "C")
                    return "X";
            }
            return "";
        }

        public static void Run()
        {
            try
            {
                StreamReader sr = new StreamReader("C:\\dev\\advent-of-code-2022\\Advent of code 2022\\day2\\day2.txt");

                String line = sr.ReadLine();
                var sumPart1 = 0;
                var sumPart2 = 0;

                while (line != null)
                {
                    var list = line.Split(' ');
                    sumPart1 = sumPart1 + GetWinScores(list[0], list[1]) + GetShapeScores(list[1]);
                    
                    var myAnswer = GetMyAnswer(list[1], list[0]);
                    sumPart2 = sumPart2 + GetWinScores(list[0], myAnswer) + GetShapeScores(myAnswer);

                    line = sr.ReadLine();
                }

                sr.Close();


                //part 1
                Console.WriteLine($"Total part1: {sumPart1}");

                //part 2
                Console.WriteLine($"Total part2: {sumPart2}");
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
