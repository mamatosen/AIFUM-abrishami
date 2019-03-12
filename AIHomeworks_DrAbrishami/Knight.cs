using System.Collections.Generic;
using System.Xml;

namespace AIHomeworks_DrAbrishami
{

    public struct Vector2
    {
        public int x, y;
        public bool available;
        public Vector2(int x_, int y_)
        {
            x = x_;
            y = y_;
            available = true;
        }
    }
    
    public struct Knight
    {
        public Vector2 pos;
        public Vector2[] moves;
        public Knight(int x_, int y_)
        {
            pos = new Vector2(x_, y_);
            moves = Program.Moves(x_, y_);
        }
    }

    public struct knightsState
    {
        public Knight[] knights;

        public bool Compare(knightsState ks)
        {
            int similars = 0;
            foreach (Knight v1 in knights)
            {
                foreach (Knight v2 in ks.knights)
                {
                    if (v1.pos.x == v2.pos.x && v1.pos.y == v2.pos.y)
                    {
                        similars++;
                    }
                }
            }

            if (similars == knights.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public knightsState WhatIfMove(Vector2 m, int ki)
        {
            knightsState ks = new knightsState(knights);
            ks.knights[ki] = new Knight(m.x, m.y);
            return ks;
        }

        public knightsState(Knight[] knights_)
        {
            knights = knights_;
        }
    }
}