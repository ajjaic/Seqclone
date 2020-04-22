using System;
using UnityEngine;
using Xyaneon.Games.Cards.StandardPlayingCards;

namespace Sequence
{
    [CreateAssetMenu(fileName = "CardMap", menuName = "CardMap", order = 0)]
    public class CardSuitNRankToPrefab : ScriptableObject
    {
        [SerializeField] private GameObject[] clubs = new GameObject[13];
        [SerializeField] private GameObject[] diamonds = new GameObject[13];
        [SerializeField] private GameObject[] hearts = new GameObject[13];
        [SerializeField] private GameObject[] spades = new GameObject[13];

        public GameObject GetCard(Suit suit, Rank rank)
        {
            switch (suit)
            {
                case Suit.Clubs:
                    return RankHandler(clubs);
                case Suit.Diamonds:
                    return RankHandler(diamonds);
                case Suit.Hearts:
                    return RankHandler(hearts);
                case Suit.Spades:
                    return RankHandler(spades);
                default:
                    throw new ArgumentOutOfRangeException(nameof(suit), suit, "Invalid card suit");
            }

            GameObject RankHandler(GameObject[] cardSuitSet)
            {
                switch (rank)
                {
                    case Rank.Ace:
                        return cardSuitSet[0];
                    case Rank.Two:
                        return cardSuitSet[1];
                    case Rank.Three:
                        return cardSuitSet[2];
                    case Rank.Four:
                        return cardSuitSet[3];
                    case Rank.Five:
                        return cardSuitSet[4];
                    case Rank.Six:
                        return cardSuitSet[5];
                    case Rank.Seven:
                        return cardSuitSet[6];
                    case Rank.Eight:
                        return cardSuitSet[7];
                    case Rank.Nine:
                        return cardSuitSet[8];
                    case Rank.Ten:
                        return cardSuitSet[9];
                    case Rank.Jack:
                        return cardSuitSet[10];
                    case Rank.Queen:
                        return cardSuitSet[11];
                    case Rank.King:
                        return cardSuitSet[12];
                    default:
                        throw new ArgumentOutOfRangeException(nameof(rank), rank, "Invalid card rank");
                }
            }
        }
    }
}