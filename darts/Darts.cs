public static class Darts
{
    public static int Score(double x, double y)
    {
        double xSquared = Math.Pow(x, 2);
        double ySquared = Math.Pow(y, 2);
        double radius = Math.Sqrt(xSquared + ySquared);
        if (radius >= -1.0 && radius <= 1.0)
        {
            return 10;
        }
        if (radius >= -5.0 && radius <= 5.0)
        {
            return 5;
        }
        if (radius >= -10.0 && radius <= 10.0)
        {
            return 1;
        }
        return 0;
    }
}
