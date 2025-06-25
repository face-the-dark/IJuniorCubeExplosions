using System;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const int MouseButton = 0;
        
    public event Action MouseButtonPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton)) 
            MouseButtonPressed?.Invoke();
    }
}