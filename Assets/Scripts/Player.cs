using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;
    public float moveSpeed = 5f;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    //private int superJumpsRemaining;
    //private bool playerIsAlive = true;
    public Logic logic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpKeyWasPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal");

        playerOutOfScreen();
    }

    private void FixedUpdate()
    {
        rigidbodyComponent.linearVelocity = new Vector3(horizontalInput * moveSpeed, rigidbodyComponent.linearVelocity.y, 0);

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if (jumpKeyWasPressed)
        {
            float jumpPower = 7f;
            /*if (superJumpsRemaining > 0)
            {
                jumpPower *= 2;
                superJumpsRemaining--;
            }*/

            rigidbodyComponent.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            Destroy(other.gameObject);
            //superJumpsRemaining++;
        }
        else if (other.gameObject.layer == 7)
        {
            Destroy(other.gameObject);
            logic.victory();
        }
    }

    private void playerOutOfScreen()
    {
        if (gameObject.transform.position.y < -2.5)
        {
            //playerIsAlive = false;
            logic.gameOver();
        }
    }
}
