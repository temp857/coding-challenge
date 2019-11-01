using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyShips
{
    public class InputHandler
    {
        public static string[] ProcessInput(string[] input)
        {
            if (input == null)
            {
                throw new ArgumentException("Input should not be null!");
            }

            string[] filteredInput = filterInput(input);

            if ((filteredInput.Length % 2) != 1)
            {
                throw new ArgumentException("Input should have odd number of elements!");
            }

            // Split with null argument splits by whitespace.
            string[] gridSizeStrs = filteredInput[0].Split(null);
            Ocean ocean = new Ocean(int.Parse(gridSizeStrs[0]) + 1, int.Parse(gridSizeStrs[1]) + 1);

            List<Ship> ships = new List<Ship>();
            int shipCount = filteredInput.Length / 2;
            string[] output = new string[shipCount];
            for (int shipNum = 0; shipNum < shipCount; shipNum++)
            {
                Ship ship = shipFromString(filteredInput[shipNum * 2 + 1], ocean);
                ships.Add(ship);
                string shipMoves = filteredInput[shipNum * 2 + 2];
                foreach (char move in shipMoves)
                {
                    Movement movement = MovementExtentions.FromChar(move);
                    ship.DoMovement(movement);
                }

                output[shipNum] = ship.ToString();
            }

            return output;
        }

        /// <summary>
        /// Filter the input, removing any blank lines.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string[] filterInput(string[] input)
        {
            return input.Where((_, lineNum) => (lineNum == 0) || (lineNum % 3 != 0)).ToArray();
        }

        /// <summary>
        /// Returns a ship from its input string.
        /// </summary>
        /// <returns></returns>
        private static Ship shipFromString(string shipStr, Ocean ocean)
        {
            // Split with null argument splits by whitespace.
            string[] splitStr = shipStr.Split(null);
            Coords initialPosition = new Coords(int.Parse(splitStr[0]), int.Parse(splitStr[1]));
            return new Ship(initialPosition, OrientationExtentions.FromString(splitStr[2]), ocean);
        }
    }
}
