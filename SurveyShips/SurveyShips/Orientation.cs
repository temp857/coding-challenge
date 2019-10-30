using System;

namespace SurveyShips
{
    public struct Coords
    {
        int XCoord;
        int YCoord;

        public Coords(int x, int y)
        {
            XCoord = x;
            YCoord = y;
        }
    }

    public enum Orientation
    {
        North,
        South,
        East,
        West
    }

    public class OrientationExtentions
    {
        /// <summary>
        /// Returns the orientation from a string.
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        public static Orientation FromString(string orientationStr)
        {
            Orientation orientation;

            switch (orientationStr)
            {
                case "N":
                    orientation = Orientation.North;
                    break;

                case "S":
                    orientation = Orientation.South;
                    break;

                case "E":
                    orientation = Orientation.East;
                    break;

                case "W":
                    orientation = Orientation.West;
                    break;

                default:
                    throw new ArgumentException();
            }

            return orientation;
        }
    }
}
