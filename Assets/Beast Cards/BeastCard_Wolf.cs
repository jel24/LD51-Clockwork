using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastCard_Wolf : BeastCard
{

    public override void Play()
    {
        Beast newBeast = Instantiate(beastPrefab, monsterParent, true).GetComponent<Beast>();
        int whichSpace = Random.Range(0, 4);
        boardManager.boardSpaces[whichSpace].SetBeastOccupant(newBeast, false);
        PlayFX(boardManager.boardSpaces[whichSpace]);
        Invoke("CleanUp", 1f);
    }

    public override void PlayFX(BoardSpace b)
    {

    }
}
