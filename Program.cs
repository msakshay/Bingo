using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo
{
    class Bingo
    {
        public string GetWinningStreak(string[,] ticket, int[] sequence)
        {
            List<int> corner = new List<int>();
            List<int> firstRow = new List<int>();
            List<int> middleRow = new List<int>();
            List<int> lastRow = new List<int>();

            if (ticket.Length <= 0)
                return "NW";
            

            for (int i = 0; i < 3; i++)
            {
                int valCount = 0;
                for (int j = 0; j < 9; j++)
                {
                    if (i == 0 && GetTicketValue(ticket[i, j]) > 0)
                    {
                        valCount++;
                        if ((valCount == 1 || valCount==5))
                        {
                            corner.Add(GetTicketValue(ticket[i, j]));
                        }                        
                        firstRow.Add(GetTicketValue(ticket[i, j]));
                    }
                    else if (i == 1 && GetTicketValue(ticket[i, j]) > 0)
                    {
                        middleRow.Add(GetTicketValue(ticket[i, j]));
                    }
                    else if (i == 2 && GetTicketValue(ticket[i, j]) > 0)
                    {
                        valCount++;
                        if ((valCount == 1 || valCount == 5))
                        {
                            corner.Add(GetTicketValue(ticket[i, j]));
                        }
                        lastRow.Add(GetTicketValue(ticket[i, j]));
                    }
                }
            }

            for (int i = 0; i < sequence.Length; i++)
            {
                if (corner.Contains(sequence[i]))
                {
                    corner.Remove(sequence[i]);
                    if (corner.Count == 0)
                        return sequence[i] + "C";
                }

                if (firstRow.Contains(sequence[i]))
                {
                    firstRow.Remove(sequence[i]);
                    if (firstRow.Count == 0)
                        return sequence[i] + "FR";
                }

                if (middleRow.Contains(sequence[i]))
                {
                    middleRow.Remove(sequence[i]);
                    if (middleRow.Count == 0)
                        return sequence[i] + "MR";
                }

                if (lastRow.Contains(sequence[i]))
                {
                    lastRow.Remove(sequence[i]);
                    if (lastRow.Count == 0)
                        return sequence[i] + "LR";
                }
            }
            return "NW";

        }

        private int GetTicketValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return 0;
            else 
                return Convert.ToInt32(value);
        }

        class Solution
        {
            public static void Main(string[] args)
            {
                try
                {
                    string[,] ticket = new string[3, 9] {{ "62", "11", "21", "32", "82", "", "", "", "" },
                                                         { "1", "", "23", "39", "", "", "", "69", "75", },
                                                         { "5", "", "27", "", "45", "56", "", "", "83" } };

                    //string[] row1 = Console.ReadLine().Split(',');
                    //for (int i = 0; i < 9; i++)
                    //{
                    //    ticket[0, i] = row1[i].Trim();
                    //}

                    //string[] row2 = Console.ReadLine().Split(',');
                    //for (int i = 0; i < 9; i++)
                    //{
                    //    ticket[1, i] = row2[i].Trim();
                    //}

                    //string[] row3 = Console.ReadLine().Split(',');
                    //for (int i = 0; i < 9; i++)
                    //{
                    //    ticket[2, i] = row3[i].Trim();
                    //}

                    //string[] seq = Console.ReadLine().Trim().Split(',');

                    int[] sequence = new int[] { 9, 11, 21, 32, 7, 99, 62, 56, 80, 5, 89, 44 };
                    //sequence = new int[seq.Length];

                    //for (int i = 0; i < seq.Length; i++)
                    //{
                    //    sequence[i] = Convert.ToInt32(seq[i]);
                    //}

                    //var ExpectedWinnigStreak = Console.ReadLine().Trim();

                    var winningStreak = new Bingo().GetWinningStreak(ticket, sequence);
                    Console.WriteLine(winningStreak);
                    Console.ReadLine();
                    //var match = (ExpectedWinnigStreak == winningStreak).ToString();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.Read();
                }
            }
        }
    }
}
