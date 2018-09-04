﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Numerics;

namespace ConsoleApp1
{
    public class Matchfield
    {
        public bool SnakeIsALive = true;

        public int yRandom;
        public int xRandom;

        public int Score = 0;
        public int Speed;
        public int Length;
        public int Height;

        public Matchfield()
        {
            Height = 22;
            Length = 82;
            Speed = 10;
        }
      
        //Leerer Konstruktor
        public Matchfield(int speedInput) { }
        
        /// <summary>
        /// Writes the border on screen
        /// </summary>
        public void DrawBorders()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            for (int i = 0; i <= Length; i++)
            {
                    Console.SetCursorPosition(i, 0);
                Console.Write("■");

                Console.SetCursorPosition(i, Height - 1);
                Console.Write("■");
            }

            for (int i = 0; i < Height; i++)
            {
            Console.SetCursorPosition(0, i);
            Console.Write("■");

            Console.SetCursorPosition(Length, i);
            Console.Write("■");
            }
        }

        public void DropItems()
        {
            Random randomxyItemPos = new Random();

            yRandom = randomxyItemPos.Next(20);
            xRandom = randomxyItemPos.Next(81);
            Console.SetCursorPosition(xRandom, yRandom);
            Console.Write("*");

        }
        
    }
}
