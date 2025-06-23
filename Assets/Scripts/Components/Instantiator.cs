using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Components
{
    public class Instantiator : MonoBehaviour
    {
        [SerializeField] private int _minSpawnClonesNumber = 2;
        [SerializeField] private int _maxSpawnClonesNumber = 6;

        public List<GameObject> InstantiateСlones()
        {
            List<GameObject> clones = new List<GameObject>();

            int cubesNumber = RandomUtils.GetRandomNumber(_minSpawnClonesNumber, _maxSpawnClonesNumber);

            for (int i = 0; i < cubesNumber; i++)
            {
                GameObject clone = Instantiate(gameObject, transform.position, Quaternion.identity);
                clones.Add(clone);
            }
            
            return clones;
        }
    }
}