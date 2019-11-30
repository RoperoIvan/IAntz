using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI{

	public class Seek_GameObject : ActionTask{
        public BBParameter<GameObject> To_seek;
        public BBParameter<GameObject> My_ant;

        public BBParameter<float> d_to_complete;

        SteeringAlign align;
        Move move;

		protected override string OnInit(){
            align = My_ant.value.GetComponent<SteeringAlign>();
            move = My_ant.value.GetComponent<Move>();

			return null;
		}

		protected override void OnExecute(){
		}

		protected override void OnUpdate(){
            Vector3 seek_pos = To_seek.value.transform.position - My_ant.value.transform.position;

            if (seek_pos.magnitude <= d_to_complete.value)
                EndAction(true);
            else
                align.DrivetoTarget(To_seek.value.transform.position, 3);
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