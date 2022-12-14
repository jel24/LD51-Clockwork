using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_SpareParts : Card
{

    [SerializeField] Deck deck;

    public override void IncrementPower()
    {
        base.IncrementPower();
        if (isPlayable)
        {
            if (power > 5) power = 5;
            UpdateDescription();
        }

    }

    public override void Play()
    {
        if (isPlayable)
        {
            for (int i = 0; i < power; i++)
            {
                deck.DrawCard();
            }
            playSound.Play();

            Burn();

        }
    }

    protected override void UpdateDescription()
    {
        cardDescriptionDisplay.text = "Draw " + power + " cards from your deck.";

    }

    public override void PlayFX(BoardSpace b)
    {

    }
}
