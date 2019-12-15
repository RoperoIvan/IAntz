using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewWorker : MonoBehaviour
{
    public GameObject resource_zone;
    public GameObject resource_zone_2;
    public GameObject resource_zone_3;
    public GameObject resource_zone_4;


    public GameObject resources;
    public GameObject Spawn_pos;

    GameObject new_obj;
    bool clicked;
    Vector3 mouse_offset;
    float mouse_z_pos;
    bool set = true;
    public AudioSource clip;

    public void Start()
    {
    }
    public void Update()
    {
        //if (clicked)
        //{
        //    set = false;
        //    PutZone(Input.mousePosition);
        //    mouse_z_pos = Camera.main.WorldToScreenPoint(new_obj.transform.position).z;
        //    mouse_offset = new_obj.transform.position - MouseInWorld();
        //    clip.Play();
        //}

        //if (!set)
        //{
        //    new_obj.transform.position = MouseInWorld() - mouse_offset;
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        set = true;
        //        resources.GetComponent<Anthill_Resources>().Food_cantity -= 20;
                
        //    }
        //}

        if (clicked)
        {
            if (resources.GetComponent<Anthill_Resources>().Food_cantity >= 20)
            {
                clip.Play();
                SelectAle();
                resources.GetComponent<Anthill_Resources>().Food_cantity -= 20;
            }
            clicked = false;
        }
    }
    private Vector3 MouseInWorld()
    {
        Vector3 mouse_pos = Input.mousePosition;
        mouse_pos.z = mouse_z_pos;
        return Camera.main.ScreenToWorldPoint(mouse_pos);
    }
    public void Clicked()
    {
        clicked = true;
    }
    public void PutZone(Vector2 mouse_pos)
    {
        RaycastHit hit = RayFromCamera(mouse_pos, 1000.0f);
        new_obj = GameObject.Instantiate(resource_zone, hit.point, Quaternion.identity);
        clicked = false;
    }

    public RaycastHit RayFromCamera(Vector3 mouse_pos, float r_length)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(mouse_pos);
        Physics.Raycast(ray, out hit, r_length);
        return hit;
    }

    public void SelectAle()
    {
        Vector3 ori_pos;
        int randd = Random.Range(0, 4);

        if (randd == 0)
        {
            ori_pos.x = Spawn_pos.transform.position.x;
            ori_pos.y = resource_zone.transform.position.y;
            ori_pos.z = Spawn_pos.transform.position.z;

            new_obj = GameObject.Instantiate(resource_zone, ori_pos, Quaternion.identity);
        }
        if (randd == 1)
        {
            ori_pos.x = Spawn_pos.transform.position.x;
            ori_pos.y = resource_zone_2.transform.position.y;
            ori_pos.z = Spawn_pos.transform.position.z;

            new_obj = GameObject.Instantiate(resource_zone_2, ori_pos, Quaternion.identity);
        }

        if (randd == 2)
        {
            ori_pos.x = Spawn_pos.transform.position.x;
            ori_pos.y = resource_zone_3.transform.position.y;
            ori_pos.z = Spawn_pos.transform.position.z;

            new_obj = GameObject.Instantiate(resource_zone_3, ori_pos, Quaternion.identity);
        }

        if (randd == 3)
        {
            ori_pos.x = Spawn_pos.transform.position.x;
            ori_pos.y = resource_zone_4.transform.position.y;
            ori_pos.z = Spawn_pos.transform.position.z;

            new_obj = GameObject.Instantiate(resource_zone_4, ori_pos, Quaternion.identity);
        }

        new_obj.SetActive(true);
        
    }

}
