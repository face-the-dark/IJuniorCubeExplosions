using System.Collections.Generic;
using UnityEngine;

namespace Components
{
    [RequireComponent(typeof(Exploder))]
    [RequireComponent(typeof(Instantiator))]
    [RequireComponent(typeof(Destroyer))]
    [RequireComponent(typeof(ChanceDivider))]
    public class ExplodeHandler : MonoBehaviour
    {
        private Exploder _exploder;
        private Instantiator _instantiator;
        private Destroyer _destroyer;
        private ChanceDivider _chanceDivider;

        private void Awake()
        {
            _exploder = GetComponent<Exploder>();
            _instantiator = GetComponent<Instantiator>();
            _destroyer = GetComponent<Destroyer>();
            _chanceDivider = GetComponent<ChanceDivider>();
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
            if (_chanceDivider.IsDivide())
            {
                List<GameObject> instantiatedObjects = _instantiator.InstantiateObjects();

                foreach (GameObject instantiatedObject in instantiatedObjects)
                {
                    Reduce(instantiatedObject);
                    ChangeColor(instantiatedObject);
                    SetNewDivideChance(instantiatedObject);
                }
            }
            
            _destroyer.DestroyGameObject(gameObject);
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
            bool hasChanceDivider = instantiatedObject.TryGetComponent(out ChanceDivider chanceDivider);

            if (hasChanceDivider)
            {
                chanceDivider.SetNewDivideChance(_chanceDivider.CurrentDivideChance);
            }
        }
    }
}