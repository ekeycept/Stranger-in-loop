using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private GameObject[] platformPrefab;
    [SerializeField] private GameObject[] platformPrefabSecond;
    [SerializeField] private GameObject[] platformPrefabThird;
    [SerializeField] private GameObject[] platformPrefabFourth;
    [SerializeField] private GameObject[] platformPrefabFifth;
    [SerializeField] private GameObject[] decoratingPlatformPrefab;
    [SerializeField] private GameObject[] platforms;
    [SerializeField] private GameObject[] decoratingPlatforms;
    [SerializeField] private Text Score;
    [SerializeField] private Transform Player;
    [SerializeField] private int lastPos = 0;
    private int j = 1;
    private int randomPrefab;
    private int randomX;
    private int randomY;
    private int randomRotX;
    private int randomRotY;
    private int randomRotZ;
    private int i;
    private int randomMovingTile;
    private int randomSide;
    private int k;
    int startPos = 0;

    void Start()
    {
        for (i = 0; i < 25; i++)
        {
            randomPrefab = UnityEngine.Random.Range(0, 3);
            randomX = UnityEngine.Random.Range(-5, 5);
            platforms[i] = Instantiate(platformPrefab[randomPrefab], new Vector3(randomX, 0, (i * 11)), Quaternion.Euler(-90, 0, 0));
        }
        for (int i = 0; i < 100; i++)
        {
            randomSide = UnityEngine.Random.Range(0, 2);
            if (randomSide == 0)
            {
                randomPrefab = UnityEngine.Random.Range(0, 4);
                randomX = UnityEngine.Random.Range(-35, -15);
                randomY = UnityEngine.Random.Range(-20, 20);
                randomRotX = UnityEngine.Random.Range(-90, 90);
                randomRotY = UnityEngine.Random.Range(-90, 90);
                randomRotZ = UnityEngine.Random.Range(-90, 90);
                decoratingPlatforms[i] = Instantiate(decoratingPlatformPrefab[randomPrefab], new Vector3(randomX, randomY, i * 10), Quaternion.Euler(randomRotX, randomRotY, randomRotZ));
            }
            if (randomSide == 1)
            {
                randomPrefab = UnityEngine.Random.Range(0, 4);
                randomX = UnityEngine.Random.Range(15, 35);
                randomY = UnityEngine.Random.Range(-20, 20); 
                randomRotX = UnityEngine.Random.Range(-90, 90);
                randomRotY = UnityEngine.Random.Range(-90, 90);
                randomRotZ = UnityEngine.Random.Range(-90, 90);
                decoratingPlatforms[i] = Instantiate(decoratingPlatformPrefab[randomPrefab], new Vector3(randomX, randomY, i * 10), Quaternion.Euler(randomRotX, randomRotY, randomRotZ));
            }
        }
        StartCoroutine(LoopFunction(3));
    }

    private void Update()
    {
        int currentPos = Convert.ToInt32(Player.position.z / 4.6f);

        if (currentPos <= 100)
        {
            AddDecoratingPlatforms(decoratingPlatformPrefab, currentPos, ref startPos, 1);
            AddPlatforms(platformPrefab, currentPos, ref lastPos);
        }
        else if (currentPos > 100 && currentPos < 200)
            AddPlatforms(platformPrefabSecond, currentPos, ref lastPos);
        else if (currentPos > 200 && currentPos < 300)
            AddPlatforms(platformPrefabThird, currentPos, ref lastPos);
        else if (currentPos > 300 && currentPos < 400)
            AddPlatforms(platformPrefabFourth, currentPos, ref lastPos);
        else if (currentPos > 400)
            AddPlatforms(platformPrefabFifth, currentPos, ref lastPos);


    }

    private void AddPlatforms(GameObject[] prefabs, int currentPos, ref int lastPos)
    {
        if ((currentPos - lastPos) >= 25)
        {
            Array.Resize(ref platforms, platforms.Length + 25);
                for (i = 0; i < 25; i++)
                {
                    randomMovingTile = UnityEngine.Random.Range(0, 2);
                    if (randomMovingTile == 0)
                    {
                        randomPrefab = UnityEngine.Random.Range(3, 5);
                        randomX = UnityEngine.Random.Range(-5, 5);
                        platforms[j * 25 + i] = Instantiate(prefabs[randomPrefab], new Vector3(randomX, 0, platforms[j * 25 - 1 + i].transform.position.z + 11), Quaternion.Euler(-90, 0, 0));
                    }
                    else
                    {
                        randomPrefab = UnityEngine.Random.Range(0, 3);
                        randomX = UnityEngine.Random.Range(-5, 5);
                        platforms[j * 25 + i] = Instantiate(prefabs[randomPrefab], new Vector3(randomX, 0, platforms[j * 25 - 1 + i].transform.position.z + 11), Quaternion.Euler(-90, 0, 0));
                    }
                }
            Debug.Log("New platforms created");
            j++;
            lastPos = currentPos;
        }
    }

    private void AddDecoratingPlatforms(GameObject[] prefab, int currentPos, ref int startPos, int k)
    {
        if (currentPos - startPos >= 99)
        {
            Array.Resize(ref decoratingPlatforms, decoratingPlatforms.Length + 50);
            for (int i = 0; i < 100; i++)
            {
                randomSide = UnityEngine.Random.Range(0, 2);
                if (randomSide == 0)
                {
                    randomPrefab = UnityEngine.Random.Range(0, 4);
                    randomX = UnityEngine.Random.Range(-25, -15);
                    randomY = UnityEngine.Random.Range(-10, 10);
                    decoratingPlatforms[100 * k + i] = Instantiate(prefab[randomPrefab], new Vector3(randomX, randomY, decoratingPlatforms[k * 100 - 1 + i].transform.position.z + 30), Quaternion.Euler(-90, 0, 0));
                }
                if (randomSide == 1)
                {
                    randomPrefab = UnityEngine.Random.Range(0, 4);
                    randomX = UnityEngine.Random.Range(15, 25);
                    randomY = UnityEngine.Random.Range(-10, 10);
                    decoratingPlatforms[100 * k + i] = Instantiate(prefab[randomPrefab], new Vector3(randomX, randomY, decoratingPlatforms[k * 100 - 1 + i].transform.position.z + 30), Quaternion.Euler(-90, 0, 0));
                }
            }
            Debug.Log("Created decorating platforms!");
            startPos += 100;

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
