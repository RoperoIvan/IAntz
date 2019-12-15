using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpRockStorage : MonoBehaviour
{
    public GameObject pop_up;
    public AudioSource clip;
    bool in_sound = false;
    // Start is called before the first frame update
    void Start()
    {
        pop_up.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseOver()
    {
        pop_up.SetActive(true);
        Debug.Log("Mouse is over GameObject.");
        if(!in_sound)
        {
            clip.Play();
            in_sound = true;
        }
       
    }
    public void OnMouseExit()
    {
        pop_up.SetActive(false);
        in_sound = false;
        Debug.Log("Mouse is exit GameObject.");
    }
}
