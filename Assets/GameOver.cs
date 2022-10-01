using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    [SerializeField] float howLongBeforeNewGame;

    void Start()
    {
        StartCoroutine("Reload");
    }

    IEnumerable Reload()
    {
        float timer = 0f;
        while (timer < howLongBeforeNewGame)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene("Main");
    }
}
