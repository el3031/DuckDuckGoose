using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleMinimap : MonoBehaviour
{
    [SerializeField] private InputActionReference toggleMapReference;
    
    // Start is called before the first frame update
    void Awake()
    {
        toggleMapReference.action.started += Toggle;
    }

    void OnDestroy()
    {
        toggleMapReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        bool isActive = !gameObject.activeSelf;
        gameObject.SetActive(isActive);
    }
}
