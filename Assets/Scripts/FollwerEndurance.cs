using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwerEndurance : MonoBehaviour
{
	[Tooltip("NPC starting endurance.")]
	public int StartEndurance;

	int endurance = 0;
	//PitonPrefab[] traversedPiton;

    // Start is called before the first frame update
    void Start()
    {
        endurance = StartEndurance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // bool checkHitPiton(PitonPrefab piton){

    // }

    void hurt()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "piton")
        {
	        Debug.Log("NPC collided trigger");        
        }

    }
}
