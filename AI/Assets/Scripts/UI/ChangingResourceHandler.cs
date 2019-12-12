using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingResourceHandler : MonoBehaviour
{
    public Sprite[] change_resource_state;
    public Image changing_resource__state_img;
    public Sprite[] change_resource;
    public Image changing_resource_img;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        changing_resource__state_img.sprite = change_resource_state[GetComponent<ChangingResourceManager>().current_resource_state];
        changing_resource__state_img.sprite = change_resource_state[GetComponent<ChangingResourceManager>().current_wanted_resource];
    }
}
