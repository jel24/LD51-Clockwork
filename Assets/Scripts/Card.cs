using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{

    [SerializeField] string cardName;
    [SerializeField] string cardDescription;
    [SerializeField] TextMeshPro cardNameDisplay;
    [SerializeField] TextMeshPro cardDescriptionDisplay;
    [SerializeField] TextMeshPro powerDisplay;
    [SerializeField] ParticleSystem burnFX;
    [SerializeField] ParticleSystem hoverFX;

    protected int power = 0;
    protected bool isPlayable = false;

    public void Burn()
    {
        burnFX.Play();
        Invoke("CleanUp", 1f);
    }


    void CleanUp()
    {
        Destroy(gameObject);
    }

    public virtual void Play()
    {
        if (isPlayable)
        {

        }
    }

    public void Hover()
    {
        if (isPlayable) hoverFX.Play();
    }

    public void CardInHand(bool trueFalse)
    {
        isPlayable = trueFalse;
        cardNameDisplay.text = cardName;
        cardDescriptionDisplay.text = cardDescription;
        powerDisplay.text = power.ToString();
    }

    public virtual void IncrementPower()
    {
        if (isPlayable)
        {
            power++;
            powerDisplay.text = power.ToString();
        }
    }

}
