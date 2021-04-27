using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 4f;

    [SerializeField] float groundDistance = 1f;
    [SerializeField] float gravity = -9.81f;
    [SerializeField] LayerMask groundMask;
    bool isGrounded = false;

    Vector3 velocity;

    Rigidbody rb;
    CharacterController controller;

    Vector3 forward, right;
    // Start is called before the first frame update
    void Start()
    {
        forward = Vector3.Normalize(Camera.main.transform.forward);
        forward.y = 0;

        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.anyKey) Move();
    }

    void FixedUpdate() {
        if (Input.anyKey) Move();
    }

    void Move() {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);
        velocity = (rightMovement + upMovement);

        transform.forward = heading;
        // transform.position += rightMovement;
        // transform.position += upMovement;

        controller.Move(velocity);

        Vector3 checkPos = new Vector3(transform.position.x, transform.position.y - 1.6f, transform.position.z);
        if (Physics.CheckSphere(checkPos, groundDistance, groundMask))
        {
            isGrounded = true;
        }

        if (isGrounded && velocity.y < 0) 
            velocity.y = -2f;

        velocity.y += gravity + Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // rb.AddForce(rightMovement + upMovement);
        // rb.AddForce(upMovement);

        // if (rb.velocity.magnitude > maxSpeed) {
        //     rb.velocity
        // }
    }
}
