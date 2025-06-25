using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private float _currentSplitProbability = 1f;
    [SerializeField] private float _probabilityDivider = 2f;
    [SerializeField] private float _minProbabilityNumber = 0f;
    [SerializeField] private float _maxProbabilityNumber = 1f;

    public float CurrentSplitProbability => _currentSplitProbability;

    public bool CanSplit()
    {
        float randomNumber = Random.Range(_minProbabilityNumber, _maxProbabilityNumber);
            
        return randomNumber <= _currentSplitProbability;
    }

    public void SetReducedSplitProbability(float previousSplitProbability)
    {
        _currentSplitProbability = previousSplitProbability / _probabilityDivider;
    }
}