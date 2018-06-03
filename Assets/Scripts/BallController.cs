using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    private PlayerController player;
    Vector3 paddleToBall;
    Rigidbody2D rb;
    bool hasStarted = false;
    AudioSource soundEffect;


	// Use this for initialization
	void Start () {
        soundEffect = GetComponent<AudioSource>();
        player = GameObject.FindObjectOfType<PlayerController>();
        paddleToBall = this.transform.position - player.transform.position;
        rb = GetComponent<Rigidbody2D>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!hasStarted)
        {
            //Lock the ball position on the player
            this.transform.position = player.transform.position + paddleToBall;

            //Launch the ball when left click is pressed
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector2(2f, 10f);
                hasStarted = true;
            }
            
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));
        if(collision.gameObject.CompareTag("Breakable"))
            soundEffect.Play();
        rb.velocity += tweak;
        rb.rotation += Random.Range(0f, 1f);
    }
}
