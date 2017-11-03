using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rover
{


    public class RoverMovement
    {



        public static bool flag = false;
        /*this flag is used to prompt the user to enter Upper right coordinates AGAIN for Rover 2 ,in case
         rover 1 entry was invalid*/

        static void Main(string[] args)
        {


            Console.Write("Enter Graph Upper Right Coordinate:");
            string input0 = Console.ReadLine(); // Get string from user*/

            //this loop is prompting the user to enter two rover informaions

            for (int roverCount = 1; roverCount < 3; roverCount++)
            {
                if (flag)
                {
                    Console.Write("Enter Graph Upper Right Coordinate:");
                    input0 = Console.ReadLine(); // Get string from user*/

                }
                Console.Write("Rover  " + roverCount + "  Starting Position:");
                string input1 = Console.ReadLine(); // Get string from user
                Console.Write("Rover  " + roverCount + "  Movement Plan:");
                string input2 = Console.ReadLine(); // Get string from user


                //process inputs
                RoverMovement obj = new RoverMovement();
                string[] UpperRightCoordinates = input0.Split(' ');
                string[] StartingPositionArray = input1.Split(' ');
                char[] MovementPlan = input2.ToCharArray();


                /*initial validation
                check empty entries or out of accepted range ( StartingPositionArray should be of size 4 and 
                starts with a space)*/


                if (input0 != string.Empty && input1 != string.Empty && input2 != string.Empty && input1[0] == ' ' && StartingPositionArray.Length == 4 && UpperRightCoordinates.Length == 3)
                {

                    // call two differant methods to validate StartingPositionArray and MovementPlan.
                    if (obj.ValidateStartingPosition(StartingPositionArray, UpperRightCoordinates) && obj.ValidateMovementPlan(MovementPlan))
                    {
                        obj.MoveRover(StartingPositionArray, MovementPlan, 1, UpperRightCoordinates);
                    }
                    else
                    {


                        Console.WriteLine("wrong input format");

                    }
                }
                else
                {

                    Console.WriteLine("wrong or Empty input ");

                }


                Console.ReadKey();

            }

        }




        /* ValidateStartingPosition method validates StartingPositionArray.*/
        public bool ValidateStartingPosition(string[] StartingPositionArray, string[] UpperRightCoordinates)
        {



            if (Convert.ToInt32(StartingPositionArray[1]) <= Convert.ToInt32(UpperRightCoordinates[1]) &&
                 Convert.ToInt32(StartingPositionArray[2]) <= Convert.ToInt32(UpperRightCoordinates[2]) &&
                 Convert.ToInt32(UpperRightCoordinates[1])> 0 && Convert.ToInt32(UpperRightCoordinates[2])>0)
            {
                //validate x


                int number;

                if (Int32.TryParse(StartingPositionArray[1], out number))
                {
                    int xCoordinate = Convert.ToInt32(StartingPositionArray[1]);

                }
                else
                {
                    Console.Write("invalid X Coordinate");
                    Console.ReadKey();
                    throw new FormatException("invalid X Coordinate");


                }

                //validate y
                if (Int32.TryParse(StartingPositionArray[2], out number))
                {
                    int yCoordinate = Convert.ToInt32(StartingPositionArray[2]);
                }

                else
                {
                    Console.Write("invalid Y Coordinate");
                    Console.ReadKey();
                    throw new FormatException("invalid Y Coordinate");

                }


                //validate orientation

                if (StartingPositionArray[3] == "N" || StartingPositionArray[3] == "E" || StartingPositionArray[3] == "W" || StartingPositionArray[3] == "S")
                {
                    String RoverOrientation = StartingPositionArray[3];


                }
                else
                {
                    Console.Write("invalid Orientation value");
                    Console.ReadKey();
                    
                }

            }
            else
            {
                flag = true;
                Console.Write("one or both of the resulted coordinates have exceeded the upper right coordinates");
                Console.ReadKey();
                throw new ArgumentException("one or both of the resulted coordinates have exceeded the upper right coordinates");
            }


            return true;

        }


        /* ValidateMovementPlan method validates MovementPlan.*/
        public bool ValidateMovementPlan(char[] MovementPlan)
        {

            for (int index = 0; index < MovementPlan.Length; index++)
            {
                if (MovementPlan[index] == 'M' || MovementPlan[index] == 'L' || MovementPlan[index] == 'R')
                {
                    continue;
                }
                else
                {
                    Console.Write("invalid Movement plan value");
                    Console.ReadKey();
                    throw new ArgumentException("invalid Movement plan value");
                }

            }
            return true;

        }


        /* MoveRover method takes the validated StartingPositionArray and MovementPlan to generate the output for each rover,
        it also checks the output against the Upper Right Coordinates. */
        public void MoveRover(string[] StartingPositionArray, char[] MovementPlan, int Rovernumber, string[] UpperRightCoordinates)
        {

            int xCoordinate = Convert.ToInt32(StartingPositionArray[1].ToString());
            int yCoordinate = Convert.ToInt32(StartingPositionArray[2].ToString());
            int upperX = Convert.ToInt32(UpperRightCoordinates[1]);
            int upperY = Convert.ToInt32(UpperRightCoordinates[2]);
            string Orientation = StartingPositionArray[3];




            //parse monvement plan
            for (int Movementindex = 0; Movementindex < MovementPlan.Length; Movementindex++)
            {
                if (MovementPlan[Movementindex] == 'M')
                {

                    //increment or decrement x,y coordinates according to orientation
                    switch (Orientation)
                    {
                        case "N":
                            yCoordinate++;
                            break;
                        case "E":
                            xCoordinate++;
                            break;
                        case "W":
                            xCoordinate--;
                            break;
                        case "S":
                            yCoordinate--;
                            break;

                    }

                }

                else
                {
                    /*this switch condition updates the resulted orientation based on the values of R or L in the 
                    Movement plan. */

                    switch (Orientation + MovementPlan[Movementindex])
                    {
                        case "NR":
                            Orientation = "E";
                            break;
                        case "NL":
                            Orientation = "W";
                            break;
                        case "WR":
                            Orientation = "N";
                            break;
                        case "WL":
                            Orientation = "S";
                            break;

                        case "SR":
                            Orientation = "W";
                            break;
                        case "SL":
                            Orientation = "E";
                            break;
                        case "ER":
                            Orientation = "S";
                            break;
                        case "EL":
                            Orientation = "N"; ;
                            break;

                    }


                }


            }

            //in case the resulted coordinates have exceeded the upper right coordinates,display error message
            if (xCoordinate > upperX || yCoordinate > upperY || xCoordinate <0 || yCoordinate <0)
            {
                Console.Write("one or both of the resulted coordinates have exceeded the upper right coordinates");
                Console.ReadKey();

            }
            //else display output
            else
            {

                Console.Write("Rover " + Rovernumber + " Output:");
                Console.Write(xCoordinate + " ");
                Console.Write(yCoordinate + " ");
                Console.Write(Orientation + "\n");
            }

        }





    }
}
