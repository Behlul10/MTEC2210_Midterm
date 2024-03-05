using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform northPoint;
    public Transform southPoint;
    public Transform westPoint;
    public Transform eastPoint;

    public float CoinSpawnDelay = 2;
    float timeElapsed = 0; // by default if you dont state public or private it will be private

    [Range(1, 10)] public int coinCount;
    int currentCoinCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update() 
    {
       if (timeElapsed < CoinSpawnDelay) 
        {
            timeElapsed += Time.deltaTime;
        }
        else 
        {
            SpawnCoin();
            timeElapsed = 0;
        }
    }

    public void SpawnCoin()
    {
        if (currentCoinCount < coinCount) 
        {
            GameObject coinClone = Instantiate(coinPrefab, SpawnPos(), Quaternion.identity);
            currentCoinCount++;
        }
    }

    private Vector2 SpawnPos() 
    {
        float xValue = Random.Range(westPoint.position.x, eastPoint.position.x);
        float yValue = Random.Range(northPoint.position.y, southPoint.position.y);
        Vector2 temp = new Vector2(xValue, yValue);
        return temp;
    }
}
