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
}
