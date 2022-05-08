using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.InputSystem;


public class MainAreaCustom : MonoBehaviour
{
    //all these variables deal with selection tracking
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private SelectionTracker selectionTracker;
    private Material originalMaterial;
    private Renderer r;

    // all these variables deal with transformations via button
    [SerializeField] private InputActionReference rotateReference;
    [SerializeField] private InputActionReference translateReference;
    [SerializeField] private float rotateIncrement;
    [SerializeField] private float translateIncrement;

    void Start()
    {
        r = GetComponent<Renderer>();
        
        originalMaterial = r.material;
    }

    
    public void OnHoverEnter()
    {
        selectionTracker.selected = this.gameObject;
    }

    public void OnHoverExit()
    {
        selectionTracker.selected = null;
    }

    public void OnSelectExit()
    {
        StartCoroutine(MoveCorrect());
    }

    public IEnumerator MoveCorrect()
    {
        float timer = 0.5f;
        float time = 0f;

        Quaternion correctRotation = Quaternion.Euler(new Vector3(0f, transform.rotation.eulerAngles.y, 0f));
        Debug.Log(correctRotation.eulerAngles);
        Vector3 correctPosition = new Vector3(transform.position.x, 0f, transform.position.z);
        Debug.Log(correctPosition);
        while (time < timer)
        {
            time += Time.deltaTime;
            yield return null;
            transform.rotation = Quaternion.Slerp(transform.rotation, correctRotation, 2f * Time.deltaTime * timer / time);
            transform.position = Vector3.Lerp(transform.position, correctPosition, 2f * Time.deltaTime * timer / time);
        }
    }

    // all these functions deal with transformations by buttons    
    /*
    private void OnTranslate(InputAction.CallbackContext context)
    {
        Vector2 val = context.ReadValue<Vector2>();
        
        if (selectionTracker.selected != null)
        {
            Vector3 addPosition = (Camera.main.transform.right * val.x + Camera.main.transform.forward * val.y).normalized * translateIncrement;        
            selectionTracker.selected.transform.position += addPosition;
        }
    }
    */

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
            Vector3 addPos = (translateVal.x * Camera.main.transform.right + translateVal.y * Camera.main.transform.forward).normalized * translateIncrement; 
            transform.position += addPos;
        }
    }
    
    /*
    private void OnRotate(InputAction.CallbackContext context)
    {
        Debug.Log("poop");
        float val = context.ReadValue<float>();
        if (selectionTracker.selected != null)
        {
            selectionTracker.selected.transform.Rotate(0f, val * rotateIncrement, 0f, Space.Self);
        }
    }
    */
}
