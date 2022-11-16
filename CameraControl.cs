using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    void Start()
    {
        

    }

  
    void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x, player.position.y, -10f);
    }
}
