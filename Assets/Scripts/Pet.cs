using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    [SerializeField] private GameObject hearts;
    [SerializeField] private float offset;
    [SerializeField]
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHoverEnter()
    {
        Instantiate(hearts, transform.position + Vector3.up * offset, Quaternion.identity);
    }
}
