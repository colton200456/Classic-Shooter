using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

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
        //transform.LookAt(Player);

        //if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        //{

        //    transform.position += transform.forward * MoveSpeed * Time.deltaTime;



        //    if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
        //    {
        //        //Here Call any function U want Like Shoot at here or something
        //    }

        //}

        Vector3 diff = Player.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        //transform.LookAt(Player);
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);


    }

}
