using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform Player;
    int MoveSpeed = 4;
    int MaxDist = 10;
    int MinDist = 5;
    public Transform myTransform;

    void Start()
    {

    }

    void Update()
    {
        Vector3 diff = Player.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        //transform.LookAt(Player);
        transform.Translate(transform.position * 5 * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            collision.gameObject.SetActive(false);
            Explode();
        }
    }

    public void Explode()
    {
        Debug.Log("SHIP DESTROYED");
        gameObject.SetActive(false);
    }
}
