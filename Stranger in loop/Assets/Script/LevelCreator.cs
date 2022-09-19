using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefab;
    [SerializeField] private GameObject[] platforms;
    private int randomPrefab;
    private int randomX;
    private int i;

    void Start()
    {
        for (i = 0; i < 50; i++)
        {
            randomPrefab = Random.Range(0, 3);
            randomX = Random.Range(-5, 5);
            platforms[i] = Instantiate(platformPrefab[randomPrefab], new Vector3(randomX, 0, (i * 11)), Quaternion.Euler(-90, 0, 0));
        }
        StartCoroutine(LoopFunction(3));
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
