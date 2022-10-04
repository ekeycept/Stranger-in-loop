using System;
using UnityEngine;
using UnityEngine.UI;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private int numberOfStartedPlatforms = 25;
    [SerializeField] private int numberOfNeededDecorPlat = 10;
    [SerializeField] private int numberOfStartedThings = 100;

    [SerializeField] private GameObject[] pastPlatformPrefab;
    [SerializeField] private GameObject[] presentPlatformPrefab;
    [SerializeField] private GameObject[] futurePlatformPrefab;
    [SerializeField] private GameObject[] pastDecoratingThingsPrefab;
    [SerializeField] private GameObject[] presentDecoratingThingsPrefab;
    [SerializeField] private GameObject[] futureDecoratingThingsPrefab;
    [SerializeField] private GameObject[] pastDecoratingPlatformsPrefab;
    [SerializeField] private GameObject[] presentDecoratingPlatformsPrefab;
    [SerializeField] private GameObject[] futureDecoratingPlatformsPrefab;

    [SerializeField] private GameObject[] decoratingPlatforms;
    [SerializeField] private GameObject[] decoratingThings;
    [SerializeField] private GameObject[] platforms;

    [SerializeField] private Text Score;
    [SerializeField] private Transform Player;

    private int randomPrefab;
    private int randomX;
    private int randomY;
    private int randomRotX;
    private int randomRotY;
    private int randomRotZ;
    private int randomMovingTile;
    private int randomSide;
    private int i;
    private int j = 1;
    private int k = 1;
    private int g = 1;
    private int lastPos = 0;
    private int startPos = 0;
    private int previousPos = 0;

    void Start()
    {
        for (i = 1; i < numberOfStartedPlatforms; i++)
        {
            randomPrefab = UnityEngine.Random.Range(0, 3);
            randomX = UnityEngine.Random.Range(-5, 5);
            platforms[i] = Instantiate(pastPlatformPrefab[randomPrefab], new Vector3(randomX, 0, (i * 11)), Quaternion.Euler(-90, 0, 0));
        }
        for (int i = 0; i < numberOfStartedThings; i++)
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
                decoratingThings[i] = Instantiate(pastDecoratingThingsPrefab[randomPrefab], new Vector3(randomX, randomY, i * 10), Quaternion.Euler(randomRotX, randomRotY, randomRotZ));
            }
            if (randomSide == 1)
            {
                randomPrefab = UnityEngine.Random.Range(0, 4);
                randomX = UnityEngine.Random.Range(15, 35);
                randomY = UnityEngine.Random.Range(-20, 20); 
                randomRotX = UnityEngine.Random.Range(-90, 90);
                randomRotY = UnityEngine.Random.Range(-90, 90);
                randomRotZ = UnityEngine.Random.Range(-90, 90);
                decoratingThings[i] = Instantiate(pastDecoratingThingsPrefab[randomPrefab], new Vector3(randomX, randomY, i * 10), Quaternion.Euler(randomRotX, randomRotY, randomRotZ));
            }
        }
        for(int i = 0; i < numberOfNeededDecorPlat; i++)
        {
            randomSide = UnityEngine.Random.Range(0, 2);
            if (randomSide == 0)
            {
                randomPrefab = UnityEngine.Random.Range(0, 2);
                randomX = UnityEngine.Random.Range(-40, -20);
                decoratingPlatforms[i] = Instantiate(pastDecoratingPlatformsPrefab[randomPrefab], new Vector3(randomX, 10, i * 50), Quaternion.Euler(-90, 0, 0));
            }
            if (randomSide == 1)
            {
                randomPrefab = UnityEngine.Random.Range(0, 2);
                randomX = UnityEngine.Random.Range(20, 40);
                decoratingPlatforms[i] = Instantiate(pastDecoratingPlatformsPrefab[randomPrefab], new Vector3(randomX, 10, i * 50), Quaternion.Euler(-90, 0, 0));
            }
        }
    }

    private void Update()
    {
        if (Player != null)
        {
            int currentPos = Convert.ToInt32(Player.position.z / 4.6f);

            if (currentPos <= 200)
            {
                if ((currentPos - lastPos) >= 25)
                    AddPlatforms(pastPlatformPrefab, currentPos, ref lastPos);
                if (currentPos - previousPos >= 99)
                    AddDecoratingThings(pastDecoratingThingsPrefab, ref previousPos, k);
                if (currentPos - startPos >= 99)
                    AddDecoratingPlatforms(pastDecoratingPlatformsPrefab, ref startPos, g);
            }
            else if (currentPos > 200 && currentPos < 400)
            {
                if ((currentPos - lastPos) >= 25)
                    AddPlatforms(presentPlatformPrefab, currentPos, ref lastPos);
                if (currentPos - previousPos >= 99)
                    AddDecoratingThings(presentDecoratingThingsPrefab, ref previousPos, k);
                if (currentPos - startPos >= 99)
                    AddDecoratingPlatforms(presentDecoratingPlatformsPrefab, ref startPos, g);
            }
            else if (currentPos > 400)
            {
                if ((currentPos - lastPos) >= 25)
                    AddPlatforms(futurePlatformPrefab, currentPos, ref lastPos);
                if (currentPos - previousPos >= 99)
                    AddDecoratingThings(futureDecoratingThingsPrefab, ref previousPos, k);
                if (currentPos - startPos >= 99)
                    AddDecoratingPlatforms(futureDecoratingPlatformsPrefab, ref startPos, g);
            }
        }
    }

    private void AddPlatforms(GameObject[] prefabs, int currentPos, ref int lastPos)
    {
        Array.Resize(ref platforms, platforms.Length + 25);
        for (i = 0; i < numberOfStartedPlatforms; i++)
        {
             randomMovingTile = UnityEngine.Random.Range(0, 2);
             if (randomMovingTile == 0)
             {
                  randomPrefab = UnityEngine.Random.Range(3, 6);
                  randomX = UnityEngine.Random.Range(-5, 5);
                  platforms[j * numberOfStartedPlatforms + i] = Instantiate(prefabs[randomPrefab], new Vector3(randomX, 0, platforms[j * numberOfStartedPlatforms - 1 + i].transform.position.z + 11), Quaternion.Euler(-90, 0, 0));
                  platforms[j * numberOfStartedPlatforms + i].GetComponent<TileMoving>().rightEnd = UnityEngine.Random.Range(3, 15);
                  platforms[j * numberOfStartedPlatforms + i].GetComponent<TileMoving>().leftEnd = UnityEngine.Random.Range(-15, -3);
             }
             else
             {
                   randomPrefab = UnityEngine.Random.Range(0, 3);
                   randomX = UnityEngine.Random.Range(-5, 5);
                   platforms[j * numberOfStartedPlatforms + i] = Instantiate(prefabs[randomPrefab], new Vector3(randomX, 0, platforms[j * numberOfStartedPlatforms - 1 + i].transform.position.z + 11), Quaternion.Euler(-90, 0, 0));
             }
        }
        Debug.Log("New platforms created");
        j++;
        lastPos = currentPos;
    }

    private void AddDecoratingThings(GameObject[] prefab, ref int previousPos, int k)
    {
        Array.Resize(ref decoratingThings, decoratingThings.Length + 100);
        for (int i = 0; i < numberOfStartedThings; i++)
        {
            randomSide = UnityEngine.Random.Range(0, 2);
            if (randomSide == 0)
            {
                 randomPrefab = UnityEngine.Random.Range(0, 4);
                 randomX = UnityEngine.Random.Range(-25, -15);
                 randomY = UnityEngine.Random.Range(-10, 10);
                 randomRotX = UnityEngine.Random.Range(-90, 90);
                 randomRotY = UnityEngine.Random.Range(-90, 90);
                 randomRotZ = UnityEngine.Random.Range(-90, 90);
                 decoratingThings[numberOfStartedThings * k + i] = Instantiate(prefab[randomPrefab], new Vector3(randomX, randomY, decoratingThings[k * numberOfStartedThings - 1 + i].transform.position.z + 30), Quaternion.Euler(randomRotX, randomRotY, randomRotZ));
            }
            if (randomSide == 1)
            {
                randomPrefab = UnityEngine.Random.Range(0, 4);
                randomX = UnityEngine.Random.Range(15, 25);
                randomY = UnityEngine.Random.Range(-10, 10);
                randomRotX = UnityEngine.Random.Range(-90, 90);
                randomRotY = UnityEngine.Random.Range(-90, 90);
                randomRotZ = UnityEngine.Random.Range(-90, 90);
                decoratingThings[numberOfStartedThings * k + i] = Instantiate(prefab[randomPrefab], new Vector3(randomX, randomY, decoratingThings[k * numberOfStartedThings - 1 + i].transform.position.z + 30), Quaternion.Euler(randomRotX, randomRotY, randomRotZ));
            }
        }
        k++;
        Debug.Log("Created decorating platforms!");
        previousPos += 100;
    }

    private void AddDecoratingPlatforms(GameObject[] prefab, ref int startPos, int g)
    {
        Array.Resize(ref decoratingPlatforms, decoratingPlatforms.Length + 10);
        for (int i = 0; i < numberOfNeededDecorPlat; i++)
        {
            randomSide = UnityEngine.Random.Range(0, 2);
            if (randomSide == 0)
            {
                randomPrefab = UnityEngine.Random.Range(0, 2);
                randomX = UnityEngine.Random.Range(-40, -20);
                decoratingPlatforms[numberOfNeededDecorPlat * g + i] = Instantiate(prefab[randomPrefab], new Vector3(randomX, 10, decoratingPlatforms[numberOfNeededDecorPlat * g - 1 + i].transform.position.z + 50), Quaternion.Euler(-90, 0, 0));
            }
            if (randomSide == 1)
            {
                randomPrefab = UnityEngine.Random.Range(0, 2);
                randomX = UnityEngine.Random.Range(20, 40);
                decoratingPlatforms[numberOfNeededDecorPlat * g + i] = Instantiate(prefab[randomPrefab], new Vector3(randomX, 10, decoratingPlatforms[numberOfNeededDecorPlat * g - 1 + i].transform.position.z + 50), Quaternion.Euler(-90, 0, 0));
            }
        }
        g++;
        startPos += 100;
    }
}
