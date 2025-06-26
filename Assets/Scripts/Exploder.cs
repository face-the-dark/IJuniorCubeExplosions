using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 1.0f;
    [SerializeField] private float _explosionRadius = 1.0f;
    
    public void Explode(Cube cube)
    {
        if (cube.TryGetComponent(out Rigidbody cubeRigidbody)) 
            cubeRigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
    }

    public void ExplodeAround(Cube cube)
    {
        foreach (Rigidbody nearCubeRigidbody in GetCubesAround(cube.transform.position)) 
            nearCubeRigidbody.AddExplosionForce(_explosionForce, nearCubeRigidbody.transform.position, _explosionRadius,
                0f, ForceMode.Impulse);
    }

    private List<Rigidbody> GetCubesAround(Vector3 cubeTransformPosition)
    {
        Collider[] cubesColliders = Physics.OverlapSphere(cubeTransformPosition, _explosionRadius);
        
        List<Rigidbody> cubes = new List<Rigidbody>();

        foreach (Collider cubeCollider in cubesColliders)
            if (cubeCollider.attachedRigidbody != null)
                cubes.Add(cubeCollider.attachedRigidbody);
        
        return cubes;
    }
}