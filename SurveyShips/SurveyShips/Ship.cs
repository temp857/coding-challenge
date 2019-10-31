using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyShips
{
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

        public override string ToString()
        {
            string output = string.Format("{0} {1} {2}",
                                          CurrentPosition.XCoord,
                                          CurrentPosition.YCoord,
                                          CurrentOrientation);
            if (_lost)
            {
                output += " LOST";
            }
            return output;
        }

        private void tryForwardMovement()
        {
            if (_lost)
            {
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
