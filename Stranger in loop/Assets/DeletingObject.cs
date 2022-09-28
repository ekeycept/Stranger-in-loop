using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletingObject : MonoBehaviour
{
    private Transform Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Player.position.z - gameObject.transform.position.z > 10)
            Destroy(gameObject, 2);
        if(Convert.ToInt32(Player.position.z) - Convert.ToInt32(gameObject.transform.position.z) == 0)
            Destroy(gameObject, 5);
    }
}
