using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public GameObject resources;
    public int win_food = 5000;
    public int win_rocks = 2500;
    public int win_wood = 3000;
    public int total_ants = 0;
    public bool full_win = false;
    public GameObject final_win_panel;
    public GameObject final_lose_panel;
    public GameObject score_panel;
    public GameObject score_text;
    bool final = false;
    //int current_day;
    // Start is called before the first frame update
    void Start()
    {
        //current_day = resources.GetComponent<DayManager>().days_until_winter; 
    }

    // Update is called once per frame
    void Update()
    {        
        if (resources.GetComponent<DayManager>().days_until_winter < 0 && final == false)
        {
            final = true;
            Debug.Log("HEHEHEHE");
            CheckWinCondition();
            DisplayFinalPanel();
        }
    }

    public void CheckWinCondition()
    {
        if(resources.GetComponent<Anthill_Resources>().Food_cantity >= win_food)
        {
            if(resources.GetComponent<Anthill_Resources>().Branches_cantity >= win_wood)
            {
                if(resources.GetComponent<Anthill_Resources>().Rocks_cantity >= win_rocks)
                {
                    full_win = true;
                }
            }
        }
    }

    public void DisplayFinalPanel()
    {
        if(full_win)
        {
            final_win_panel.SetActive(true);
        }
        else
        {
            final_lose_panel.SetActive(true);
            Debug.Log("FAIL");

        }
    }

    public void ContinueClicked()
    {
        if(full_win)
            final_win_panel.SetActive(false);
        else
            final_lose_panel.SetActive(false);

        score_panel.SetActive(true);
        SetScore();
    }

    void SetScore()
    {
        int food = resources.GetComponent<Anthill_Resources>().Food_cantity;
        int rocks = resources.GetComponent<Anthill_Resources>().Rocks_cantity;
        int wood = resources.GetComponent<Anthill_Resources>().Branches_cantity;
        int total_score = CalculateTotalScore(food, rocks, wood);
        score_text.GetComponent<Text>().text = "Total food gained : " + food + " X 3"  +"\n" + "Total Rocks gained: " + rocks + " X 2" + "\n" +
            "Total wood gained : " + wood + " X 2" + "\n" + "Total ants in the anthill: " + total_ants + " X 20" + "\n" + "Total score: " + total_score;
    }

    int CalculateTotalScore(int t_food, int t_rocks, int t_wood)
    {
        int final_score = (t_food * 3) + (t_rocks * 2) + (t_wood * 2) + (total_ants * 20);
        return final_score;
    }

    public void PlayAgainClicked()
    {
        final = false;
        score_panel.SetActive(false);
        full_win = false;
        resources.GetComponent<DayManager>().days_until_winter = 9;
        //Restart game code HERE
    }
}
