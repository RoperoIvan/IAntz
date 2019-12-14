using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;


namespace IAntz{

	public class Sleep_fast : ActionTask{
        public BBParameter<GameObject> my_sleep_module;
        public BBParameter<bool> on_sleep_module;
        public BBParameter<GameObject> my_ant;

        public BBParameter<int> my_load;


        Worker_Knowledge my_knowledge;
        SteeringAlign align;
        Move move;
        Vector3 helper;
        protected override string OnInit()
        {
            align = my_ant.value.GetComponent<SteeringAlign>();
            move = my_ant.value.GetComponent<Move>();
            my_knowledge = my_ant.value.GetComponent<Worker_Knowledge>();
            return null;
        }

        protected override void OnExecute()
        {
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

            float r_h = Random.value;
            float r_w = Random.value;

            largo *= r_h;
            ancho *= r_h;

            Vector3 rand_final;
            rand_final.x = largo;
            rand_final.z = ancho;
            rand_final.y = mI.y;

            mI.x += largo;
            mI.z += ancho;
            mI.y = my_ant.value.transform.position.y;

            helper = mI;
            my_ant.value.transform.position = helper;


            my_knowledge.GiveMaterial(my_load.value);
            my_knowledge.CalculatePriorities();
            my_load.value = 0; //once we drop our resource we reset it to 0
            EndAction(true);

        }

        protected override void OnUpdate()
        {
        }

        protected override void OnStop()
        {
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