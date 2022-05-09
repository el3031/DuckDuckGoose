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

        affection = 10 * (int) Mathf.Floor(Random.Range(0f, 3f));

        hunger = 10 * (int) Mathf.Floor(Random.Range(1f, 3f));

        patPatTracker.text = "Affection: " + affection.ToString();
        hungerTracker.text = "Fullness: " + hunger.ToString();
        AffectionDisplay();
        HungerDisplay();
        InvokeRepeating("decreaseHunger",
        10.0f,
        10 * (int) Mathf.Floor(Random.Range(3f, 4f)));
    }

    void decreaseHunger()
    {
        duck.GetComponent<ShowStats>().waitTime = 0f;
        if (hunger > 0)
        {
            hunger -= (int) Mathf.Floor(Random.Range(1f, 4f));
            HungerDisplay();
        }
        if (hunger < 0)
        {
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
        if (hunger > 50)
        {
            duck.GetComponent<ExplodeDuck>().Explode();
        }
        if (hunger % 10 == 0)
        {
            HungerDisplay();
        }
    }
}
