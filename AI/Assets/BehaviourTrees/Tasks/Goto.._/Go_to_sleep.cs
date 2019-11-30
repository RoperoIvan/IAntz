using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;


namespace AI{

	public class Go_to_sleep : ActionTask{

        public BBParameter<GameObject> my_sleep_module;
        public BBParameter<bool> on_sleep_module;
        public BBParameter<GameObject> my_ant;

        SteeringAlign align;
        Move move;

        protected override string OnInit(){
            align = my_ant.value.GetComponent<SteeringAlign>();
            move = my_ant.value.GetComponent<Move>();
            return null;
        }

		protected override void OnExecute(){
			
		}

		protected override void OnUpdate(){
            align.DrivetoTarget(my_sleep_module.value.transform.position, 3);
            if (on_sleep_module.value)
            {
                EndAction(true);
            }
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