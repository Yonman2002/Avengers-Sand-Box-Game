using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private bool canThrow;
    private Rigidbody rigidBody;
    private Collider col;

    public float throwForce;
    public float speed;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        col = GetComponentInChildren<Collider>();
        canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canThrow && Input.GetMouseButtonDown(0))
        {
            col.enabled = true;
            //rigidBody.constraints -= RigidbodyConstraints.FreezePositionZ;
            rigidBody.velocity = (transform.parent.forward * throwForce);
            transform.parent = null;
            //rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, speed * Time.deltaTime);
            canThrow = false;
        }
        if (!canThrow && Input.GetMouseButtonDown(1))
        {
            //Send back shield
            //rigidBody.constraints -= RigidbodyConstraints.FreezePositionX;
            //rigidBody.constraints -= RigidbodyConstraints.FreezePositionY;
            transform.LookAt(parent.transform);
            rigidBody.velocity = transform.forward * speed;
            //rigidBody.velocity = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z * throwForce);
            //rigidBody.AddForce(parent.transform.position * throwForce);
            //transform.position = Vector3.MoveTowards(transform.position, parent.transform.position, speed * Time.deltaTime);
            Debug.Log("hi1");
        }
        if (transform.parent != null)
        {
            transform.localPosition = new Vector3(0.77f, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject != parent)
        {
            //Send back shield
            transform.LookAt(parent.transform);
            rigidBody.velocity = transform.forward * speed;
            Debug.Log("hi2");
        }
        else
        {
            col.enabled = false;
            Debug.Log("hi3");
            transform.parent = parent.transform;
            rigidBody.velocity = Vector3.zero;
            transform.localPosition = new Vector3(0.77f, 0, 0);
            transform.localEulerAngles = new Vector3(90f, 90f, 0);
            canThrow = true;
            /*rigidBody.constraints -= RigidbodyConstraints.FreezePositionZ;
            rigidBody.constraints -= RigidbodyConstraints.FreezePositionX;
            rigidBody.constraints -= RigidbodyConstraints.FreezePositionY;*/
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == parent)
        {
            col.enabled = true;
        }
    }
}
