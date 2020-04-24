using System;
using System.Collections;
using System.Collections.Generic;
using Sequence;
using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    // messages
    private void ShowChosenPlayer(int indexOfChildToShow)
    {
        foreach (Transform player in transform)
        {
            var indexUnderParent = player.GetSiblingIndex();
            if (indexUnderParent == indexOfChildToShow)
                transform.GetChild(indexOfChildToShow).GetComponent<SelfHider>().Show();
            else
                transform.GetChild(indexUnderParent).GetComponent<SelfHider>().Hide();
        }
    }

    // public messages
    public void ShowPlayer(int playerNum)
    {
        switch (playerNum)
        {
            case 0:
                ShowChosenPlayer(0);
                break;
            case 1:
                ShowChosenPlayer(1);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(playerNum), playerNum, "Player does not exist");
        }
    }
}
