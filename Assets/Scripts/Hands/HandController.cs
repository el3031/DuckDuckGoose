using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    [SerializeField] InputActionReference controllerActionGrip;
    [SerializeField] InputActionReference controllerActionTrigger;

    private Animator _handAnimator;

    private void Awake()
    {
        controllerActionGrip.action.performed += GripPress;
        controllerActionTrigger.action.performed += TriggerPress;

        controllerActionGrip.action.canceled += GripCancel;
        controllerActionTrigger.action.canceled += TriggerCancel;

        _handAnimator = GetComponent<Animator>();

    }

    private void GripPress(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }

    private void TriggerPress(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
        Debug.Log("Trigger value: " + obj.ReadValue<float>());
    }

    private void GripCancel(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Grip", 0);
    }

    private void TriggerCancel(InputAction.CallbackContext obj)
    {
        _handAnimator.SetFloat("Trigger", 0);
    }


}
