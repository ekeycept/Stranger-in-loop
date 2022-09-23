using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMoving : MonoBehaviour
{
    private Vector3 lastPos;
    private Vector3 currentPos;
    private Rigidbody rb;
    private float speed = 5f;
    private bool isMovingRight = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(transform.position.x > 5)
        {
            isMovingRight = false;
        }
        else if (transform.position.x < -5)
        {
            isMovingRight = true;
        }

        if (isMovingRight)
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }


}
