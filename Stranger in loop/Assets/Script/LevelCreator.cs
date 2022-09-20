using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefab;
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private Text Score;
    [SerializeField] private Transform Player;
    [SerializeField] private int lastPos = 0;
    private int j = 2;
    private int randomPrefab;
    private int randomX;
    private int i;

    void Start()
    {
        for (i = 0; i < 50; i++)
        {
            randomPrefab = UnityEngine.Random.Range(0, 3);
            randomX = UnityEngine.Random.Range(-5, 5);
            platforms[i] = Instantiate(platformPrefab[randomPrefab], new Vector3(randomX, 0, (i * 11)), Quaternion.Euler(-90, 0, 0));
        }
        StartCoroutine(LoopFunction(3));
    }

    private void Update()
    {
        int currentPos = Convert.ToInt32(Player.position.z / 4.6f);
        int distance = currentPos - lastPos;

        if (distance >= 25)
        {
            for (i = 0; i < 25; i++)
            {
                randomPrefab = UnityEngine.Random.Range(0, 3);
                randomX = UnityEngine.Random.Range(-5, 5);
                platforms[j*25 + i] = Instantiate(platformPrefab[randomPrefab], new Vector3(randomX, 0, platforms[j*25 - 1 + i].transform.position.z + 11), Quaternion.Euler(-90, 0, 0));
            }
            Debug.Log("New platforms created");
            j++;
            lastPos = currentPos;
        }
    }

    private IEnumerator LoopFunction(float waitTime)
    {
        int i = 0;
        while (i >= 0)
        {
            Destroy(platforms[i]);
            yield return new WaitForSeconds(waitTime);
            i++;
        }
    }
}
