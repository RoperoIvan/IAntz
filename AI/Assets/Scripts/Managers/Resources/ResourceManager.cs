using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int resource_type;
    public int current_resource;
    Worker_Knowledge my_knowledg;
    // Start is called before the first frame update
    void Start()
    {
        my_knowledg = this.GetComponent<Worker_Knowledge>();
    }

    // Update is called once per frame
    void Update()
    {
        current_resource = my_knowledg.my_load;
    }
}
