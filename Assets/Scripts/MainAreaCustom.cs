using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAreaCustom : MonoBehaviour
{
    [SerializeField] private Material selectedMaterial;
    private Material originalMaterial;
    private Renderer r;

    void Start()
    {
        r = GetComponent<Renderer>();
        
        originalMaterial = r.material;
    }

    
    public void OnHoverEnter()
    {
        r.material = selectedMaterial;
    }

    public void OnHoverExit()
    {
        r.material = originalMaterial;
    }
}
