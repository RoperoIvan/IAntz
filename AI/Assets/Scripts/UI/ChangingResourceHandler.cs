using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangingResourceHandler : MonoBehaviour
{
    public Sprite[] change_resource;
    public Image changing_resource_img;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        changing_resource_img.sprite = change_resource[GetComponent<ChangingResourceManager>().current_resource_state];
    }
}
