using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BeastCard : MonoBehaviour
{

    [SerializeField] string cardName;
    [SerializeField] string cardDescription;
    [SerializeField] protected TextMeshPro cardNameDisplay;
    [SerializeField] protected TextMeshPro cardDescriptionDisplay;
    [SerializeField] protected ParticleSystem burnFX;
    [SerializeField] protected ParticleSystem hoverFX;
    [SerializeField] protected BoardManager boardManager;
    [SerializeField] protected Transform monsterParent;
    [SerializeField] protected GameObject beastPrefab;

    public virtual void Play()
    {

    }
    public void Hover()
    {
    }

    public virtual void PlayFX(BoardSpace b)
    {

    }

    protected void CleanUp()
    {
        Destroy(gameObject);
    }

}
