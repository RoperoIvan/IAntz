using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriorityRocks : MonoBehaviour
{
    public Dropdown D_Rocks;
    public int last_index = 0;
    List<string> prio_rocks = new List<string>() { "Rocks: 1", "Rocks: 2", "Rocks: 3" };
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
        D_Rocks.AddOptions(prio_rocks);
    }

    public void DrowpDownChanged(int index)
    {
        this.GetComponent<Anthill_Resources>().Priority_rocks = (index + 1);
        last_index = (index + 1);
        this.GetComponent<Anthill_Resources>().CalculatePriorities();
        clip.Play();
    }
}
