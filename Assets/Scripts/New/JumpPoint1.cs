using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPoint1 : MonoBehaviour
{
    public float JumpForce;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            Debug.Log("Player_here");
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.velocity = new Vector3(rb.velocity.x, 0f, JumpForce);
        }
    }
}
