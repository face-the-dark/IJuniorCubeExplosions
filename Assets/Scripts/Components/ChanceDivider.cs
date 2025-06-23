using UnityEngine;
using Utils;

namespace Components
{
    public class ChanceDivider : MonoBehaviour
    {
        [SerializeField] private float _currentDivideChance = 1f;
        [SerializeField] private float _divider = 2f;

        public float CurrentDivideChance => _currentDivideChance;

        public bool IsDivide()
        {
            float randomNumber = RandomUtils.GetFloatRandomNumber();
            
            return randomNumber <= _currentDivideChance;
        }

        public void SetNewDivideChance(float lastChanceDivide)
        {
            _currentDivideChance = lastChanceDivide / _divider;
        }
    }
}