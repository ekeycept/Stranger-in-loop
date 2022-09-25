using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] private GameObject PlayerToFollow;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(PlayerToFollow.transform.position.x, -5, PlayerToFollow.transform.position.z);
    }
}
