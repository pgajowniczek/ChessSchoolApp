using ChessSchoolApp.Entities;
using System.Text;

public class Ranking : EntityBase
{
    public int StudentId { get; set; }

    public int MatchesPlayed { get; set; }

    public int Wins { get; set; }

    public int Losses { get; set; }

    public int Draws { get; set; }

    public double Points { get; set; }

    #region ToString method Override
    public override string ToString()
    {
        StringBuilder sb = new(1024);
        sb.AppendLine($"{StudentId} has played {MatchesPlayed} games");
        sb.AppendLine($"{Wins} Wins, {Draws} Draws, {Losses} Losses");
        sb.AppendLine($"Current ranking: {Points}");
        return sb.ToString();
    }
    #endregion
}
