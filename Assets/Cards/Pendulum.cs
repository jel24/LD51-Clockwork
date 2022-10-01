using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : Card
{
    [SerializeField] int damage = 5;
    
    public override void IncrementPower()
    {
        base.IncrementPower();
    }

    public override void TargetsFound(List<GameObject> objects)
    {
        foreach(GameObject g in objects)
        {
            Beast b = g.GetComponent<Beast>();
            if (b) b.TakeDamage(damage * power);
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
        cardDescriptionDisplay.text = "Damages all Beasts in a row by " + 5 * power + ".";

    }

    public override void PlayFX(BoardSpace b)
    {

    }
}