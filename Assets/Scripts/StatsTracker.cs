using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public int hunger;

    public GameObject duck;

    // Start is called before the first frame update
    void Start()
    {
        mushrooms = PlayerPrefs.GetInt("mushrooms", 0);

        affection =
            PlayerPrefs.GetInt("affection", (int)(10 * Random.Range(0f, 3f)));
        hunger = PlayerPrefs.GetInt("hunger", (int)(10 * Random.Range(3f, 4f)));

        hunger -= PlayerPrefs.GetInt("removeHunger", 0);
        checkHunger();

        PlayerPrefs.SetInt("removeHunger", 0);
        patPatTracker.text = "Affection: " + affection.ToString();
        hungerTracker.text = "Fullness: " + hunger.ToString();
        AffectionDisplay();
        HungerDisplay();
        InvokeRepeating("decreaseHunger",
        20.0f,
        10 * (int) Mathf.Floor(Random.Range(3f, 4f)));
    }

    public void decreaseHunger()
    {
        int hungerDecrease = (int) Mathf.Floor(Random.Range(3f, 5f));
        duck.GetComponent<ShowStats>().waitTime = 0f;
        hunger -= hungerDecrease;
        checkHunger();
    }

    public void checkHunger()
    {
        if (hunger > 0)
        {
            HungerDisplay();
        }
        if (hunger < 0 || hunger > 50)
        {
            if (hunger > 50)
            {
                duck.GetComponent<ExplodeDuck>().Explode();
            }

            // yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("gameOver");
        }
    }

    void Update()
    {
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
        PlayerPrefs.SetInt("hunger", hunger);
        hungerTracker.text = "Fullness: " + hunger.ToString();
        int counter = (int) Mathf.Min(hunger / 10, hungerIcons.Length);
        for (int i = 0; i < counter; i++)
        {
            Color c = hungerIcons[i].color;
            c.a = 1f;

            hungerIcons[i].color = c;
        }
        for (int i = counter; i < hungerIcons.Length; i++)
        {
            Color c = hungerIcons[i].color;
            c.a = 0.5f;

            hungerIcons[i].color = c;
        }
    }

    public void IncreaseAffection(int i)
    {
        duck.GetComponent<ShowStats>().waitTime = 0f;
        affection += i;
        PlayerPrefs.SetInt("affection", affection);
        patPatTracker.text = "Affection: " + affection.ToString();

        if (affection % 10 == 0)
        {
            AffectionDisplay();
        }
    }

    public void IncreaseHungerBar(int i)
    {
        duck.GetComponent<ShowStats>().waitTime = 0f;
        hunger += i;
        hungerTracker.text = "Fullness: " + hunger.ToString();
        checkHunger();
        if (hunger % 10 == 0)
        {
            HungerDisplay();
        }
    }
}
