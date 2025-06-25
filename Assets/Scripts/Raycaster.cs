using System;
using UnityEngine;

[RequireComponent(typeof(InputHandler))]
public class Raycaster : MonoBehaviour
{
    private InputHandler _inputHandler;
        
    public event Action<Cube> RayHit;

    private void Awake() => 
        _inputHandler = GetComponent<InputHandler>();

    private void OnEnable() => 
        _inputHandler.MouseButtonPressed += CastRay;

    private void OnDisable() => 
        _inputHandler.MouseButtonPressed -= CastRay;

    private void CastRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        bool isHit = Physics.Raycast(ray, out RaycastHit hit);

        if (isHit && HasCubeComponent(hit, out Cube instance)) 
            RayHit?.Invoke(instance);
    }
        
    private bool HasCubeComponent(RaycastHit hit, out Cube cube) => 
        hit.collider.TryGetComponent(out cube);
}