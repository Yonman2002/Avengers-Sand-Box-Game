using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Rigidbody rigidbody;
    private float count = 0;

    public GameObject shootFrom;
    public float fireRate;
    public float distanceToShoot;
    public float moveSpeed;
    public float bulletSpeed;
    public Damage bulletDamage;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(PlayerController.player.transform);
        rigidbody.velocity = new Vector3(moveSpeed * transform.forward.x, rigidbody.velocity.y, moveSpeed * transform.forward.z);
        if (Vector3.Distance(transform.position, PlayerController.player.transform.position) <= distanceToShoot && count <= 0)
        {
            count = fireRate;
            GameObject bullet = Instantiate(bulletDamage.gameObject);
            bullet.SetActive(true);
            bullet.transform.forward = transform.forward;
            bullet.transform.position = shootFrom.transform.position;
            bullet.GetComponent<Rigidbody>().velocity = new Vector3(moveSpeed * transform.forward.x * bulletSpeed, rigidbody.velocity.y, moveSpeed * transform.forward.z * bulletSpeed);
        }
        count -= Time.deltaTime;
    }
}
