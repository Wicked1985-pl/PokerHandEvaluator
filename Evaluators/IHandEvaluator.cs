using PokerHandEvaluator.Models;

namespace PokerHandEvaluator.Evaluators
{
    public interface IHandEvaluator
    {
        HandRanking Evaluate(Hand playerHand, List<Card> communityCards);
    }
}
