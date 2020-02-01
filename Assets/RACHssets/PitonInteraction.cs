using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitonInteraction : MonoBehaviour
{

    float health;
    bool playerInRangeOfPiton;
    
    public float maxHealth = 1000.0f;
    public float repairRate = 10.0f;

    public Sprite brokenSprite;
    public Sprite damagedSprite;
    public Sprite healthySprite;
        
    // Start is called before the first frame update
    void Start()
    {
        float startingHealth = Random.Range(0, maxHealth);
        //Debug.Log("Starting health" + startingHealth);
        health = startingHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRangeOfPiton && Input.GetKey(KeyCode.Space))
        {
            health += repairRate * Time.deltaTime; // time since the last frame.  so essentially repairRate is the repair per second that the key is held down?
            //Debug.Log("Repairing the piton, health is now " + health);
        }

        if (health >= maxHealth)
        {
            this.GetComponent<SpriteRenderer>().sprite = healthySprite;
        }
        else if (health / maxHealth >= .33)
        {
            this.GetComponent<SpriteRenderer>().sprite = damagedSprite;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = brokenSprite;
        }

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Player collided trigger");
        playerInRangeOfPiton = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("Player exited trigger");
        playerInRangeOfPiton = false;
    }
}
