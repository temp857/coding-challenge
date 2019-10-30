using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyShips
{
    internal class Ship
    {
        private Coords _position;
        private Orientation _orientation;

        public Ship(Coords initialCoords, Orientation intitialOrientation)
        {
            _position = initialCoords;
            _orientation = intitialOrientation;
        }
    }
}
