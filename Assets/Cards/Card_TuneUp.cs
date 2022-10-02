using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_TuneUp : Card
{

    [SerializeField] Hand hand;

    public override void IncrementPower()
    {
        base.IncrementPower();
    }

    public override void Play()
    {
        if (isPlayable)
        {
            foreach (Card c in hand.cardsInHand)
            {
                if (c != null && c != this)
                {
                    for (int i = 0; i < power; i++)
                    {
                        c.IncrementPower();
                    }
                }
            }
            Burn();
        }
    }

    protected override void UpdateDescription()
    {
        cardDescriptionDisplay.text = "Increases Power value of all other cards in hand by " + power + ".";

    }

    public override void PlayFX(BoardSpace b)
    {

    }
}
