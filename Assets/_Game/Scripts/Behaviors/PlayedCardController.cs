using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayedCardController : MonoBehaviour
{
    private readonly float _distanceBetweenCards = 0.4f; // TODO: should be in gamecontroller?;
    private List<CardController> _playedCards;
    [SerializeField] private Transform playedCardHand;

    // messages
    private void Start()
    {
        _playedCards = new List<CardController>();
    }

    private void UpdateCardPositions()
    {
        var cardOffset = Vector3.zero;
        foreach (var cardController in _playedCards)
        {
            cardController.transform.position = playedCardHand.position + cardOffset;
            cardOffset.x += _distanceBetweenCards;
        }
    }

    // public messages
    public void CardIsPlayed(CardController cardController)
    {
        _playedCards.Add(cardController);
        cardController.transform.parent = playedCardHand;
        UpdateCardPositions();
    }
}