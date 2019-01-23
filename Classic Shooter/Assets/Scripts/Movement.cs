using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Transform bulletShot;
    public float shotDelay;

    public ObjectPooler pooler;

    public float speed = 2.0f;

    Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float leftStickx = Input.GetAxis("Horizontal");
        float leftSticky = Input.GetAxis("Vertical");
        
        transform.Translate(leftStickx * Time.deltaTime * speed, leftSticky * Time.deltaTime * speed, 0, Space.World);

        float rightStickx = Input.GetAxis("Right_Horizontal");
        float rightSticky = Input.GetAxis("Right_Vertical");


        //if (rightStickx != 0f || rightSticky != 0f)
        //{
        //    Debug.Log("rotation to shooting");
        //    float angle = Mathf.Atan2(rightStickx, rightSticky) * Mathf.Rad2Deg;
        //    transform.rotation = Quaternion.Euler(rightStickx, rightSticky, angle);
        //}

        if (leftStickx != 0f || leftSticky != 0f)
        {
            //Debug.Log("rotation to movement");
            float angle = Mathf.Atan2(-leftStickx, leftSticky) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(-leftStickx, leftSticky, angle);
        }

        // pls work....
        else if(leftStickx == 0f && leftSticky == 0f)
        {
            float angle = 1;
            transform.rotation = Quaternion.Euler(-leftStickx, leftSticky, angle);
        }
                    body.velocity = new Vector2(1 * leftStickx, 1 * leftSticky);

        if (((rightStickx > .2 || rightStickx < -.2)) && (shotDelay == 0))
        {
            shotDelay = 1;
            CreateBullet();
            StartCoroutine(delayRest());
        }

        if (((rightSticky > .2 || rightSticky < -.2)) && (shotDelay == 0))
        {
            shotDelay = 1;
            CreateBullet();
            StartCoroutine(delayRest());
        }

    }

    IEnumerator delayRest()
    {
        yield return new WaitForSeconds(.25f);
        shotDelay = 0;
    }
    void CreateBullet()
    {
        var pooledObject = pooler.GetPooledObject();
        pooledObject.transform.position = transform.position;
        pooledObject.transform.rotation = transform.rotation;
        pooledObject.SetActive(true);
    }
}
