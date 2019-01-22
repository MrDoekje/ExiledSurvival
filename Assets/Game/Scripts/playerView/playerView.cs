using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerView : MonoBehaviour
{
    public Rigidbody rb;

    private int positionY;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("w"))
        {
            rb.AddForce(0, 0, 4000 * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-4000 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            rb.AddForce(0, 0, -4000 * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            rb.AddForce(4000 * Time.deltaTime, 0, 0);
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            if (transform.position.y >= 15)
                rb.AddForce(0, -3000 * Time.deltaTime, 0);
            if (transform.position.y < 10)
            {
                rb.AddForce(0, 1000 * Time.deltaTime, 0);
                transform.position = new Vector3(transform.position.x, 10, transform.position.z);
            }
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            if (transform.position.y <= 40)
                rb.AddForce(0, 3000 * Time.deltaTime, 0);
            if (transform.position.y > 45)
            {
                rb.AddForce(0, -1000 * Time.deltaTime, 0);
                transform.position = new Vector3(transform.position.x, 45, transform.position.z);
            }
        }
    }

}
