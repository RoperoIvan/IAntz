using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace AI{

	public class Go_to_Enemy : ActionTask{
        public BBParameter<bool> can_hit;
        int prio;
		protected override string OnInit(){
            prio = agent.gameObject.GetComponent<SteeringAlign>().priority;
            

            return null;
		}

		protected override void OnExecute(){
            agent.gameObject.GetComponent<SteeringFollowPath>().enabled = false;
            
        }

		protected override void OnUpdate(){
            Vector3 enemy_pos = agent.gameObject.GetComponent<PheromonesSecrete>().enemy.transform.position;
            Vector3 distance_between_enemy = enemy_pos - agent.gameObject.transform.position;
            agent.gameObject.GetComponent<SteeringAlign>().DrivetoTarget(enemy_pos, prio);
            if(distance_between_enemy.magnitude <= 3.0f)
            {
                can_hit.value = true;
                EndAction(true);
            }
            else
                can_hit.value = false;

        }

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}