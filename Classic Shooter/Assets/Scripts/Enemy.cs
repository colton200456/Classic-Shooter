﻿using System.Collections;
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

        transform.LookAt(Player);
        transform.Translate(Vector3.forward * 5 * Time.deltaTime);


    }

}
