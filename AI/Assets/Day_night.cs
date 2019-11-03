using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Day_night : MonoBehaviour
{
    public bool day = true;
    public Text resources_food;
    public Text resources_materials;
    public Light sun_light;
    Color color_day = Color.yellow;
    Color color_night = Color.blue;
    int amount_food = 0;
    int amount_materials = 0;
    bool double_update = false;
    public bool _update = false;
    // Start is called before the first frame update
    void Start()
    {
        double_update = false;
        _update = false;
        day = true;
        Add_food(0);
        Add_materials(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (_update)
        {
            if (!double_update)
            {
                _update = false;
            }
            double_update = false;
        }
    }

    public void Add_food(int food_to_add)
    {
        amount_food += food_to_add;
        resources_food.text = "Food: " + amount_food;
    }

    public void Add_materials(int material_to_add)
    {
        amount_materials += material_to_add;
        resources_materials.text = "Materials: " + amount_materials;
    }

    public void Daynight()
    {
        day = !day;
        double_update = true;
        _update = true;
        if(day)
        {
            sun_light.color = Color.Lerp(color_night, color_day, 2);
        }
        else
        {
            sun_light.color = Color.Lerp(color_day, color_night, 2);
        }
    }
}
