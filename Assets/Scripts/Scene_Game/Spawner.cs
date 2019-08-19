using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPref;
    public GameObject CoinPref;
    private Vector2 currentPos;
    private float timePassed;

    [SerializeField] private float timeBetweenSpawn;


    private void Update()
    {
        currentPos = transform.position;
        SpawnSaw();
    }

    private void SpawnSaw()
    {
        if (Random.Range(0, 100) == 50)
                Instantiate(EnemyPref, currentPos, Quaternion.identity);
    }

    private void SpawnCoins()
    {
        if (timePassed >= timeBetweenSpawn)
        {
            Instantiate(CoinPref, currentPos, Quaternion.identity);
            timePassed = 0;
        }
        else
            timePassed += Time.deltaTime;
    }
}
