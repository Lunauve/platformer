using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    bool jumpKeyWasPressed;
    float horizontalInput;
    private Rigidbody rigidbodyComponent;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");
    }

    bool isGrounded;
    private void FixedUpdate()
    {
        rigidbodyComponent.velocity = new Vector3(horizontalInput, rigidbodyComponent.velocity.y, 0);

        if (!isGrounded)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            playerJump();
        }
    }

    void playerJump()
    {
        rigidbodyComponent.AddForce(Vector3.up * 5, ForceMode.VelocityChange);
        jumpKeyWasPressed = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
        isGrounded = jumpKeyWasPressed && !isGrounded ? true : false;
    }
}
