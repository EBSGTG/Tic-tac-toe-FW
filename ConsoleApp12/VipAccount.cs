namespace Program;

public class VipAccount : GameAccount
{
    public VipAccount(string name) : base(name)
    {
        UserName = "Vip " + UserName;
    }

    override public void WinGame(string opponentName, Game game)
    {
        var winGame = new Operation("VIPWin", opponentName, 1);
        allOperations.Add(winGame);
    }
}