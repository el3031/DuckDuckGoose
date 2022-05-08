using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class ObjectManip : MonoBehaviour
{
    [SerializeField] private SelectionTracker selectionTracker;
    [SerializeField] private InputActionReference rotateReference;
    [SerializeField] private InputActionReference translateReference;
    [SerializeField] private float rotateIncrement;
    [SerializeField] private float translateIncrement;

    [SerializeField] private Text rotate;
    [SerializeField] private Text translate;

    float timeToGo;

    public bool rotateScriptActive = false;

    void Start()
    {
        timeToGo = Time.fixedTime + 0.5f;
    }

    

    
    private void OnTranslate(InputAction.CallbackContext context)
    {
        Vector2 val = context.ReadValue<Vector2>();
        translate.text = val.ToString();
        
        if (selectionTracker.selected != null)
        {
            Vector3 addPosition = new Vector3(val.x, 0f, val.y) * translateIncrement;
            selectionTracker.selected.transform.position += addPosition;
        }
    }
    
    private void FixedUpdate()
    {
        float val = rotateReference.action.ReadValue<float>();
        Vector2 translateVal = translateReference.action.ReadValue<Vector2>();
        if (
            gameObject == selectionTracker.selected
            &&
            val != 0f
        )
        {
            transform.Rotate(0f, val * rotateIncrement, 0f, Space.Self);
        }

        if (gameObject == selectionTracker.selected && translateVal != Vector2.zero)
        {
            Vector3 addPos = new Vector3(translateVal.x, 0f, translateVal.y);
            transform.position += addPos;
        }
    }
    
   
    private void OnRotate(InputAction.CallbackContext context)
    {
        Debug.Log("poop");
        float val = context.ReadValue<float>();
        rotate.text = val.ToString();
        if (selectionTracker.selected != null)
        {
            selectionTracker.selected.transform.Rotate(0f, val * rotateIncrement, 0f, Space.Self);
        }
    }
}
