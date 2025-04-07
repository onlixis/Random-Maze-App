using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

public class Player
{
    private int playerX = 1,playerY = 1; 

   
    public bool PlayerMove(MazeDeepF mazeDeepF)
    {

        int winX = mazeDeepF.isCorridor.GetLength(1) - 2 , winY = mazeDeepF.isCorridor.GetLength(0) - 2; // coordinates of exit of maze.(Its in the down right corner because there is always builds path.)
        Console.SetCursorPosition(winX,winY); 
        Console.BackgroundColor = ConsoleColor.DarkRed; // mark pixel as exit
        Console.Write(" ");
        Console.ResetColor();

        ConsoleKeyInfo controls = Console.ReadKey();

        Console.SetCursorPosition(playerX, playerY); //
        Console.BackgroundColor = ConsoleColor.White;//  It writes white pixel where player passed, otherwise it will be black, because player pixel will erase path pixel
        Console.Write(" ");                          //
        Console.ResetColor();
        switch (controls.Key) // Controls
        {
            case ConsoleKey.UpArrow:
                if (!mazeDeepF.isBorders[playerY - 1, playerX] && mazeDeepF.isCorridor[playerY - 1, playerX]) { playerY--; }    //If(player has not border or wall in his directon){move in this direction})              
                break;
            case ConsoleKey.LeftArrow:
                if (!mazeDeepF.isBorders[playerY, playerX - 1] && mazeDeepF.isCorridor[playerY, playerX - 1]) { playerX--; }    //
                break;
            case ConsoleKey.DownArrow:
                if (!mazeDeepF.isBorders[playerY + 1, playerX] && mazeDeepF.isCorridor[playerY + 1, playerX]) { playerY++; }    //
                break;
            case ConsoleKey.RightArrow:
                if (!mazeDeepF.isBorders[playerY, playerX + 1] && mazeDeepF.isCorridor[playerY, playerX + 1]) { playerX++; }    //
                break;

                


        }

        Console.SetCursorPosition(playerX, playerY);//
        Console.BackgroundColor = ConsoleColor.Blue;// write player pixel
        Console.Write(" ");                         //
        Console.ResetColor();
        if (playerX == winX && playerY == winY) // if player have same coordinates as exit
        {
            return false;
        }
        else
            return true;
        
        
    }





}
