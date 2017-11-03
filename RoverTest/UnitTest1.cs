using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rover;

namespace RoverAssignmentTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        [ExpectedException(typeof(FormatException))]
        public void ValidateStartingPosition_invalidXValue_ShouldThrowFormatException()
        {

            //this test method is for testing invalid inputs of x,y or orientation

            RoverMovement obj = new RoverMovement();

            //test x
            string input0 = " 5 5";
            string[] UpperRightCoordinates = input0.Split(' ');
            string input1 = " # 3 E";
            string[] StartingPositionArray = input1.Split(' ');



            obj.ValidateStartingPosition(StartingPositionArray, UpperRightCoordinates);



        }

        [TestMethod]

        [ExpectedException(typeof(FormatException))]
        public void ValidateStartingPosition_invalidYValue_ShouldThrowFormatException()
        {

            //this test method is for testing invalid inputs of x,y or orientation

            RoverMovement obj = new RoverMovement();


            //test y
            string input0 = " 5 5";
            string[] UpperRightCoordinates = input0.Split(' ');
            string input1 = " 3 ! N";
            string[] StartingPositionArray = input1.Split(' ');

            obj.ValidateStartingPosition(StartingPositionArray, UpperRightCoordinates);






        }

       

    }
}

