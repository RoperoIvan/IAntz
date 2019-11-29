using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceHandler : MonoBehaviour
{
    public Sprite[] resource;
    public Image resource_img;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        resource_img.sprite = resource[GetComponent<ResourceManager>().current_resource];
    }
}
