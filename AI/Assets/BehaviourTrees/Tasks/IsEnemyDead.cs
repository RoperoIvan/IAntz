using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    public class IsEnemyDead : ConditionTask
    {
        public BBParameter<GameObject> my_ant;
        public BBParameter<GameObject> my_enemie;
        protected override string OnInit()
        {
            
            return null;
        }

        protected override bool OnCheck()
        {
            bool ret = false;
            if (my_enemie.value.GetComponent<HealthManager>().current_health <= 0 || my_enemie.value == null)
            {
                //agent.gameObject.GetComponent<PheromonesSecrete>().enemy;
                ret = true;           
            }

            return ret;
        }
    }
}