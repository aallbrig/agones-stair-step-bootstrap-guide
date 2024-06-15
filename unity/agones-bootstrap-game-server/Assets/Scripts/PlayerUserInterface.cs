using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerUserInterface : MonoBehaviour
{
    [SerializeField] private UIDocument diceThrowDocument;
    [SerializeField]
    private NetworkPlayerController networkPlayerController;

    private void Awake()
    {
        diceThrowDocument.enabled = false;
    }
    private void OnNavigate(InputValue inputValue)
    {
        
    }
    private void OnSubmit(InputValue inputValue)
    {
        
    }
    private void OnCancel(InputValue inputValue)
    {
        
    }
    private void OnDiceMenuOpen(InputValue inputValue)
    {
        if (inputValue.Get<bool>())
        {
            diceThrowDocument.enabled = true;
        }
    }
}
