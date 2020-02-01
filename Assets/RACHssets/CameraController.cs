using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;        //Public variable to store a reference to the player game object


    private Vector3 offset;            //Private variable to store the offset distance between the player and camera

    private float helpCameraFollowFaster = 3;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called after Update each frame

    void LateUpdate()
    {
       this.transform.position = new Vector3(Mathf.Lerp(this.transform.position.x, player.transform.position.x + offset.x, Time.deltaTime * helpCameraFollowFaster),
                                               Mathf.Lerp(this.transform.position.y, player.transform.position.y + offset.y, Time.deltaTime * helpCameraFollowFaster), this.transform.position.z);
    }

}
