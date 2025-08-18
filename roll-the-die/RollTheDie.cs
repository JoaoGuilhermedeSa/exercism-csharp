public class Player
{

    private System.Random random = new System.Random();

    public int RollDie()
    {
        return random.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
        return random.NextDouble() * 100;
    }
}
