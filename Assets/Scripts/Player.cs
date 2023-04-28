using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public Transform Head;
    public Camera camera;

    [Header("Configurations")]
    public float walkSpeed;
    public float runSpeed;


    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 newVelocity = new Vector3(0f, rb.velocity.y, 0f);
        //float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;
        float speed = walkSpeed;
        newVelocity.x = Input.GetAxis("Horizontal") * speed;
        newVelocity.z = Input.GetAxis("Vertical") * speed;
        rb.velocity = newVelocity;
    }
}
