using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{

    Card[] allCards;
    Queue<Card> deckCards;

    [SerializeField] Hand hand;


    void Start()
    {
        allCards = GetComponentsInChildren<Card>();
        deckCards = new Queue<Card>();
        for (int i = 0; i < allCards.Length; i++)
        {
            deckCards.Enqueue(allCards[i]);
            allCards[i].transform.localPosition = new Vector3(0f, .1f * i, 0f);
            allCards[i].transform.localEulerAngles = new Vector3(90f, 0f, 0f);

        }
    }

    public void DrawCard()
    {
        hand.AddCard(deckCards.Dequeue());
    }

    public void Shuffle()
    {
        
    }


}