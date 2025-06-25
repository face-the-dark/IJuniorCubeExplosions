using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Destroyer))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minSpawnClonesNumber = 2;
    [SerializeField] private int _maxSpawnClonesNumber = 6;
        
    private Destroyer _destroyer;

    private void Awake() => 
        _destroyer = GetComponent<Destroyer>();

    public List<Cube> SpawnClones(Cube parent)
    {
        List<Cube> cubes = new List<Cube>();
        
        int cubesNumber = Random.Range(_minSpawnClonesNumber, _maxSpawnClonesNumber);

        for (int i = 0; i < cubesNumber; i++)
        {
            Cube cube = SpawnClone(parent);
            cubes.Add(cube);
        }

        return cubes;
    }

    public void DestroyCube(Cube cube) => 
        _destroyer.DestroyCube(cube);

    private Cube SpawnClone(Cube parent) => 
        Instantiate(parent, parent.transform.position, parent.transform.rotation);
}