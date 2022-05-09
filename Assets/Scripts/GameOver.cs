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
        PlayerPrefs.DeleteKey("hunger");
        PlayerPrefs.DeleteKey("affection");
        PlayerPrefs.DeleteKey("mushrooms");
        PlayerPrefs.DeleteKey("timeElapsed");
        GetComponent<SceneTransitions>().OnNextScene();
    }
}
