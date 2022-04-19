using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsTracker : MonoBehaviour
{
    public int mushrooms;
    [SerializeField] private Text patPatTracker;
    [SerializeField] private Image[] hearts;
    private int affection;
    
    // Start is called before the first frame update
    void Start()
    {
        mushrooms = PlayerPrefs.GetInt("mushrooms", 0);

        affection = 10 * (int) Mathf.Floor(Random.Range(0f, 5f));

        patPatTracker.text = patPatTracker.ToString();
        AffectionDisplay();
    }

    void AffectionDisplay()
    {
        int counter = (int) Mathf.Min(affection / 10, hearts.Length);
        
        for (int i = 0; i < counter; i++)
        {
            Color c = hearts[i].color;
            c.a = 1f;

            hearts[i].color = c;
        }
    }

    public void IncreaseAffection(int i)
    {
        affection += i;
        patPatTracker.text = affection.ToString();

        if (affection % 10 == 0)
        {
            AffectionDisplay();
        }
    }
}
