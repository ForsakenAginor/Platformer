using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointsList;
    [SerializeField] private GameObject _creature;

    private Transform[] _points;
    private float _spawnFrequency = 60;

    private void Awake()
    {
        _points = new Transform[_pointsList.childCount];

        for (int i = 0; i < _points.Length; i++)
        {
            _points[i] = _pointsList.GetChild(i);
        }
    }

    private void Start()
    {
        var spawner = StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        bool isSpawning = true;

        while (isSpawning)
        {
            Instantiate(_creature, _points[Random.Range(0, _points.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(_spawnFrequency);
        }
    }
}
