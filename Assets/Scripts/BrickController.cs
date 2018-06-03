using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {
    int maxHits;
    int timesHit;
    LevelManager lvlManager;
    bool isBreakable;

    public static int brickCount = 0;
    public Sprite[] hitSprites;
    public GameObject particles;

    // Use this for initialization
    void Start () {
        timesHit = 0;
        lvlManager = FindObjectOfType<LevelManager>();
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            brickCount++;
            print(brickCount);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isBreakable)
        {
            
            HandleHits();
        }

        
    }

    void HandleHits()
    {
        maxHits = hitSprites.Length + 1;
        timesHit++;
        if (timesHit >= maxHits)
        {
            brickCount--;
            print(brickCount);
            lvlManager.BrickDestroyed();
            ActivateParticles();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }

    void ActivateParticles()
    {
        var smokeMain = particles.GetComponent<ParticleSystem>().main;
        smokeMain.startColor = gameObject.GetComponent<SpriteRenderer>().color;
        Instantiate(particles, gameObject.transform.position, Quaternion.identity);
    }

    void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {  
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Brick sprite missing");
        }

    }


    // TODO Remove this method once we can actually win!
    void SimulateWin()
    {
        lvlManager.LoadNextLevel();
    }
}
