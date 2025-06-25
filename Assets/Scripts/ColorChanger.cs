using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChanger : MonoBehaviour
{
    private static readonly int ColorNameId = Shader.PropertyToID("_Color");

    private Renderer _renderer;

    public void GenerateRandomColor()
    {
        _renderer = GetComponent<Renderer>();
        _renderer.material.SetColor(ColorNameId, Random.ColorHSV());
    }
}