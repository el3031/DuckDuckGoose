using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class HandToggle : MonoBehaviour
{
    public InputActionReference toggleReference = null;

    private XRInteractorLineVisual line;

    private XRRayInteractor interactor;

    // Start is called before the first frame update
    private void Awake()
    {
        line = GetComponent<XRInteractorLineVisual>();
        interactor = GetComponent<XRRayInteractor>();

        toggleReference.action.started += Toggle;
    }

    // Update is called once per frame
    private void OnDestroy()
    {
        toggleReference.action.started -= Toggle;
    }

    private void Toggle(InputAction.CallbackContext context)
    {
        bool isEnabled = line.enabled;
        if (isEnabled)
        {
            interactor.maxRaycastDistance = 0.5f;
        }
        else
        {
            interactor.maxRaycastDistance = 10;
        }
        line.enabled = !isEnabled;
    }
}
