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

        public Ocean(int xSize, int ySize)
        {
            _xSize = xSize;
            _ySize = ySize;
        }

        public enum MovementResult
        {
            Success,
            Lost,
            Warning
        }

        public MovementResult TryMove(Coords position)
        {
            return MovementResult.Success;
        }
    }
}
