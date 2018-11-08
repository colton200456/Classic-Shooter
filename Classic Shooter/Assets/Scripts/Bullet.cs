using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float shotRotation;

    void Start()
    {
        InitializeBulletMovement();
    }

    private void OnEnable()
    {
        InitializeBulletMovement();
    }

    void InitializeBulletMovement()
    {
        float rightStickx = Input.GetAxis("Right_Horizontal");
        float rightSticky = Input.GetAxis("Right_Vertical");

        if (rightStickx > .2)
        {
            rightStickx = 5;
            shotRotation = 90;
        }
        if (rightStickx < -.2)
        {
            rightStickx = -5;
            shotRotation = -90;
        }
        if (rightSticky > .2)
        {
            rightSticky = 5;
            shotRotation = 180;
        }
        if (rightSticky < -.2)
        {
            rightSticky = -5;
            shotRotation = 0;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector3(-rightStickx, rightSticky, 0);
        Debug.Log(string.Format("rightstick x : {0}, rightstick y : {1}", -rightStickx, rightSticky));

        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, shotRotation);

        GetComponent<Transform>().eulerAngles = new Vector3(0, 0, shotRotation);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BulletDestroyer")
        {
            gameObject.SetActive(false);
        }
    }
}