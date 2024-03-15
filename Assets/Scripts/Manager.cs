using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject frogPrefab;
    public GameObject duckPrefab;

    public Transform northPoint;
    public Transform eastPoint;
    public Transform westPoint;
    public Transform southPoint;

    public float coinSpawnDelay = 2;
    public float duckSpawnDelay = 2;
    public float frogSpawnDelay = 2;
    float timeElapsed = 0;
    float timeElapsedDuck = 0;
    float timeElapsedFrog = 0;

    [Range(1, 25)] public int coinCount = 5;
    int currentCoinCount = 0;


    [Range(1, 25)] public int duckCount = 5;
    int currentDuckCount = 0;


    [Range(1, 25)] public int frogCount = 5;
    int currentFrogCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Duck spawn 
        if(timeElapsedDuck < duckSpawnDelay)
        {
            timeElapsedDuck += Time.deltaTime;
        }
        else
        {
            SpawnDuck();
            timeElapsedDuck = 0;
        }
        // Frog spawn 
        if (timeElapsedFrog < frogSpawnDelay)
        {
            timeElapsedFrog += Time.deltaTime;
        }
        else
        {
            SpawnFrog();
            timeElapsedFrog = 0;
        }
        // Coin spawn
        if (timeElapsed < coinSpawnDelay)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            SpawnCoin();
            timeElapsed = 0;
        }

    }
    public void SpawnDuck()
    {
        if (currentDuckCount < duckCount)
        {
            GameObject DuckClone = Instantiate(duckPrefab, SpawnPos(), Quaternion.identity);
            currentDuckCount++;
        }
    }

    public void SpawnFrog()
    {
        if(currentFrogCount < frogCount)
        {
            GameObject frogClone = Instantiate(frogPrefab, SpawnPos(), Quaternion.identity);
            currentFrogCount++;
        }
    }
    public void SpawnCoin()
    {
        if(currentCoinCount < coinCount)
        {
            GameObject coinClone = Instantiate(coinPrefab, SpawnPos(), Quaternion.identity);
            currentCoinCount++;
        }
    }

    private Vector2 SpawnPos()
    {
        float xValue = Random.Range(westPoint.position.x, eastPoint.position.x);
        float yValue = northPoint.position.y;
        Vector2 temp = new Vector2(xValue, yValue);
        return temp;

    }
}
