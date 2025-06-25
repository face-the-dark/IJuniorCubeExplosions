using UnityEngine;

public class Reducer : MonoBehaviour
{
    [SerializeField] private int _scaleDivider = 2;

    public void ReduceScale()
    {
        float reducedLocalScaleX = transform.localScale.x / _scaleDivider;
        float reducedLocalScaleY = transform.localScale.y / _scaleDivider;
        float reducedLocalScaleZ = transform.localScale.z / _scaleDivider;

        transform.localScale = new Vector3(reducedLocalScaleX, reducedLocalScaleY, reducedLocalScaleZ);
    }
}