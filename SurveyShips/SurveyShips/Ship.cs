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

        private void tryForwardMovement()
        {
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

            Ocean.MovementResult res = _ocean.TryMove(newPos);
        }
    }
}
