using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwerEndurance : MonoBehaviour
{
	[Tooltip("NPC starting endurance.")]
	public int StartEndurance;

	int endurance = 0;
	HashSet<Collider2D> traversedPiton;

    // Start is called before the first frame update
    void Start()
    {
    	traversedPiton = new HashSet<Collider2D>();
        endurance = StartEndurance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // bool checkHitPiton(PitonPrefab piton){

    // }

    void Hurt()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!traversedPiton.Contains(other) && other.gameObject.tag == "piton")
        {
	        Debug.Log("NPC collided trigger");
	        traversedPiton.Add(other);
        }

    }
}
