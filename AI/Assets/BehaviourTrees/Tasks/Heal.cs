using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System.Collections;
using UnityEngine.AI;


namespace AI{

	public class Heal : ActionTask{
        public BBParameter<GameObject> my_ant;
        public BBParameter<int> my_total_health;
        public BBParameter<int> my_current_health;

        Worker_Knowledge my_knowledge;

        public BBParameter<float> timer_long;
        float inside_timer;

        protected override string OnInit(){
            my_knowledge = my_ant.value.GetComponent<Worker_Knowledge>();
            return null;
		}

		protected override void OnExecute(){
            inside_timer = Time.time;
		}

		protected override void OnUpdate(){
            float actual_timer = Time.time;

            if (actual_timer - inside_timer >= timer_long.value)
            {
                if (my_current_health.value < my_total_health.value)
                {
                    my_current_health.value += 1;
                    my_knowledge.GiveMaterial(8); // eight means that we are taking food.
                }
                  

                inside_timer = Time.time;
            }
            if (my_current_health.value == my_total_health.value)
                EndAction(true);
		}

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}