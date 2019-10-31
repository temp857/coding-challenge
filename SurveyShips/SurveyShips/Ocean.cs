using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyShips
{
    /// <summary>
    /// The ocean. Potentially could make this a singleton but they tend to be controversial...
    /// </summary>
    public class Ocean
    {
        private int _xSize;
        private int _ySize;

        private List<Coords> _warnings = new List<Coords>();

        public Ocean(int xSize, int ySize)
        {
            _xSize = xSize;
            _ySize = ySize;
        }

        /// <summary>
        /// Result of trying to move in the ocean.
        /// </summary>
        public enum MovementResult
        {
            Success,
            Lost,
            Warning
        }

        /// <summary>
        /// Ship tries to move in the ocean.
        /// </summary>
        /// <param name="prevPosition"></param>
        /// <param name="newPosition"></param>
        /// <returns></returns>
        public MovementResult TryMove(Coords prevPosition, Coords newPosition)
        {
            MovementResult result = MovementResult.Success;

            if ((newPosition.XCoord < 0) ||
                (newPosition.XCoord >= _xSize) ||
                (newPosition.YCoord < 0) ||
                (newPosition.YCoord >= _ySize))
            {
                if (_warnings.Contains(prevPosition))
                {
                    result = MovementResult.Warning;
                }
                else
                {
                    result = MovementResult.Lost;
                }
            }

            return result;
        }

        /// <summary>
        /// Add a warning in the ocean.
        /// </summary>
        /// <param name="warning"></param>
        public void AddWarning(Coords warning)
        {
            if (!_warnings.Contains(warning))
            {
                _warnings.Add(warning);
            }
        }
    }
}
