using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    public class IsEnemyDead : ConditionTask
    {
        protected override string OnInit()
        {
            
            return null;
        }

        protected override bool OnCheck()
        {
            bool ret = false;
            if (agent.gameObject.GetComponent<PheromonesSecrete>().enemy.GetComponent<HealthManager>().current_health <= 0 || !agent.gameObject.GetComponent<PheromonesSecrete>().enemy)
            {
                //agent.gameObject.GetComponent<PheromonesSecrete>().enemy;
                ret = true;           
            }

            return ret;
        }
    }
}