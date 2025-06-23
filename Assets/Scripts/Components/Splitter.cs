using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Components
{
    public class Splitter : MonoBehaviour
    {
        [SerializeField] private float _currentSplitProbability = 1f;
        [SerializeField] private float _probabilityDivider = 2f;

        public float CurrentSplitProbability => _currentSplitProbability;

        public bool CanSplit()
        {
            float randomNumber = RandomUtils.GetFloatRandomNumber();
            
            return randomNumber <= _currentSplitProbability;
        }

        public void SetReducedSplitProbability(float previousSplitProbability)
        {
            _currentSplitProbability = previousSplitProbability / _probabilityDivider;
        }
    }
}