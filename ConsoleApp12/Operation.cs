namespace Program;

public class Operation
{
    public string Status { get; }
    public string OpponentName { get; }
    public int GameId { get; }

    public Operation(string status, string opponentName, int gameIndex)
    {
        Status = status;
        OpponentName = opponentName;
        GameId = gameIndex;
    }

    public Operation()
    {
        
    }


    public bool CheckWin(string[] pos)
    {
        if (pos[1] == "O" && pos[2] == "O" && pos[3] == "O")
        {
            return true;
        }

        if (pos[4] == "O" && pos[5] == "O" && pos[6] == "O")
        {
            return true;
        }

        if (pos[7] == "O" && pos[8] == "O" && pos[9] == "O")
        {
            return true;
        }

        if (pos[1] == "O" && pos[5] == "O" && pos[9] == "O")
        {
            return true;
        }

        if (pos[7] == "O" && pos[5] == "O" && pos[3] == "O")
        {
            return true;
        }

        if (pos[1] == "O" && pos[4] == "O" && pos[7] == "O")
        {
            return true;
        }

        if (pos[2] == "O" && pos[5] == "O" && pos[8] == "O")
        {
            return true;
        }

        if (pos[3] == "O" && pos[6] == "O" && pos[9] == "O")
        {
            return true;
        }

        if (pos[1] == "X" && pos[2] == "X" && pos[3] == "X")
        {
            return true;
        }

        if (pos[4] == "X" && pos[5] == "X" && pos[6] == "X")
        {
            return true;
        }

        if (pos[7] == "X" && pos[8] == "X" && pos[9] == "X")
        {
            return true;
        }

        if (pos[1] == "X" && pos[5] == "X" && pos[9] == "X")
        {
            return true;
        }

        if (pos[7] == "X" && pos[5] == "X" && pos[3] == "X")
        {
            return true;
        }

        if (pos[1] == "X" && pos[4] == "X" && pos[7] == "X")
        {
            return true;
        }

        if (pos[2] == "X" && pos[5] == "X" && pos[8] == "X")
        {
            return true;
        }

        if (pos[3] == "X" && pos[6] == "X" && pos[9] == "X")
        {
            return true;
        }

        return false;
    }
}