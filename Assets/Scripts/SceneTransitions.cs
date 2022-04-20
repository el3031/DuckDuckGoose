using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField] private string nextScene;
    
    public void OnNextScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
