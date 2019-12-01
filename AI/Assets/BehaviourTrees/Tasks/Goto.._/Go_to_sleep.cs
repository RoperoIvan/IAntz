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
        Vector3 helper;
        protected override string OnInit(){
            align = my_ant.value.GetComponent<SteeringAlign>();
            move = my_ant.value.GetComponent<Move>();
            return null;
        }

		protected override void OnExecute(){
            Collider to_work;
            Bounds to_w;
            Vector3 mA;
            Vector3 mI;

            to_work = my_sleep_module.value.GetComponent<Collider>();

            to_w = to_work.bounds;

            mI = to_w.min;
            mA = to_w.max;

            float largo = mA.x - mI.x;
            float ancho = mA.z - mI.z;

            Debug.Log("Largo ahora =" + largo);

            float r_h = Random.value;
            float r_w = Random.value;

            largo *= r_h;
            ancho *= r_h;
            Debug.Log("Largo ahora =" + largo);

            Vector3 rand_final;
            rand_final.x = largo;
            rand_final.z = ancho;
            rand_final.y = mI.y;

            mI.x += largo;
            mI.z += ancho;
            mI.y = my_ant.value.transform.position.y;

            helper = mI;
        }

		protected override void OnUpdate(){
            align.DrivetoTarget(helper, 3);
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