using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneLoader : MonoBehaviour
{
    public void GameOver()
    {
        Invoke("LoadGameOver", 1f);

    }

    public void Victory()
    {
        Invoke("LoadVictory", 1f);

    }

    void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");

    }

    void LoadVictory()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Victory");

    }
}
