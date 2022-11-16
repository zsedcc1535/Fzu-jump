using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    public Rigidbody2D Rd;
    public float Press_right_Time;
    public float Press_left_Time;
    public float Press_y_Time;
    public float Jump_x_Force = 13;
    public float Jump_y_Force = 13;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            Press_right_Time += 0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Press_left_Time -= 0.1f;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Press_y_Time += 0.1f;
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W))
        {
            Rd.AddForce(new Vector2((Press_right_Time + Press_left_Time) * Jump_x_Force, Press_y_Time * Jump_y_Force));
            Press_right_Time = 0f;
            Press_left_Time = 0f;
            Press_y_Time = 0f;
        }
    }
}
