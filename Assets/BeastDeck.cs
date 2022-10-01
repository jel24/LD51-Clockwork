using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastDeck : MonoBehaviour
{
    BeastCard[] allCards;
    Queue<BeastCard> deckCards;

    void Start()
    {
        allCards = GetComponentsInChildren<BeastCard>();
        deckCards = new Queue<BeastCard>();
        for (int i = 0; i < allCards.Length; i++)
        {
            deckCards.Enqueue(allCards[i]);
            allCards[i].transform.localPosition = new Vector3(0f, .1f * i, 0f);
            allCards[i].transform.localEulerAngles = new Vector3(90f, 0f, 0f);

        }
    }

    public void DrawCard()
    {
        deckCards.Dequeue().Play();
    }
}
