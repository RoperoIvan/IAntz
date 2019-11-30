using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI{

	public class To_far : ActionTask{
        public BBParameter<GameObject> my_ant;
        public BBParameter<GameObject> my_current_enemie;
        public BBParameter<float> distance;

        protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
			
		}

		protected override void OnUpdate(){
            Vector3 dist = my_current_enemie.value.transform.position - my_ant.value.transform.position;
            if (dist.magnitude >= distance.value)
            {
                EndAction(false);
            }
        }

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}