﻿using ColorPalettes.Math;
using ColorPalettes.Services;

namespace ColorPalettes.PaletteGeneration
{
    public class ArcLengthCalculator : IArcLengthCalculator
    {
        private readonly ILuvDistanceCalculator _distanceCalculator;
        private readonly IVectorToLuvConverter _vectorToLuvConverter;

        public ArcLengthCalculator(ILuvDistanceCalculator distanceCalculator, IVectorToLuvConverter vectorToLuvConverter)
        {
            _distanceCalculator = distanceCalculator;
            _vectorToLuvConverter = vectorToLuvConverter;
        }

        public double Calculate(int index, int lineSegments, IBezierCurve curve)
        {
            double sum = 0;
            for (var i = 0; i < index; i++)
            {
                var fraction1 = ((double) i)/lineSegments;
                var b0 = curve.Calculate(fraction1);

                var fraction2 = ((double) (i + 1))/lineSegments;
                var b1 = curve.Calculate(fraction2);

                var l0 = _vectorToLuvConverter.Convert(b0);
                var l1 = _vectorToLuvConverter.Convert(b1);

                sum += _distanceCalculator.CalculateDistance(l0, l1);
            }

            return sum;
        }
    }
}