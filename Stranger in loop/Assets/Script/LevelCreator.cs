using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefab;
    private int randomNumber;

    void Start()
    {
        for (int i = 0; i < 25; i++)
        {
            randomNumber = Random.Range(0, 2);
            Instantiate(platformPrefab[randomNumber], new Vector3(0, 0, (float)(i * 4.6)), Quaternion.Euler(-90, 0, 0));
            
        }
    }

    void Update()
    {

    }
}
