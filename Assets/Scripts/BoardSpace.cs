using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSpace : MonoBehaviour
{

    Beast beastOccupant;
    Minion minionOccupant;
    [SerializeField] ParticleSystem hoverFX;

    public void SetBeastOccupant(Beast b, bool smoothAnimation)
    {
        beastOccupant = b;
        if (smoothAnimation)
        {
            StartCoroutine(SmoothAnimation(b));

        } else
        {
            b.transform.position = transform.position;

        }
    }

    IEnumerator SmoothAnimation(Beast b)
    {
        float timer = 0f;
        while (timer < .875f)
        {
            timer += Time.deltaTime;
            b.transform.position = new Vector3(Mathf.Lerp(b.transform.position.x, transform.position.x, timer / 1f),
                Mathf.Lerp(b.transform.position.y, transform.position.y, timer / 1f),
                Mathf.Lerp(b.transform.position.z, transform.position.z, timer / 1f));
            yield return null;
        }
    }

    public void SetMinionOccupant(Minion m)
    {
        m.transform.position = transform.position;
        minionOccupant = m;
    }

    public void ClearBeastOccupant()
    {
        beastOccupant = null;
    }

    public void ClearMinionOccupant()
    {
        minionOccupant = null;
    }

    public Beast GetBeastOccupant()
    {
        return beastOccupant;
    }

    public Minion GetMinionOccupant()
    {
        return minionOccupant;
    }

    public void PlayHoverFX()
    {
        hoverFX.Play();
    }

}
