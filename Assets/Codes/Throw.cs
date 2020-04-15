using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    private bool canThrow;
    private Rigidbody rigidBody;
    private Collider col;
    private Damage damage;

    public float throwForce;
    public float speed;
    public GameObject parent;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        col = GetComponentInChildren<Collider>();
        damage = GetComponent<Damage>();
        canThrow = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canThrow && Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            col.enabled = true;
            damage.enabled = true;
            //rigidBody.constraints -= RigidbodyConstraints.FreezePositionZ;
            transform.parent = null;
            transform.localPosition += new Vector3(0.5f, 0, 0);
            rigidBody.velocity = (player.transform.forward * throwForce);
            //rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y, speed * Time.deltaTime);
            canThrow = false;
        }
        if (!canThrow && Input.GetMouseButtonDown(1) && Time.timeScale == 1)
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
            transform.localPosition = new Vector3(-0.4f, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.GetComponentInChildren<PlayerController>())
        {
            //Send back shield
            transform.LookAt(parent.transform);
            rigidBody.velocity = transform.forward * speed;
            Debug.Log("hi2");
        }
        else
        {
            col.enabled = false;
            damage.enabled = false;
            Debug.Log("hi3");
            transform.parent = parent.transform;
            rigidBody.velocity = Vector3.zero;
            transform.localPosition = new Vector3(0.77f, 0, 0);
            transform.localEulerAngles = new Vector3(180f, 0, 90f);
            canThrow = true;
            /*rigidBody.constraints -= RigidbodyConstraints.FreezePositionZ;
            rigidBody.constraints -= RigidbodyConstraints.FreezePositionX;
            rigidBody.constraints -= RigidbodyConstraints.FreezePositionY;*/
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponentInChildren<PlayerController>())
        {
            col.enabled = true;
            damage.enabled = true;
        }
    }
}
