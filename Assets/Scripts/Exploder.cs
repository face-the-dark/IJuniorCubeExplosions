using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 1.0f;
    [SerializeField] private float _explosionRadius = 1.0f;

    public void Explode(Cube cube)
    {
        if (cube.TryGetComponent(out Rigidbody instanceRigidbody)) 
            instanceRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}