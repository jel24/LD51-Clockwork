using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastCard_Wolf : BeastCard
{

    public override void Play()
    {
        Beast newBeast = Instantiate(beastPrefab, monsterParent, true).GetComponent<Beast>();
        int whichSpace = Random.Range(0, 5);
        int maxLoop = 0;
        while (boardManager.boardSpaces[whichSpace].GetBeastOccupant() != null){
            whichSpace = Random.Range(0, 5);
            maxLoop++;
            if (maxLoop >= 50)
            {
                boardManager.boardSpaces[whichSpace].GetBeastOccupant().Die();
                break;
            }
        }
        boardManager.boardSpaces[whichSpace].SetBeastOccupant(newBeast, false);
        PlayFX(boardManager.boardSpaces[whichSpace]);
        Invoke("CleanUp", 1f);
    }

    public override void PlayFX(BoardSpace b)
    {

    }
}
