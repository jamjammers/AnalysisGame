
using System;
public static class Utilities
{


    private static Random random = new Random();

    public static float Normal(double mean = 0, double stdDev = 1)
    {
        double u1 = 1.0 - random.NextDouble();
        double u2 = 1.0 - random.NextDouble();
        double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                               Math.Sin(2.0 * Math.PI * u2);
        return (float)(mean + stdDev * randStdNormal);
    }
}