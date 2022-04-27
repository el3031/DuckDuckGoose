using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAreaCustom : MonoBehaviour
{
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private SelectionTracker selectionTracker;
    private Material originalMaterial;
    private Renderer r;

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
        float timer = 0.5f;
        float time = 0f;

        Quaternion correctRotation = Quaternion.Euler(new Vector3(0f, transform.rotation.y, 0f));
        while (time < timer)
        {
            time += Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, correctRotation, Time.deltaTime * time / timer);
        }
    }
}
