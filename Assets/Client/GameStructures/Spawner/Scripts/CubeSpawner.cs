using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CubeSpawner : MonoBehaviour
{
    const int CUBE_COUNT = 1;
    const bool AUTO_EXPAND = true;


    [SerializeField]
    private Cube _prefab;
    [SerializeField]
    private Transform _container;
    [SerializeField]
    private float _spawnDelay = 1.0f;
    [SerializeField]
    private float _cubeSpeed = 1.0f;
    [SerializeField]
    private float _cubeLifeTime = 1.0f;
    [SerializeField]
    private Vector3 _dirrection = Vector3.right;



    public float Speed => _cubeSpeed;
    public float Delay => _spawnDelay;
    public float LifeTime => _cubeLifeTime;

    private Coroutine spawn;
    private Pool<Cube> cubePool;
    private bool isActive = false;
    private void Awake()
    {
        cubePool = new Pool<Cube>(_prefab, CUBE_COUNT, _container, AUTO_EXPAND);
    }

    public void StartSpawn()
    {
        if(spawn == null)
            spawn = StartCoroutine(SpawnRoutine());
    }
    public void StopSpawn()
    {
        spawn = null;
        StopAllCoroutines();
    }

    public void SpawnCube()
    {
        var cube = cubePool.GetFreeObject(transform.position);
        cube.Move(_dirrection, _cubeSpeed * 0.1f, _cubeLifeTime);

    }

    public IEnumerator SpawnRoutine()
    {
        isActive = true;
        while(isActive)
        {
            yield return new WaitForSeconds(_spawnDelay);
            SpawnCube();
        }
    }

    public void ChangeValues(float delay,float speed,float lifeTime)
    {
        _spawnDelay = delay;
        _cubeSpeed = speed;
        _cubeLifeTime = lifeTime;
    }

}
