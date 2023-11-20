using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _pointsList;
    [SerializeField] private Medpack _medpack;

    private readonly float _spawnFrequency = 60;
    private Transform[] _points;

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
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        bool isSpawning = true;
        WaitForSeconds spawnDelay = new WaitForSeconds(_spawnFrequency);
        Vector3[] emptySpots;

        while (isSpawning)
        {
            emptySpots = FindEmptyPoints();
            
            if(emptySpots.Length > 0)
                Instantiate(_medpack, emptySpots[Random.Range(0, emptySpots.Length)], Quaternion.identity);

            yield return spawnDelay;
        }
    }

    private Vector3[] FindEmptyPoints()
    {
        string tag = _medpack.tag;
        Vector3[] emptySpots = _points.Select(point => point.position).
            Except(GameObject.FindGameObjectsWithTag(tag).Select(creature => creature.transform.position)).
            ToArray();

        return emptySpots;
    }
}
