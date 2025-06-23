using System;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class Exploder : MonoBehaviour
    {
        [SerializeField] private float _explosionForce = 1.0f;
        [SerializeField] private float _explosionRadius = 1.0f;

        private Rigidbody _rigidbody;

        public event Action Exploded;

        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnMouseUpAsButton()
        {
            Explode();
        }

        private void Explode()
        {
            _rigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            
            Exploded?.Invoke();
        }
    }
}