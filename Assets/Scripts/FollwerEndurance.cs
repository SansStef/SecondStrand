using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollwerEndurance : MonoBehaviour
{
	[Tooltip("NPC starting endurance.")]
	public int StartEndurance;

	[Tooltip("Follower skill level, determines if to take damage based on piton health.")]
	public int Skill;

	[Tooltip("")]
	public int EnduranceDamage;

	int endurance = 0;
	HashSet<Collider2D> traversedPitons;

    // Start is called before the first frame update
    void Start()
    {
    	traversedPitons = new HashSet<Collider2D>();
        endurance = StartEndurance;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfDead();
    }



    void CheckIfDead(){
    	endurance = endurance <= 0 ? 0 : endurance;
    	if(endurance <= 0){
    		Die();
    	}
    }

    void Die()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!traversedPitons.Contains(other) && other.gameObject.tag == "piton")
        {
        	traversedPitons.Add(other);
	        Debug.Log("NPC collided trigger: "+ traversedPitons.Count);

	        DoDamage(other.GetComponent<PitonInteraction>());

	        Debug.Log("NPC Endurance: " + endurance);
        }

    }

    private void DoDamage(PitonInteraction piton){
    	Debug.Log("Piton health: " + piton.GetHealth());
    	Debug.Log("Skill: "+ Skill);
    	if(! (piton.GetHealth() > Skill)){
    		endurance = endurance - EnduranceDamage;
    	}
    }
}
