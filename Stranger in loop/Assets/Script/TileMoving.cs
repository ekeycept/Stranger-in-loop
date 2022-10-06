using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMoving : MonoBehaviour
{
    private float speed = 3f;
    public float rightEnd { get;  set; }
    public float leftEnd { get; set; }
    private bool isMovingRight = false;


    void Update()
    {
        if(transform.position.x > rightEnd)
        {
            isMovingRight = false;
        }
        else if (transform.position.x < leftEnd)
        {
            isMovingRight = true;
        }

        if (isMovingRight)
            transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    public void SpeedUp()
    {
        speed += 3f;
    }


}
