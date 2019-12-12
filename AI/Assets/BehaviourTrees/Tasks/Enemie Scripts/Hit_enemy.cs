using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI{

	public class Hit_enemy : ActionTask{

        public BBParameter<GameObject> my_ant;
        public BBParameter<GameObject> my_current_enemie;
        public BBParameter<float> CDR;

        HealthManager enemie_health;
        float timer;
        protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
            enemie_health = my_current_enemie.value.GetComponent<HealthManager>(); //We do it here cause we wanna always know which enemie we are fighting;
            Vector3 dist = my_current_enemie.value.transform.position - my_ant.value.transform.position;
            //agent.gameObject.GetComponent<AttackManager>().current_attack = 1;
            if (dist.magnitude <= 4.0f)
            {
                enemie_health.current_health -= 1;
            }
            timer = Time.time;
		}

		protected override void OnUpdate(){
            float time_now = Time.time;
            if (time_now - timer >= CDR.value)
            {
                //agent.gameObject.GetComponent<AttackManager>().current_attack = 0;
                EndAction(true);
            }
		}

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}