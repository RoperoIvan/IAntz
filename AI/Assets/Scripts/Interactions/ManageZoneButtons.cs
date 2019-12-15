using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageZoneButtons : MonoBehaviour
{
    public UnityEngine.UI.Button warrior;
    public UnityEngine.UI.Button worker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Anthill_Resources>().Food_cantity >= 40)
        {
            worker.interactable = true;
        }
        else
            worker.interactable = false;
        if (GetComponent<Anthill_Resources>().Food_cantity >= 30 && GetComponent<Anthill_Resources>().Branches_cantity >= 20)
        {
            warrior.interactable = true;
        }
        else
            warrior.interactable = false;

    }
}
