# Poker Hand Evaluator

A C# 8 library for evaluating and simulating poker hands in Texas Hold'em and PLO4 (4-card Omaha).

## Features

- **Multiple Game Types**: Support for Texas Hold'em and PLO4
- **Flexible Input**: Evaluate hands from pre-flop through turn/river
- **Hand Simulation**: Run multiple simulations to determine win/tie outcomes
- **Proper Hand Rules**: 
  - Texas Hold'em: Best 5 cards from 7 total
  - PLO4: Exactly 2 from hand, exactly 3 from community

## Usage

### Basic Hand Evaluation

```csharp
using PokerHandEvaluator.Models;
using PokerHandEvaluator.Simulators;

// Create hands from card notation (e.g., AsKd = Ace of spades, King of diamonds)
var playerA = Hand.Parse("AsKd");
var playerB = Hand.Parse("QhQc");
var communityCards = new List<Card> { Card.Parse("2d"), Card.Parse("3h"), Card.Parse("4s") };

// Simulate 10,000 games
var simulator = new HandSimulator(GameType.TexasHoldEm);
var result = simulator.Simulate(playerA, playerB, communityCards, 10000);

Console.WriteLine(result);
// Output: Player A Wins: 5123, Player B Wins: 4567, Ties: 310
```

### Pre-flop Simulation (no community cards)

```csharp
var playerA = Hand.Parse("AsKs");
var playerB = Hand.Parse("2h2c");
var emptyBoard = new List<Card>();

var result = simulator.Simulate(playerA, playerB, emptyBoard, 100000);
```

### Community Cards Input

```csharp
// Flop (3 cards)
var flop = new List<Card> 
{ 
    Card.Parse("As"), 
    Card.Parse("Kd"), 
    Card.Parse("Qh") 
};

// Turn (4 cards)
var turn = new List<Card> 
{ 
    Card.Parse("As"), 
    Card.Parse("Kd"), 
    Card.Parse("Qh"),
    Card.Parse("2c")
};

var result = simulator.Simulate(playerA, playerB, flop, 50000);
```

### PLO4 Example

```csharp
var playerA = Hand.Parse("AsKdQhJc");  // 4 hole cards
var playerB = Hand.Parse("2h3h4h5h");  // 4 hole cards
var flop = new List<Card> { Card.Parse("6h"), Card.Parse("7h"), Card.Parse("8h") };

var simulator = new HandSimulator(GameType.PLO4);
var result = simulator.Simulate(playerA, playerB, flop, 10000);
```

## Card Notation

Cards are represented as two characters:
- **Rank**: A (Ace), K (King), Q (Queen), J (Jack), T (Ten), 9-2
- **Suit**: s (spades), h (hearts), d (diamonds), c (clubs)

Examples: `As` (Ace of spades), `Kd` (King of diamonds), `2c` (Two of clubs)

## Hand Rankings

1. Royal Flush
2. Straight Flush
3. Four of a Kind
4. Full House
5. Flush
6. Straight
7. Three of a Kind
8. Two Pair
9. One Pair
10. High Card

## Tie Handling

When two hands have identical rankings, they are counted as ties in the simulation results.
