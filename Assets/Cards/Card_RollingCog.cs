using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_RollingCog : Card
{
    [SerializeField] int damage = 6;
    
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
        cardDescriptionDisplay.text = "Damages all Beasts in a column by " + damage * power + ".";

    }

    public override void PlayFX(BoardSpace b)
    {
        spellFX.transform.position = b.transform.position;
        spellFX.transform.eulerAngles = Vector3.zero;
        spellFX.Play();

    }
}
