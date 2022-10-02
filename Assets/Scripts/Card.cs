using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{

    [SerializeField] protected string cardName;
    [SerializeField] protected string cardDescription;
    [SerializeField] protected TextMeshPro cardNameDisplay;
    [SerializeField] protected TextMeshPro cardDescriptionDisplay;
    [SerializeField] protected TextMeshPro powerDisplay;
    [SerializeField] protected ParticleSystem burnFX;
    [SerializeField] protected ParticleSystem hoverFX;
    [SerializeField] protected ParticleSystem powerupFX;
    [SerializeField] protected ParticleSystem spellFX;
    [SerializeField] protected TargetType targetType;
    [SerializeField] protected MouseManager mouseManager;

    protected int power = 0;
    protected bool isPlayable = false;

    bool markedForDeletion = false;

    public void Burn()
    {
        if (!markedForDeletion)
        {
            burnFX.Play();
            markedForDeletion = true;
            //StartCoroutine("FadeOut");
            Invoke("CleanUp", 1f);
        }

    }

    IEnumerable FadeOut()
    {
        float timer = 0f;
        Material[] materials = GetComponentsInChildren<Material>();
        while (timer < 1f)
        {
            timer += Time.deltaTime;
            foreach (Material r in materials)
            {
                Color c = r.color;
                Color newColor = new Color(c.r, c.g, c.b, 1 - (timer / 1f));
                r.color = newColor;
            }
        }
        
        yield return null;
    }

    void CleanUp()
    {
        Destroy(gameObject);
    }

    public virtual void Play()
    {

    }

    public bool IsMarkedForDeletion()
    {
        return markedForDeletion;
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
            powerupFX.Play();
            UpdateDescription();
        }
    }

    protected virtual void UpdateDescription()
    {

    }

    public virtual void TargetsFound(List<GameObject> objects)
    {

    }

    public virtual void PlayFX(BoardSpace b)
    {

    }

}
