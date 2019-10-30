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

            return new string[0];
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
    }
}
