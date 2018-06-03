using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    // Use this for initialization
    Vector3 playerPos;
    AudioSource ballBouncingSound;
    public bool autoPlay = false;
    BallController ball;

    void Start ()
    {
        ball = FindObjectOfType<BallController>();
        playerPos = new Vector3(0, transform.position.y, 0);
        ballBouncingSound = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (autoPlay)
        {
            AutoPlay();
        }
        else
        {
            ManualPlay();
        }
        
    }

    void AutoPlay()
    {
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16) - 8; // -8 to compensate for the center being 0
        Vector3 ballPos = ball.transform.position;
        playerPos.x = Mathf.Clamp(ballPos.x, -8f, 8f);
        transform.position = playerPos;
    }

    void ManualPlay()
    {
        float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16) - 8; // -8 to compensate for the center being 0
        playerPos.x = Mathf.Clamp(mousePosInBlocks, -8f, 8f);
        transform.position = playerPos;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        ballBouncingSound.Play();
    }
}
