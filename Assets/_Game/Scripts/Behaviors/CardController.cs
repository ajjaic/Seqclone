using System;
using System.Collections;
using System.Collections.Generic;
using Sequence.Player;
using UnityEngine;
using Xyaneon.Games.Cards.StandardPlayingCards;

public class CardController : MonoBehaviour
{
    private StandardPlayingCard _card;
    private CardHandController _cardHandController;

    // messages
    private void OnMouseDown()
    {
        _cardHandController.OnCardClicked(this);
    }

    // API
    public void SetStandardPlayingCard(StandardPlayingCard standardPlayingCard) => _card = standardPlayingCard;
    public void SetCardHandController(CardHandController cardHandController) => _cardHandController = cardHandController;
}
