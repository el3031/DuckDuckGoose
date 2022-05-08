using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExplodeDuck : MonoBehaviour
{
    [SerializeField] private GameObject explosion;
    
    public void Explode()
    {
        StartCoroutine(ExplodeAndRestart());
    }

    IEnumerator ExplodeAndRestart()
    {
        Vector3 duckPos = transform.position;
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("gameOver");
    }
}
