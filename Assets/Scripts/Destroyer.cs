using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public void DestroyCube(Cube cube) => 
        Destroy(cube.gameObject);
}