using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 100.0f;
    [SerializeField] private float _explosionRadius = 10.0f;
    [SerializeField] private float _minDistanceBetweenCubes = 0.1f;
    
    public void Explode(Cube cube)
    {
        if (cube.TryGetComponent(out Rigidbody cubeRigidbody)) 
            cubeRigidbody.AddExplosionForce(_explosionForce, cube.transform.position, _explosionRadius);
    }

    public void ExplodeAround(Cube cube)
    {
        foreach (Rigidbody nearCubeRigidbody in GetCubesAround(cube.transform.position))
        {
            float explosionRadius = CalculateExplosionRadius(nearCubeRigidbody.transform.localScale);
            float distance = CalculateDistance(cube.transform.position, nearCubeRigidbody.transform.position);
            float explosionForce = CalculateExplosionForce(distance, explosionRadius);

            nearCubeRigidbody.AddExplosionForce(explosionForce, cube.transform.position, explosionRadius,
                0f, ForceMode.Impulse);
        }
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

    private float CalculateExplosionRadius(Vector3 transformLocalScale)
    {
        const float AxisNumber = 3f;
        
        float averageScale = (transformLocalScale.x + transformLocalScale.y + transformLocalScale.z) / AxisNumber;

        float explosionRadiusModifier = _explosionRadius / averageScale;
        float explosionRadius = _explosionRadius * explosionRadiusModifier;
        
        return explosionRadius;
    }

    private float CalculateDistance(Vector3 firstCubePosition, Vector3 secondCubePosition)
    {
        float distance = Vector3.Distance(firstCubePosition, secondCubePosition);

        if (distance < _minDistanceBetweenCubes)
        {
            distance = _minDistanceBetweenCubes;
        }

        return distance;
    }

    private float CalculateExplosionForce(float distance, float explosionRadius)
    {
        float explosionForceModifier = distance / explosionRadius;
        float explosionForce = _explosionForce / explosionForceModifier;
        
        return explosionForce;
    }

    private void OnDrawGizmos()
    {
        Cube[] cubes = FindObjectsByType<Cube>(FindObjectsInactive.Exclude, FindObjectsSortMode.InstanceID);

        foreach (Cube cube in cubes)
        {
            Color color = Color.red;
            color.a = 0.5f;
            Gizmos.color = color;
            Gizmos.DrawSphere(cube.transform.position, CalculateExplosionRadius(cube.transform.localScale));
        }
    }
}