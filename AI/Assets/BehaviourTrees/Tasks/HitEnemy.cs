using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;

namespace AI{

	public class HitEnemy : ActionTask{
        int enemy_health;
        float time_start;
        public BBParameter<float> time_finish;
        protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
            time_start = Time.time;
           
            //EndAction(true);
        }

		protected override void OnUpdate(){
            //StartCoroutine(HitNow());
            float timer = Time.time;
            if (timer - time_start > time_finish.value)
            {
                --agent.gameObject.GetComponent<PheromonesSecrete>().enemy.GetComponent<HealthManager>().current_health;
                time_start = Time.time;
            }
        }

		protected override void OnStop(){
            //agent.gameObject.GetComponent<AttackManager>().current_attack = 0;
        }

		protected override void OnPause(){
			
		}
	}
}