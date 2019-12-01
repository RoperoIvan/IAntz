using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace AI{

	public class Go_to_Enemy : ActionTask{
        public BBParameter<bool> can_hit;
        int prio;
        public BBParameter<GameObject> my_ant;
        public BBParameter<GameObject> my_enemie;

        SteeringAlign align;
        Move move;
        protected override string OnInit(){
            prio = agent.gameObject.GetComponent<SteeringAlign>().priority;
            align = my_ant.value.GetComponent<SteeringAlign>();
            move = my_ant.value.GetComponent<Move>();

            return null;
		}

		protected override void OnExecute(){
            agent.gameObject.GetComponent<SteeringFollowPath>().enabled = false;
            
        }

		protected override void OnUpdate(){
            Vector3 enemy_pos = my_enemie.value.transform.position;
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
            for (int i = 0; i < move.movement_velocity.Length; i++)
            {
                move.movement_velocity[i] = Vector3.zero;
                move.current_velocity = Vector3.zero;
            }
            for (int i = 0; i < move.angular_velocity.Length; i++)
            {
                move.angular_velocity[i] = 0;
                move.current_rotation_speed = 0;
            }
        }

		protected override void OnPause(){
			
		}
	}
}