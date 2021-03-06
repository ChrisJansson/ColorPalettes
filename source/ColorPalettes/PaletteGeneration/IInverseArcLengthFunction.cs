﻿using ColorPalettes.Math;

namespace ColorPalettes.PaletteGeneration
{
    public interface IInverseArcLengthFunction
    {
        double Calculate(double d, int numberOfColors, int lineSegments, IBezierCurve curve);
    }
}