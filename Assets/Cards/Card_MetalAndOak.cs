using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card_MetalAndOak : Card_CogKnight
{
    protected override void UpdateDescription()
    {
        cardDescriptionDisplay.text = "Summons a level " + power + " Barrier at a space of your choosing.";

    }
}
