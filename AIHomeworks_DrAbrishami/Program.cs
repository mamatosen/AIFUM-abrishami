using System;
using System.Collections.Generic;

namespace AIHomeworks_DrAbrishami
{
    class Program
    {
        private static Fringe f;
        private static knightsState currentState, idealState;
        private static List<Vector2> choices;
        private static int xBound, yBound;
        
        public static void Main(string[] args)
        {
            choices = new List<Vector2>();
            f = new DFS_Fringe();
            GetInput();
            do
            {
                currentState = f.Pop();
                Successor();
            } while (!GoalTest());
            Console.WriteLine("done");
        }

        private static bool GoalTest()
        {
            return currentState.Compare(idealState);
        }
        
        private static void Successor()
        {
            for (int i = 0; i < currentState.knights.Length; i++)
            {
                AddAvailableMoves(i);
            }
        }

        private static void AddAvailableMoves(int kIndex)
        {
            Knight k = currentState.knights[kIndex];
            for (int j = 0; j < k.moves.Length; j++)
            {
                Vector2 move = k.moves[j];
                
                for (int i = 0; i < currentState.knights.Length; i++)
                {
                    if (i != kIndex)
                    {
                        foreach (var move_ in currentState.knights[i].moves)
                        {
                            if (move.x == move_.x && move.y == move_.y)
                            {
                                move.available = false;
                            }
                        }
                    }
                }

                if (move.available)
                {
                    f.Append(
                        currentState.WhatIfMove(move, kIndex)
                    );
                }
            }
        }

        public static Vector2[] Moves(int x_, int y_)
        {
            List<Vector2> moves = new List<Vector2>();
            
            // for switching bigger number
            for (int i = 0; i < 2; i++)
            {
                // for switching x sign
                for (int j = 0; j < 2; j++)
                {
                    // for switching y sign
                    for (int k = 0; k < 2; k++)
                    {
                        var xSign = j == 0 ? 1 : -1;
                        var ySign = k == 0 ? 1 : -1;
                        
                        var x = i == 0 ? 2 * xSign : 1 * xSign;
                        var y = i == 1 ? 2 * ySign : 1 * ySign;

                        x = x_ + x;
                        y = y_ + y;

                        if (x >= 0 && x < xBound && y >= 0 && y < yBound)
                        {
                            moves.Add(new Vector2(x, y));
                        }
                    }
                }
            }

            return moves.ToArray();
        }

        private static void GetInput()
        {
            string l = Console.ReadLine();
            int m = Convert.ToInt32(l[0] + ""), n = Convert.ToInt32(l[1] + "");
            xBound = m;
            yBound = n;
            List<Knight> knights = new List<Knight>();

            for (int i = 0; i < n; i++)
            {
                l = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    if (l[j] == '#')
                    {
                        knights.Add(
                                new Knight(j, i)
                            );
                    }
                }
            }
            
            f.Append(
                    new knightsState(
                            knights.ToArray()
                    )
            );
            
            knights = new List<Knight>();
            
            for (int i = 0; i < n; i++)
            {
                l = Console.ReadLine();
                for (int j = 0; j < m; j++)
                {
                    if (l[j] == '#')
                    {
                        knights.Add(
                            new Knight(j, i)
                        );
                    }
                }
            }

            idealState = new knightsState(knights.ToArray());
        }
    }
}