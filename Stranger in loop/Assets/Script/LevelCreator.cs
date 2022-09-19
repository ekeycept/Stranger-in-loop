using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField]
    private GameObject[] platformPrefab;
    private int randomPrefab;
    private int randomX;

    void Start()
    {
        for (int i = 0; i < 50; i++)
        {
            randomPrefab = Random.Range(0, 3);
            randomX = Random.Range(-5, 5);
            Instantiate(platformPrefab[randomPrefab], new Vector3(randomX, 0, (i * 11)), Quaternion.Euler(-90, 0, 0));            
        }
    }
}
