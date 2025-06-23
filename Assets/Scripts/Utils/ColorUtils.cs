using UnityEngine;

namespace Utils
{
    public class ColorUtils
    {
        public Color GenerateColor()
        {
            float r = RandomUtils.GetFloatRandomNumber();
            float g = RandomUtils.GetFloatRandomNumber();
            float b = RandomUtils.GetFloatRandomNumber();
        
            return new Color(r, g, b);
        }
    }
}