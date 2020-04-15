﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rigidBody;
    private float horizontal;
    private float vertical;

    public Transform CollisionPos;
    public float JumpForce;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 trueSpeed = new Vector3(horizontal * speed, rigidBody.velocity.y, vertical * speed);
        if (Input.GetButton("Jump"))
        {
            if (Physics.CheckBox(CollisionPos.position, CollisionPos.localScale, Quaternion.identity, ~(1 << 8)))
            {
                trueSpeed.y = JumpForce;
                /*if (!JumpingAnimation.Active)
                {
                    ActivateAnimation(JumpingAnimation);
                    source.PlayOneShot(JumpSounds[Random.Range(0, JumpSounds.Length)]);
                }*/
            }
        }
        rigidBody.velocity = trueSpeed;
    }
}
