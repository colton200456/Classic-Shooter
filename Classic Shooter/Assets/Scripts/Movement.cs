using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public float speed;


    //protected Rigidbody MyRb;

    //// Use this for initialization
    //void Start()
    //{
    //    MyRb = GetComponent<Rigidbody>();
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float y = Input.GetAxis("Vertical");

    //    transform.Translate(x * Time.deltaTime * speed, y * Time.deltaTime * speed, 0.0f, Space.World);

    //    #warning THIS ISN'T WORKING, NEED TO DEBUG WHY?  http://wiki.unity3d.com/index.php/Xbox360Controller
    //    float rx = Input.GetAxis("RightStickHorizontal");
    //    float ry = Input.GetAxis("RightStickVertical");

    //    float angle = Mathf.Atan2(rx, ry);

    //    transform.rotation = Quaternion.Euler(0, angle, 0);
    //}

    public Transform bulletShot;
    public float shotDelay;

    void start()
    {

    }

    public float speed = 2.0f;

    void Update()
    {
        float leftStickx = Input.GetAxis("Horizontal");
        float leftSticky = Input.GetAxis("Vertical");

        transform.Translate(leftStickx * Time.deltaTime * speed, leftSticky * Time.deltaTime * speed, 0, Space.World);

        float rightStickx = Input.GetAxis("Right_Horizontal");
        float rightSticky = Input.GetAxis("Right_Vertical");


        float angle = Mathf.Atan2(rightStickx, rightSticky) * Mathf.Rad2Deg;
        //if (rightStickx  || rightSticky != sensitivity)
        //{
        transform.rotation = Quaternion.Euler(rightStickx, rightSticky, angle);
        //transform.rotation = Quaternion.Angle(leftStickx, leftSticky);
        // }
        GetComponent<Rigidbody2D>().velocity = new Vector2(3 * leftStickx, 3 * leftSticky);


        if (((rightStickx > .2 || rightStickx < -.2)) && (shotDelay == 0))
        {
            shotDelay = 1;
            Instantiate(bulletShot, transform.position, bulletShot.rotation);
            StartCoroutine(delayRest());
        }

        if (((rightSticky > .2 || rightSticky < -.2)) && (shotDelay == 0))
        {
            shotDelay = 1;
            Instantiate(bulletShot, transform.position, bulletShot.rotation);
            StartCoroutine(delayRest());
        }
    }

    IEnumerator delayRest()
    {
        yield return new WaitForSeconds(.6f);
        shotDelay = 0;
         

    }
}
