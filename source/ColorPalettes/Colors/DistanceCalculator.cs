﻿namespace ColorPalettes.Colors
{
    public interface ILuvDistanceCalculator
    {
        double CalculateDifference(Luv c0, Luv c1);
    }

    public class DistanceCalculator : ILuvDistanceCalculator
    {
        public double CalculateDifference(Luv c0, Luv c1)
        {
            var over = 125 - c1.L;
            var below = 125 - c0.L;

            var log = System.Math.Log(over/below);
            return System.Math.Abs(log);
        }
    }
}