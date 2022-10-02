using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_Repair : Card
{
    [SerializeField] int damage = 5;
    
    public override void IncrementPower()
    {
        base.IncrementPower();
    }

    public override void TargetsFound(List<GameObject> objects)
    {
        playSound.Play();

        foreach (GameObject g in objects)
        {
            Minion b = g.GetComponent<Minion>();
            if (b) b.Heal(damage * power);

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
        cardDescriptionDisplay.text = "Grants " + damage * power + " bonus health to all Minions in a row.";

    }

    public override void PlayFX(BoardSpace b)
    {

    }
}
