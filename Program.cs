using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Random_Maze
{
    internal class Program
    {
    
        static void Main(string[] args)
        {
           

            MazeDeepF mazeDeepF = new MazeDeepF(); //class that makes maze with DFS algorithm
            Player player = new Player();
            
            Console.CursorVisible = false; // Hide cursor

            mazeDeepF.SetMazeSize(15,28); // method that gives size of maze to mazeDeepF class. MIN: (9,10) MAX: (115,28). ONLY (ODDA TAL, JÄMN TAL)
            mazeDeepF.MapBuild(); //builds maze


            long memoryAfter = GC.GetTotalMemory(false);

            bool GameIsOn = true;

            while (GameIsOn)
            {
                GameIsOn = player.PlayerMove(mazeDeepF); // if false - he found exit, else is continue 
            }

            Console.WriteLine("Time elapsed: " + mazeDeepF.stopwatch.Elapsed.TotalMilliseconds + " ms");
            float rounded = (float)memoryAfter;
            Console.WriteLine("Memory taken: " + Math.Round( rounded) / 1024 + " KB");//How much time it takes to make maze

        }
    }
}
