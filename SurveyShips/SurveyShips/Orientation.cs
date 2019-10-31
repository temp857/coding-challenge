﻿using System;

namespace SurveyShips
{
    public struct Coords : IEquatable<Coords>
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public Coords(int x, int y)
        {
            XCoord = x;
            YCoord = y;
        }

        public bool Equals(Coords other)
        {
            if ((this.XCoord == other.XCoord) && (this.YCoord == other.YCoord))
            {
                return true;
            }

            return false;
        }
    }

    public enum Orientation
    {
        North,
        South,
        East,
        West
    }

    public static class OrientationExtentions
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

        public static string ToString(this Orientation orientation)
        {
            string returnStr = string.Empty;

            switch (orientation)
            {
                case Orientation.North:
                    returnStr = "N";
                    break;

                case Orientation.East:
                    returnStr = "E";
                    break;

                case Orientation.South:
                    returnStr = "S";
                    break;

                case Orientation.West:
                    returnStr = "W";
                    break;
            }

            return returnStr;
        }

        public static Orientation TurnRight(this Orientation orientation)
        {
            Orientation newOrientation = Orientation.North;

            switch (orientation)
            {
                case Orientation.North:
                    newOrientation = Orientation.East;
                    break;

                case Orientation.East:
                    newOrientation = Orientation.South;
                    break;

                case Orientation.South:
                    newOrientation = Orientation.West;
                    break;

                case Orientation.West:
                    newOrientation = Orientation.North;
                    break;
            }

            return newOrientation;
        }

        public static Orientation TurnLeft(this Orientation orientation)
        {
            Orientation newOrientation = Orientation.North;

            switch (orientation)
            {
                case Orientation.North:
                    newOrientation = Orientation.West;
                    break;

                case Orientation.East:
                    newOrientation = Orientation.North;
                    break;

                case Orientation.South:
                    newOrientation = Orientation.East;
                    break;

                case Orientation.West:
                    newOrientation = Orientation.South;
                    break;
            }

            return newOrientation;
        }
    }

    public enum Movement
    {
        Forward,
        Right,
        Left,
    }

    public static class MovementExtentions
    {
        /// <summary>
        /// Returns the orientation from a string.
        /// </summary>
        /// <param name="movementChar"></param>
        /// <returns></returns>
        public static Movement FromChar(char movementChar)
        {
            Movement movement;

            switch (movementChar)
            {
                case 'F':
                    movement = Movement.Forward;
                    break;

                case 'R':
                    movement = Movement.Right;
                    break;

                case 'L':
                    movement = Movement.Left;
                    break;

                default:
                    throw new ArgumentException();
            }

            return movement;
        }
    }
}
