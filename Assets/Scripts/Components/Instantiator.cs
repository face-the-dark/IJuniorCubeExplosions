using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace Components
{
    public class Instantiator : MonoBehaviour
    {
        [SerializeField] private int _minSpawnCubesNumber = 2;
        [SerializeField] private int _maxSpawnCubesNumber = 6;

        public List<GameObject> InstantiateObjects()
        {
            List<GameObject> gameObjects = new List<GameObject>();

            int cubesNumber = RandomUtils.GetRandomNumber(_minSpawnCubesNumber, _maxSpawnCubesNumber);

            for (int i = 0; i < cubesNumber; i++)
            {
                GameObject instantiate = Instantiate(gameObject, transform.position, Quaternion.identity);
                gameObjects.Add(instantiate);
            }
            
            return gameObjects;
        }
    }
}