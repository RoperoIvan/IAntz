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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(clicked)
        {
            while(enemies_spawned != 4)
            {
                GameObject enemy;
                enemy = GameObject.Instantiate(enemy_ant, this.transform.position, Quaternion.identity);
                Vector3 tmp_pos = enemy.transform.position;
                tmp_pos.x += offset * enemies_spawned;
                enemy.transform.position = tmp_pos;
                enemies_spawned++;
            }          
            clicked = false;
            enemies_spawned = 0;
        }


    }

    public void Clicked()
    {
        clicked = true;
    }
}
