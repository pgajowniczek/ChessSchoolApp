using ChessSchoolApp.Repositories;

public class RankingProvider : IRankingProvider
{
    private readonly IRepository<Ranking> _rankingRepository;
    public RankingProvider(IRepository<Ranking> rankingRepository)
    {
        _rankingRepository = rankingRepository;
    }
    public List<Ranking> FilterRankings(double minPoints)
    {
        var rankings = _rankingRepository.GetAll();
        var higherThanProvided = rankings.Where(x => x.Points > minPoints).ToList();
        return higherThanProvided;
    }

    public double GetHighestWinRate()
    {
        var rankings = _rankingRepository.GetAll();
        var highestWinRate = rankings.Where(x => x.MatchesPlayed > 0 && x.Wins > 0).Select(x => x.Wins / x.MatchesPlayed).Max();
        return highestWinRate;

    }

    public double GetMaxPointsValue()
    {
        var rankings = _rankingRepository.GetAll();
        var maxPoints = rankings.Select(x => x.Points).Max();
        return maxPoints;
    }

    public double GetMinPointsValue()
    {
        var rankings = _rankingRepository.GetAll();
        var minPoints = rankings.Select(x => x.Points).Min();
        return minPoints;
    }

    public List<Ranking> OrderByMatchesPlayed()
    {
        var rankings = _rankingRepository.GetAll();
        return rankings.OrderBy(x => x.MatchesPlayed).ToList();
    }

    public List<Ranking> OrderByPoints()
    {
        var rankings = _rankingRepository.GetAll();
        return rankings.OrderBy(x => x.Points).ToList();
    }

    public List<Ranking> OrderByWins()
    {
        var rankings = _rankingRepository.GetAll();
        return rankings.OrderBy(x => x.Wins).ToList();
    }
}
