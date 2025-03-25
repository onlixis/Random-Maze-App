using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Runtime.InteropServices;

public class MazeDeepF : MazePersonal //child class, derived from MazePersonal
{
    
	public MazeDeepF() { }//constructor

   

    public Stopwatch stopwatch = new Stopwatch();//Timer

    
    protected override void mapBuild()//override of MazePersonal's method
    {
        isBorders = new bool[mazeHeight, mazeWidth];
        isCorridor = new bool[mazeHeight, mazeWidth];

        for (int i = 0; i < isCorridor.GetLength(0); i++)
        {
            for (int j = 0; j < isCorridor.GetLength(1); j++)
            {
               
                isBorders[i, j] = true; // make all map with borders
            }
        }

        for (int i = 1; i < isBorders.GetLength(0) - 1; i++)
        {
            for (int j = 1; j < isBorders.GetLength(1) - 1; j++)
            {
              
                isCorridor[i, j] = false; 
                isBorders[i, j] = false;//erase borders from inner maze
            }
        }


        if (isStepByStep) { mapPrint(); }
        int[] tempCoords = new int[2]; //workaround to activate WayBuild method
        stopwatch.Start();    
        WayBuild(tempCoords);
        stopwatch.Stop();
        mapPrint();
        

    }
    
    public int[] WayBuild(int[] Coords)//the brain,heart and lungs of algorithm
    {
        bool noWay1 = false, noWay2 = false, noWay3 = false, noWay4 = false; // each bool represents possibility to go in chosen direction If bool is false, it means you cant go there
        int[] tempCoords = new int[2];
        int[] pastCoords = new int[2];//workaround to activate recursion of method
        int direction;
        while (true)
        {

            if (isStepByStep) { Thread.Sleep(50); } //to see how it makes
            direction = rand.Next(1, 5);
                switch (direction)
                {
                    case 1:// move to the left
                        
                        if (noWay1 && noWay2 && noWay3 && noWay4)// if all is false(no way in any direction)
                        {
                           
                            WayHomePrint(Coords); // if you watching step by step, it will mark this coordinates checked
                            return tempCoords; //go out from this level of recursion
                        }
                        if (noWay1) goto case 2; // if you cant go in this direction that you choose, you will go to the next possible direction 
                        else // else if you can go in this direction
                        {

                            if (isBorders[yPlayer,xPlayer-1] || isBorders[yPlayer, xPlayer - 2] || isCorridor[yPlayer, xPlayer - 2] || isCorridor[yPlayer, xPlayer-1]) { noWay1 = true; break; }// if there is border or corridor in this direction, then there is no way in this direction
                            else // if you finally can go in this direction
                            {
                                
                                xPlayer--; // change position by 1
                                isCorridor[yPlayer, xPlayer] = true; //save it as corridor
                                WayPrint(); // print corridor, if you watch step by step
                                xPlayer--; // you do it twice, cuz you cant do it once
                                isCorridor[yPlayer, xPlayer] = true;
                                WayPrint();

                                tempCoords[0] = xPlayer; //safe our coordinates in temporary variable   
                                tempCoords[1] = yPlayer;

                                pastCoords = WayBuild(tempCoords); // send this coordinates to recursive method

                                xPlayer = tempCoords[0]; // overwrite our coordinations when we will get back from recursion
                                yPlayer = tempCoords[1];

                            }

                            // And same shit for other directions
                        }
                        break;

                    case 2:// move to the right
                        
                        if (noWay1 && noWay2 && noWay3 && noWay4)
                        {
                           
                                WayHomePrint(Coords);
                                return tempCoords;
                            
                        }
                        if (noWay2) goto case 3;
                        else
                        {
                            if (isBorders[yPlayer, xPlayer + 1] || isBorders[yPlayer, xPlayer + 2] || isCorridor[yPlayer, xPlayer + 2] || isCorridor[yPlayer, xPlayer+1]) { noWay2 = true; break; }
                            else
                            {
                                

                                xPlayer++;
                                isCorridor[yPlayer, xPlayer] = true;
                                WayPrint();
                                xPlayer++;
                                isCorridor[yPlayer, xPlayer] = true;
                                WayPrint();

                                tempCoords[0] = xPlayer;
                                tempCoords[1] = yPlayer;

                                pastCoords = WayBuild(tempCoords);
                                
                                xPlayer=tempCoords[0];
                                yPlayer=tempCoords[1];



                            }
                        }
                        break;

                    case 3:// move to the up
                        

                        if (noWay1 && noWay2 && noWay3 && noWay4)
                        {
                            
                               
                                WayHomePrint(Coords);

                                return tempCoords;
                            
                        }
                        if (noWay3) goto case 4;
                        else
                        {
                            if (yPlayer - 2 >= 0 && !isBorders[yPlayer - 1, xPlayer] && !isBorders[yPlayer - 2, xPlayer] && !isCorridor[yPlayer - 2, xPlayer] && !isCorridor[yPlayer - 1, xPlayer])
                            {
                                yPlayer--;
                                isCorridor[yPlayer, xPlayer] = true;
                                WayPrint();
                                yPlayer--;
                                isCorridor[yPlayer, xPlayer] = true;
                                WayPrint();

                                tempCoords[0] = xPlayer;
                                tempCoords[1] = yPlayer;

                                pastCoords = WayBuild(tempCoords);

                                xPlayer = tempCoords[0];
                                yPlayer = tempCoords[1];
                               
                            }
                            else
                            {
                                noWay3 = true; break;
                            }
                        }

                        break;

                    case 4:// move to the down
                       
                        if (noWay1 && noWay2 && noWay3 && noWay4)
                        {
                           
                               
                             
                              WayHomePrint(Coords);

                                return tempCoords;
                            
                        }
                        if (noWay4) goto case 1;
                        else
                        {
                            if (isBorders[yPlayer+1, xPlayer] || isBorders[yPlayer + 2, xPlayer] || isCorridor[yPlayer + 2, xPlayer] || isCorridor[yPlayer+1, xPlayer]) { noWay4 = true; break; }
                            else
                            {
                                

                                yPlayer++;
                                isCorridor[yPlayer, xPlayer] = true;
                                WayPrint();
                                yPlayer++;
                                isCorridor[yPlayer, xPlayer] = true;
                                WayPrint();

                                tempCoords[0] = xPlayer;
                                tempCoords[1] = yPlayer;

                                pastCoords = WayBuild(tempCoords);

                                xPlayer = tempCoords[0];
                                yPlayer = tempCoords[1];
                            }
                        }
                        break;
                }            
        }
    }

}
