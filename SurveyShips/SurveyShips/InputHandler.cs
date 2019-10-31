using System;
using System.Collections.Generic;
using System.Text;

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
            for (int shipIdx = 0; shipIdx < shipCount; shipIdx++)
            {
                Ship ship = shipFromString(filteredInput[shipIdx * 2 + 1], ocean);
                ships.Add(ship);
                string shipMoves = filteredInput[shipIdx * 2 + 2];
                foreach (char move in shipMoves)
                {
                    Movement movement = MovementExtentions.FromChar(move);
                    ship.DoMovement(movement);
                }

                output[shipIdx] = ship.ToString();
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
            List<string> filteredInput = new List<string>();

            foreach (string line in input)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    filteredInput.Add(line);
                }
            }

            return filteredInput.ToArray();
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
