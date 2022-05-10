using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField]
    private string nextScene;

    public void OnNextScene()
    {
        if (nextScene == "MainArea")
        {
            PlayerPrefs
                .SetInt("removeHunger",
                ((int) Mathf.Round(Time.timeSinceLevelLoad)) / 20);
        }
        PlayerPrefs
            .SetFloat("timeElapsed",
            PlayerPrefs.GetFloat("timeElapsed", 0) + Time.timeSinceLevelLoad);
        SceneManager.LoadScene (nextScene);
    }
}
