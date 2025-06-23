using UnityEngine;

namespace Components
{
    public class Destroyer : MonoBehaviour
    {
        public void DestroyGameObject(GameObject objectToDestroy)
        {
            Destroy(objectToDestroy);
        }
    }
}