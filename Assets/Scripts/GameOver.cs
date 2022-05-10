using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI timeText;

    void Start()
    {
        float time = (int) PlayerPrefs.GetFloat("timeElapsed", 0.0f);
        int min = System.TimeSpan.FromSeconds(time).Minutes;
        int sec = System.TimeSpan.FromSeconds(time).Seconds;
        timeText.text = min + " minutes and " + sec + " seconds ";
    }

    // Update is called once per frame
    public void Restart()
    {
        PlayerPrefs.SetInt("affection", (int)(10 * Random.Range(0f, 3f)));
        PlayerPrefs.SetInt("hunger", (int)(10 * Random.Range(1f, 3f)));
        PlayerPrefs.SetInt("mushrooms", 0);
        PlayerPrefs.SetFloat("timeElapsed", 0);
        GetComponent<SceneTransitions>().OnNextScene();
    }
}
