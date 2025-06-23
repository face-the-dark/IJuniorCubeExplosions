using UnityEngine;
using Utils;

namespace Components
{
    [RequireComponent(typeof(MeshRenderer))]
    public class ColorChanger : MonoBehaviour
    {
        private static readonly int ColorNameId = Shader.PropertyToID("_Color");

        private Renderer _renderer;
        private ColorUtils _colorUtils;

        private void Initialize()
        {
            _renderer = GetComponent<Renderer>();
            _colorUtils = new ColorUtils();
        }

        public void GenerateRandomColor()
        {
            Initialize();
            
            Color color = _colorUtils.GenerateColor();
            _renderer.material.SetColor(ColorNameId, color);
        }
    }
}