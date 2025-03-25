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
            
             Console.CursorVisible = false; // Hide cursor

            mazeDeepF.SetMazeSize(117, 29); // method that gives size of maze to mazeDeepF class
            mazeDeepF.MapBuild(); //builds maze

            Console.WriteLine("Time elapsed: " + mazeDeepF.stopwatch.Elapsed.TotalMilliseconds + " ms");
            long memoryAfter = GC.GetTotalMemory(false);
            float rounded = (float)memoryAfter;
            Console.WriteLine("Memory taken: " + Math.Round( rounded) / 1024 + " KB");//How much time it takes to make maze

        }
    }
}
