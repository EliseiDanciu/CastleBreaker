using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public static int LastLevelIndex { get; set; }


    public void LoadLevel(string name)
    {
        BrickController.brickCount = 0;
        System.Threading.Thread.Sleep(500);
        SceneManager.LoadScene(name);
    }

    public void ReplayLevel()
    {
        BrickController.brickCount = 0;
        SceneManager.LoadScene(LastLevelIndex);
    }


    public void LoadNextLevel()
    {
        BrickController.brickCount = 0;
        LastLevelIndex = SceneManager.GetActiveScene().buildIndex;

        System.Threading.Thread.Sleep(500);

        //if it's last level load the game finished scene
        //else load next level
        if (LastLevelIndex + 1 >= SceneManager.sceneCountInBuildSettings) 
        {
            SceneManager.LoadScene("GameFinished");
        }
        else
        {
            SceneManager.LoadScene(LastLevelIndex + 1);
        }
    }


    public void QuitRequest()
    {
        Application.Quit();
    }

    public void BrickDestroyed()
    {
        if (BrickController.brickCount <= 0)
        {
            LoadNextLevel();
        }
    }
}
