using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPref;
    public GameObject CoinPref;
    private Vector2 currentPos;
    private float timePassed;
    private bool isSpawnerBusy = false;
    private float _cooldown;

    [SerializeField] private int coinsLength;
    [SerializeField] private float timeBetweenSpawn;
    
    private void Update()
    {
        currentPos = transform.position;
        SpawnSaw();
        SpawnCoins();
    }

    private void SpawnSaw()
    {
        if (Random.Range(0, 100) == 50 && !isSpawnerBusy)
        {
            isSpawnerBusy = true;
            Instantiate(EnemyPref, currentPos, Quaternion.identity);
            do {
                _cooldown += Time.deltaTime;
            } while (_cooldown <= 3f);

            isSpawnerBusy = false;
            _cooldown = 0f;
        }
    }

    private void SpawnCoins()
    {
        if (timePassed >= timeBetweenSpawn && !isSpawnerBusy)
        {
            isSpawnerBusy = true;
            for (int i = 0; i < coinsLength; i++)
            {
                currentPos.x += 1;
                currentPos.y = 1;
                Instantiate(CoinPref, currentPos, Quaternion.identity);
            }

            do
            {
                _cooldown += Time.deltaTime;
            } while (_cooldown <= 3f);

            isSpawnerBusy = false;
            _cooldown = 0f;
            timePassed = 0;
        }
        else
            timePassed += Time.deltaTime;
    }
}
