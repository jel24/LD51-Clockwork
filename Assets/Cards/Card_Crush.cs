using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Crush : Card
{
    [SerializeField] int damage = 10;
    
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
                Beast b = space.GetBeastOccupant();
                if (b) b.TakeDamage(damage * power);
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
        cardDescriptionDisplay.text = "Damages a single Beast by " + damage * power + ".";

    }

    public override void PlayFX(BoardSpace b)
    {
        spellFX.transform.position = b.transform.position;
        spellFX.transform.eulerAngles = Vector3.zero;
        spellFX.Play();

    }
}
