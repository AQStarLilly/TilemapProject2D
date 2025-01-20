using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, GameInput.IPlayerActions
{

    private GameInput gameInput;

    void Awake()
    {
        gameInput = new GameInput();
        gameInput.Player.Enable();

        gameInput.Player.SetCallbacks(this);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Movement started : " + context.ReadValue<Vector2>());
            Actions.MoveEvent?.Invoke(context.ReadValue<Vector2>());
        }      
        else if (context.canceled)
        {
            Debug.Log("Movement stopped.");
            Actions.MoveEvent?.Invoke(Vector2.zero);
        }       
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("Interaction started.");
            Actions.InteractionEvent?.Invoke(true);
        }
        else if (context.canceled)
        {
            Debug.Log("Interaction stopped.");
            Actions.InteractionEvent?. Invoke(false); 
        }
    }
}


public static class Actions
{
    public static Action<Vector2> MoveEvent;
    public static Action<bool> InteractionEvent;
}
