using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFollower : MonoBehaviour
{

	Node[] PathNode;
	public GameObject Player;
	public float MoveSpeed;
	int Timer;
	static Vector3 CurrentPositionHolder;

    // Start is called before the first frame update
    void Start()
    {
        PathNode = GetComponentsInChildren<Node>();
        CheckNode();

        foreach(Node n in PathNode){
        	Debug.Log(n.name);
        }
    }

    void CheckNode(){
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
