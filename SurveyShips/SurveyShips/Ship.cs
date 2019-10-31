using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyShips
{
    /// <summary>
    /// Class representing a ship with a position and orientation.
    /// </summary>
    public class Ship
    {
        public Coords CurrentPosition { get; private set; }
        public Orientation CurrentOrientation { get; private set; }

        private Ocean _ocean;

        private bool _lost = false;

        public Ship(Coords initialCoords, Orientation intitialOrientation, Ocean ocean)
        {
            CurrentPosition = initialCoords;
            CurrentOrientation = intitialOrientation;
            _ocean = ocean;
        }

        /// <summary>
        /// Process a movement.
        /// </summary>
        /// <param name="movement"></param>
        public void DoMovement(Movement movement)
        {
            switch (movement)
            {
                case Movement.Forward:
                    tryForwardMovement();
                    break;

                case Movement.Right:
                    CurrentOrientation = CurrentOrientation.TurnRight();
                    break;

                case Movement.Left:
                    CurrentOrientation = CurrentOrientation.TurnLeft();
                    break;
            }
        }

        /// <summary>
        /// Returns a string representing the current position and orientation of the ship and
        /// whether it's lost.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = string.Format("{0} {1} {2}",
                                          CurrentPosition.XCoord,
                                          CurrentPosition.YCoord,
                                          CurrentOrientation.GetString());
            if (_lost)
            {
                output += " LOST";
            }
            return output;
        }

        /// <summary>
        /// Try to move forward.
        /// </summary>
        private void tryForwardMovement()
        {
            if (_lost)
            {
                // Ship is already lost, don't move forward.
                return;
            }

            Coords newPos = CurrentPosition;

            switch (CurrentOrientation)
            {
                case Orientation.North:
                    newPos = new Coords(CurrentPosition.XCoord, CurrentPosition.YCoord + 1);
                    break;

                case Orientation.East:
                    newPos = new Coords(CurrentPosition.XCoord + 1, CurrentPosition.YCoord);
                    break;

                case Orientation.South:
                    newPos = new Coords(CurrentPosition.XCoord, CurrentPosition.YCoord - 1);
                    break;

                case Orientation.West:
                    newPos = new Coords(CurrentPosition.XCoord - 1, CurrentPosition.YCoord);
                    break;
            }

            Ocean.MovementResult res = _ocean.TryMove(CurrentPosition, newPos);

            if (res == Ocean.MovementResult.Lost)
            {
                _lost = true;
                _ocean.AddWarning(CurrentPosition);
            }
            else if (res == Ocean.MovementResult.Warning)
            {
                // Ship has received warning not to move. Nothing to do.
            }
            else
            {
                // Ship succeeded in moving, update position.
                CurrentPosition = newPos;
            }
        }
    }
}
