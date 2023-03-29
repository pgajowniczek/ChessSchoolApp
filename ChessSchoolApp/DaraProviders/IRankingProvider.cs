public interface IRankingProvider
{
    List<Ranking> FilterRankings(double minPoints);

    double GetMaxPointsValue();

    double GetMinPointsValue();

    double GetHighestWinRate();

    //order by

    List<Ranking> OrderByPoints();

    List<Ranking> OrderByWins();

    List<Ranking> OrderByMatchesPlayed();

}
