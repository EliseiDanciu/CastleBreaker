using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour {
    

    void OnTriggerEnter2D(Collider2D collider)
    {
        LevelManager.LastLevelIndex = SceneManager.GetActiveScene().buildIndex;
        System.Threading.Thread.Sleep(500);
        SceneManager.LoadScene("GameOver");
    }

}
