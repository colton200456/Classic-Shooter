using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;


    protected Rigidbody MyRb;

    public Transform laser;
    public float shotDelay;

    // Use this for initialization
    void Start()
    {
        MyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(x * Time.deltaTime * speed, y * Time.deltaTime * speed, 0.0f, Space.World);

        //#warning THIS ISN'T WORKING, NEED TO DEBUG WHY?  http://wiki.unity3d.com/index.php/Xbox360Controller
        float rx = Input.GetAxis("RightStickHorizontal");
        float ry = Input.GetAxis("RightStickVertical");

        float angle = Mathf.Atan2(rx, ry);

        transform.rotation = Quaternion.Euler(0, angle, 0);

        if (rx > .2 || rx < -.2) {
            Instantiate(laser, transform.position, laser.rotation);
        }

        if (ry > .2 || ry < -.2)
        {
            Instantiate(laser, transform.position, laser.rotation);
        }
    }
}
