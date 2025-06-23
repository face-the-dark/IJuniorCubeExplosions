using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Exploder))]
    [RequireComponent(typeof(Instantiator))]
    [RequireComponent(typeof(Destroyer))]
    [RequireComponent(typeof(Splitter))]
    public class ExplodeHandler : MonoBehaviour
    {
        private Exploder _exploder;
        private Instantiator _instantiator;
        private Destroyer _destroyer;
        private Splitter _splitter;

        private void Awake()
        {
            _exploder = GetComponent<Exploder>();
            _instantiator = GetComponent<Instantiator>();
            _destroyer = GetComponent<Destroyer>();
            _splitter = GetComponent<Splitter>();
        }

        private void OnEnable()
        {
            _exploder.Exploded += OnExplode;
        }

        private void OnDisable()
        {
            _exploder.Exploded -= OnExplode;
        }

        private void OnExplode()
        {
            if (_splitter.CanSplit())
            {
                List<GameObject> instantiatedObjects = _instantiator.InstantiateСlones();

                foreach (GameObject instantiatedObject in instantiatedObjects)
                {
                    Reduce(instantiatedObject);
                    ChangeColor(instantiatedObject);
                    SetNewDivideChance(instantiatedObject);
                }
            }
            
            _destroyer.DestroyObject(gameObject);
        }

        private void Reduce(GameObject instantiatedObject)
        {
            bool hasReducer = instantiatedObject.TryGetComponent(out Reducer reducer);

            if (hasReducer)
            {
                reducer.ReduceScale();
            }
        }
        
        private void ChangeColor(GameObject instantiatedObject)
        {
            bool hasColorChanger = instantiatedObject.TryGetComponent(out ColorChanger colorChanger);

            if (hasColorChanger)
            {
                colorChanger.GenerateRandomColor();
            }
        }

        private void SetNewDivideChance(GameObject instantiatedObject)
        {
            bool hasChanceDivider = instantiatedObject.TryGetComponent(out Splitter chanceDivider);

            if (hasChanceDivider)
            {
                chanceDivider.SetReducedSplitProbability(_splitter.CurrentSplitProbability);
            }
        }
    }
}