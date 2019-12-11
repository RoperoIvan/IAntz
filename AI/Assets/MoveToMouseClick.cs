using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveToMouseClick : MonoBehaviour {

	public LayerMask mask;
	public int mouse_button = 0;
    public bool selected;

    public GameObject my_ant;
    private Warrior_knowledge my_knowledge;

    private void Start()
    {
        my_knowledge = my_ant.GetComponent<Warrior_knowledge>();
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetMouseButton(mouse_button))
		{
			RaycastHit hit;
			Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(r, out hit, 10000.0f, mask) == true)
            {
                // We only want to affect the selected ant.
                if (my_knowledge.im_selected == true)
                {
                    transform.position = hit.point;
                    my_knowledge.target_pos_ind = transform.position;
                }
            }
				
		}
	}

}
