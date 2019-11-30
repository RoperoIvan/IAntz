using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;


namespace AI{

	public class Flee : ActionTask{
        public BBParameter<GameObject> my_ant;
        public BBParameter<GameObject> my_enemie;

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
            Vector3 dir = my_enemie.value.transform.position - my_ant.value.transform.position;
            Vector3  dist = dir.normalized;
            dist = -dist;

            if (dir.magnitude >= 9.0f)
                EndAction(true);
            else
                align.DrivetoTarget(dist,3);

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