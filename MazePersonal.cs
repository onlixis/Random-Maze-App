using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

public class MazePersonal //parent class, contains main methods Like print or etc
{
    protected bool isStepByStep = false; // to see making of maze step by step

    protected bool[,] isBorders = new bool[mazeHeight, mazeWidth]; // array of boolians, that represents borders of maze, so it may not do IndexOutOfRangeExeption shit
    protected Random rand = new Random(); // random number
    static protected int mazeHeight,mazeWidth; //height and width of maze
    protected int xPlayer = 1 , yPlayer = 0; // pozition of "player" or cursor, as you wish
    protected bool[,] isCorridor = new bool[mazeHeight, mazeWidth]; // array of boolians, that represents tiles that is corridor of maze

    public MazePersonal(){}//constructor
    protected virtual void mapBuild() //SKIP IT. my personal try to make a maze, nvm. It doesnt works yet, but maybe in future..
    {
        isBorders = new bool[mazeHeight, mazeWidth];
        isCorridor = new bool[mazeHeight, mazeWidth];
        int countJ = 0, countI = 0;

        for (int i = 0; i < isCorridor.GetLength(0); i++)
        {
            for (int j = 0; j < isCorridor.GetLength(1); j++)
            {
               
                isCorridor[i, j] = false;
            }
        }

        for (int i = 1; i < isCorridor.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < isCorridor.GetLength(1) - 1; j++)
            {
                
                isCorridor[i, j] = true;
            }
        }

        for (int i = 1; i < isCorridor.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < isCorridor.GetLength(1) - 1; j++)
            {

               
                isCorridor[i, j] = true;
                countJ++;
                if (countI % 2 == 0)
                {
                    
                    isCorridor[i, j] = false;

                }

                if (countJ == 1)
                {
      
                    isCorridor[i, j] = false;

                }
                countJ = 0;
            }
            countI++;
        }
    }

    protected void mapPrint() // prints map
    {
        
        for (int i = 0; i < isCorridor.GetLength(0); i++)
        {
            for (int j = 0; j < isCorridor.GetLength(1); j++)
            {
                if (isCorridor[i, j])
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write(" ");

                }
                else if (!isCorridor[i, j])
                {
                    if (isBorders[i, j])
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write(" ");
                    }
                }
                
                Console.ResetColor();
            }
            Console.WriteLine();
        }

    }

    public void MapBuild() // getter for mapBuild
    {
        mapBuild();
    }
    public void MapPrint() // getter for mapPrint
    {
        mapPrint();
    }

    public void SetMazeSize(int width, int height)
    {
        mazeWidth = width;
        mazeHeight = height;
    }

    public void WayPrint()
    {
        if (isStepByStep)
        {
            Console.SetCursorPosition(xPlayer, yPlayer);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write(" ");
            Console.ResetColor();
            Console.SetCursorPosition(mazeWidth + 1, mazeHeight + 1);
        }
    }

    public void WayHomePrint(int[] tempCoods)
    {
        if (isStepByStep)
        {
            Console.SetCursorPosition(tempCoods[0], tempCoods[1]);
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.Write(" ");
            Console.ResetColor();
            Console.SetCursorPosition(mazeWidth + 1, mazeHeight + 1);
        }
    }
}
