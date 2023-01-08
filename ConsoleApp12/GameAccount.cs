namespace Program;

public class GameAccount
{
    public string UserName { get; set; }
    public int GamesCount { get; }


    public GameAccount(string userName)
    {
        UserName = userName;
        GamesCount = 0;
    }

    public int GameId
    {
        get
        {
            int gameId = 1;
            foreach (var t in allOperations)
            {
                gameId += t.GameId;
            }

            return gameId;
        }
    }


    public virtual void WinGame(string opponentName, Game game)
    {
        var winGame = new Operation("Win", opponentName, 1);
        allOperations.Add(winGame);
    }

    public void DrawGame(string opponentName, Game game)
    {
        var drawGame = new Operation("Draw", opponentName, 1);
        allOperations.Add(drawGame);
    }

    public void LoseGame(string opponentName, Game game)
    {
        var loseGame = new Operation("Lose", opponentName, 1);
        allOperations.Add(loseGame);
    }

    public string GetStats()
    {
        var rep = new System.Text.StringBuilder();
        int gameId = 0;

        rep.AppendLine("|Player|\t\t|Status|\t|OpponentName|\t|GameId|");
        foreach (var t in allOperations)
        {
            gameId += t.GameId;
            rep.AppendLine(
                $"|{UserName}|\t\t|{t.Status}|\t\t|{t.OpponentName}|\t\t|{gameId}|");
        }

        return rep.ToString();
    }


    public List<Operation> allOperations = new List<Operation>();
}