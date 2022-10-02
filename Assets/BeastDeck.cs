using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeastDeck : MonoBehaviour
{
    BeastCard[] allCards;
    Queue<BeastCard> deckCards;

    [SerializeField] TextMeshProUGUI counter;
    [SerializeField] TriggeredEvent victoryEvent;

    void Start()
    {
        allCards = GetComponentsInChildren<BeastCard>();
        deckCards = new Queue<BeastCard>();
        for (int i = 0; i < allCards.Length; i++)
        {
            deckCards.Enqueue(allCards[i]);
            allCards[i].transform.localPosition = new Vector3(0f, .05f * i, 0f);
            allCards[i].transform.localEulerAngles = new Vector3(90f, 0f, 0f);

        }
        counter.text = deckCards.Count.ToString();

    }

    public void DrawCard()
    {
        deckCards.Dequeue().Play();
        counter.text = deckCards.Count.ToString();
        if (deckCards.Count == 0)
        {
            victoryEvent.Trigger();
        }
    }
}
