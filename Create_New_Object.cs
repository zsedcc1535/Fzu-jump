using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Create_New_Object : MonoBehaviour
{
    public GameObject Obj;
    private bool flag = false;
    public int Len = 20;
    public Rigidbody2D Rd;
    public Collider2D collider;
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collider.isTrigger = true;
        Instantiate(Obj, new Vector3(Obj.transform.position.x, transform.position.y + Len, 0), transform.rotation);
        Destroy(Obj);
    }
}
