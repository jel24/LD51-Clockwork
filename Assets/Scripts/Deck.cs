using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    Card[] allCards;
    Queue<Card> deckCards;

    [SerializeField] Hand hand;
    [SerializeField] TriggeredEvent gameOverEvent;

    void Start()
    {
        allCards = GetComponentsInChildren<Card>();
        for (int i = 0; i < allCards.Length; i++)
        {
            allCards[i].transform.SetSiblingIndex(Random.Range(0, allCards.Length));
        }
        allCards = GetComponentsInChildren<Card>();

        deckCards = new Queue<Card>();
        for (int i = 0; i < allCards.Length; i++)
        {
            deckCards.Enqueue(allCards[i]);
            allCards[i].transform.localPosition = new Vector3(0f, .05f * i, 0f);
            allCards[i].transform.localEulerAngles = new Vector3(90f, 0f, 0f);

        }
    }

    public void DrawCard()
    {
        if (deckCards.Count == 0)
        {
            gameOverEvent.Trigger();
        } else
        {
            hand.AddCard(deckCards.Dequeue());
        }
    }

    public void Shuffle()
    {
        
    }


}
