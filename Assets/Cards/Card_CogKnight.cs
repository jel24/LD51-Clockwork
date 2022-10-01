using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_CogKnight : Card
{
    [SerializeField] GameObject minionPrefab;
    [SerializeField] Transform monsterParent;

    public override void IncrementPower()
    {
        base.IncrementPower();
    }

    public override void TargetsFound(List<GameObject> objects)
    {
        foreach (GameObject g in objects)
        {
            BoardSpace space = g.GetComponent<BoardSpace>();
            if (space)
            {
                Minion newMinion = Instantiate(minionPrefab, monsterParent, true).GetComponent<Minion>();
                newMinion.OnPlayEffect(power);
                space.SetMinionOccupant(newMinion);
                PlayFX(space);
            }

        }
        Burn();
    }

    public override void Play()
    {
        if (isPlayable)
        {
            mouseManager.ToggleBoardTarget(targetType, this);
        }
    }

    protected override void UpdateDescription()
    {
        cardDescriptionDisplay.text = "Summons a level " + power + " Cog Knight at a space of your choosing.";

    }

    public override void PlayFX(BoardSpace b)
    {

    }
}
