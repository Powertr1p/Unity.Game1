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
    private float _cooldown = 0;

    [SerializeField] private int coinsLength;
    [SerializeField] private float timeBetweenSpawn;

    private void Awake()
    {
        coinsLength = 4;
        timeBetweenSpawn = 2;
    }

    private void Update()
    {
        currentPos = transform.position;
        SpawnSaw();
        SpawnCoins();
    }

    private void SpawnSaw()
    {
        if (Random.Range(0, 200) == 100 && !isSpawnerBusy)
        {
            isSpawnerBusy = true;
            currentPos.y = Random.Range(1, 3);
            Instantiate(EnemyPref, currentPos, Quaternion.identity);
            do {
                _cooldown += Time.deltaTime;
            } while (_cooldown < 5f);

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
