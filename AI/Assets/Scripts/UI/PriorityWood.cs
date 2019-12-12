using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriorityWood : MonoBehaviour
{
    public Dropdown D_Wood;
    public int last_index = 0;
    List<string> prio_wood = new List<string>() { "Wood: 1", "Wood: 2", "Wood: 3" };
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
        D_Wood.AddOptions(prio_wood);
    }

    public void DrowpDownChanged(int index)
    {
        this.GetComponent<Anthill_Resources>().Priority_branches = (index + 1);
        last_index = (index + 1);
        this.GetComponent<Anthill_Resources>().CalculatePriorities();
    }
}
