using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriorityFood : MonoBehaviour
{
    public Dropdown D_Food;
    public int last_index = 0;
    List<string> prio_food = new List<string>() { "Food: 1", "Food: 2", "Food: 3" };
    public AudioSource clip;

    // Start is called before the first frame update
    void Start()
    {
        AddLists();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddLists()
    {
        D_Food.AddOptions(prio_food);
    }

    public void DrowpDownChanged(int index)
    {
        this.GetComponent<Anthill_Resources>().Priority_food = (index + 1);
        last_index = (index + 1);
        this.GetComponent<Anthill_Resources>().CalculatePriorities();
        clip.Play();
    }
}
