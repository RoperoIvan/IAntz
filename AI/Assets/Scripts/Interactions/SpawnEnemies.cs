using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemy_ant;
    //public int max_enemies_spawned = 1;
    private int enemies_spawned = 0;
    public float offset = 1.5f;
    public bool clicked = false;
    public int localization = 0; // 0: up/down 1: left/right
    public int number_enemies = 2;
    public bool is_spawned = false;

    public GameObject which_day;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        number_enemies = (6 - which_day.GetComponent<DayManager>().days_until_winter)*2;
        if(clicked)
        {
            switch(localization)
            {
                case 0:
                    while (enemies_spawned != number_enemies)
                    {
                        GameObject enemy;
                        enemy = GameObject.Instantiate(enemy_ant, this.transform.position, Quaternion.identity);
                        Vector3 tmp_pos = enemy.transform.position;
                        tmp_pos.x += offset * (enemies_spawned +1) ;
                        enemy.transform.position = tmp_pos;
                        enemies_spawned++;
                        enemy.SetActive(true);
                    }                    
                    break;
                case 1:
                    while (enemies_spawned != number_enemies)
                    {
                        GameObject enemy;
                        enemy = GameObject.Instantiate(enemy_ant, this.transform.position, Quaternion.identity);
                        Vector3 tmp_pos = enemy.transform.position;
                        tmp_pos.z += offset * (enemies_spawned + 1);
                        enemy.transform.position = tmp_pos;
                        enemies_spawned++;
                        enemy.SetActive(true);
                    }
                    break;                
                default:
                    Debug.Log("This spawn doesn't exist");
                    break;
            }
            clicked = false;
            is_spawned = true;
            enemies_spawned = 0;
        }
    }

    public void Clicked()
    {
        clicked = true;        
    }
}
