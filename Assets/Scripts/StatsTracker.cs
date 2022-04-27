using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsTracker : MonoBehaviour
{
    public int mushrooms;

    [SerializeField]
    private Text patPatTracker;

    [SerializeField]
    private Image[] hearts;

    [SerializeField]
    private Text hungerTracker;

    [SerializeField]
    private Image[] hungerIcons;

    private int affection;

    private int hunger;

    // Start is called before the first frame update
    void Start()
    {
        mushrooms = PlayerPrefs.GetInt("mushrooms", 0);

        affection = 10 * (int) Mathf.Floor(Random.Range(0f, 5f));
        hunger = 10 * (int) Mathf.Floor(Random.Range(0f, 5f));

        patPatTracker.text = "Affection: " + affection.ToString();
        hungerTracker.text = "Hunger: " + hunger.ToString();
        AffectionDisplay();
        HungerDisplay();
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

    void HungerDisplay()
    {
        int counter = (int) Mathf.Min(hunger / 10, hungerIcons.Length);

        for (int i = 0; i < counter; i++)
        {
            Color c = hungerIcons[i].color;
            c.a = 1f;

            hungerIcons[i].color = c;
        }
    }

    public void IncreaseAffection(int i)
    {
        affection += i;
        patPatTracker.text = "Affection: " + affection.ToString();

        if (affection % 10 == 0)
        {
            AffectionDisplay();
        }
    }

    public void IncreaseHungerBar(int i)
    {
        hunger += i;
        hungerTracker.text = "Hunger: " + hunger.ToString();

        if (hunger % 10 == 0)
        {
            HungerDisplay();
        }
    }
}
