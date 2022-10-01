using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public Card[] cardsInHand;
    public Vector3[] cardPositions;
    public Vector3[] cardRotations;


    void Start()
    {
        cardsInHand = new Card[6];    
    }

    public void AddCard(Card c)
    {
        c.transform.parent = transform;
        c.CardInHand(true);
        AdvanceCardPosition(1);
        cardsInHand[0] = c;
        SetCardTransformPositions();
    }

    void AdvanceCardPosition(int whichIndex)
    {
        if (whichIndex == 5)
        {
            DestroyCard(4);
        } else if (cardsInHand[whichIndex] && !cardsInHand[whichIndex].IsMarkedForDeletion())
        {
            AdvanceCardPosition(whichIndex + 1);
            cardsInHand[whichIndex] = cardsInHand[whichIndex - 1];

        }
        else
        {
            cardsInHand[whichIndex] = cardsInHand[whichIndex - 1];

        }

    }

    void SetCardTransformPositions()
    {
        for (int i = 0; i < 5; i++)
        {
            if (cardsInHand[i])
            {
                cardsInHand[i].transform.position = cardPositions[i];
                cardsInHand[i].transform.eulerAngles = cardRotations[i];
            }
        }
    }


    void DestroyCard(int whichIndex)
    {
        cardsInHand[whichIndex].transform.position = cardPositions[5];
        cardsInHand[whichIndex].transform.eulerAngles = cardRotations[5];
        cardsInHand[whichIndex].CardInHand(false);
        cardsInHand[whichIndex].Burn();
        cardsInHand[whichIndex] = null;
    }


}
