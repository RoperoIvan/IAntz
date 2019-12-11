using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectAnt : MonoBehaviour
{
    public LayerMask mask;
    public int mouse_button = 0;

    public GameObject my_ant;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(mouse_button))
        {
            RaycastHit hit;
            Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(r, out hit, 10000.0f, mask) == true)
            {
                Collider[] colliders = Physics.OverlapSphere(hit.point, 3, mask);
                //first we wanna tell the other ant that is no longer selected.

                if (my_ant != null)
                    my_ant.GetComponent<Warrior_knowledge>().im_selected = false;



                foreach (Collider coll in colliders)
                {
                    my_ant = coll.gameObject;
                }
                //Then the new ant will be told that is selected.
                my_ant.GetComponent<Warrior_knowledge>().im_selected = true;
            }

        }
    }
}
