using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : PoolingManager
{
    public Transform spawnPoint;
    public int poolSize;
    public float timeBetweenSpawns;
    public GameObject prefab;

    private List<GameObject> _balloons;
    private GameObject _activeBalloon;
    private ObjectPoolManager _OPM;
    private int _balloonCount;

    private void Awake()
    {
        _OPM = ObjectPoolManager.Instance;
        _balloonCount = 0;
        _balloons = CreateList(prefab, poolSize);
    }


    private void Update()
    {
        if (_balloonCount < poolSize)
        {
            if (Time.frameCount % 30 == 0)
            {
                StartCoroutine(SpawnBalloon());
            }
        }        
    }


    /*
     * Spawns prefab at spawnPoint
     * void -> void
     */
    private IEnumerator SpawnBalloon()
    {
        _activeBalloon = GetObjectFromPool(_balloons);

        if (_activeBalloon)
        {
            _activeBalloon.transform.position = spawnPoint.position;
            _activeBalloon.transform.rotation = spawnPoint.rotation;
            _activeBalloon.SetActive(true);
            ChangeBalloonCount(1);
        }
        else
        {
            Debug.Log("There aren't any balloons available right now.");
        }

        yield return new WaitForSeconds(timeBetweenSpawns);
    }


    public void ChangeBalloonCount(int x)
    {
        _balloonCount += x;
    }
}
