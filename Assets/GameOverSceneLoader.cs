using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneLoader : MonoBehaviour
{
    public void GameOver()
    {
        SceneManager.LoadScene("Game Over");
    }

    public void Victory()
    {
        SceneManager.LoadScene("Victory");

    }
}
