namespace Program;

public abstract class Game
{
    public readonly GameAccount PlayerOne;
    public readonly GameAccount PlayerTwo;


    protected Game(GameAccount p1, GameAccount p2)
    {
        PlayerOne = p1;
        PlayerTwo = p2;
    }
    public abstract void Process();
}