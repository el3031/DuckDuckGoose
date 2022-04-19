using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeDuck : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    
    public void Explode()
    {
        Vector3 duckPos = transform.position;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
