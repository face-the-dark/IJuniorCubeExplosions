using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Exploder))]
[RequireComponent(typeof(Spawner))]
[RequireComponent(typeof(Raycaster))]
public class ExplodeHandler : MonoBehaviour
{
    private Exploder _exploder;
    private Spawner _spawner;
    private Raycaster _raycaster;
    private CubeBuilder _cubeBuilder;

    private void Awake()
    {
        _exploder = GetComponent<Exploder>();
        _spawner = GetComponent<Spawner>();
        _raycaster = GetComponent<Raycaster>();
        _cubeBuilder = new CubeBuilder();
    }

    private void OnEnable() =>
        _raycaster.RayHit += OnRayHit;

    private void OnDisable() =>
        _raycaster.RayHit -= OnRayHit;

    private void OnRayHit(Cube cube)
    {
        bool hasSplitter = cube.TryGetComponent(out Splitter splitter);

        if (hasSplitter && splitter.CanSplit())
        {
            List<Cube> spawnCubes = _spawner.SpawnClones(cube);
            _cubeBuilder.BuildCubes(cube, spawnCubes);
            
            _exploder.Explode(cube);
        }
        else
        {
            _exploder.ExplodeAround(cube);
        }

        _spawner.DestroyCube(cube);
    }
}