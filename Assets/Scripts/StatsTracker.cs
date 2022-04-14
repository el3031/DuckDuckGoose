using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsTracker : MonoBehaviour
{
    public int mushrooms;
    [SerializeField] private Text patPatTracker;
    [SerializeField] private Image[] hearts;
    private float affection;
    
    // Start is called before the first frame update
    void Start()
    {
        mushrooms = PlayerPrefs.GetInt("mushrooms", 0);

        affection = Mathf.Floor(Random.Range(0f, 5f));
        Debug.Log(affection);

        patPatTracker.text = patPatTracker.ToString();
        AffectionDisplay();
    }

    void AffectionDisplay()
    {
        int counter = (int) Mathf.Min(Mathf.Floor(affection), hearts.Length - 1);
        
        for (int i = 0; i < counter; i++)
        {
            Color c = hearts[i].color;
            c.a = 1f;

            hearts[i].color = c;
        }
    }

    public void IncreaseAffection(int i)
    {
        affection += i * 0.1f;
        patPatTracker.text = affection.ToString();

        AffectionDisplay();
    }
}
