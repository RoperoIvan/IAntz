using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IAntz{

	public class Enemie_disapered : ActionTask{
        public BBParameter<GameObject> my_enemie;
        public BBParameter<GameObject> Notonmywatch;

        protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
			
		}

		protected override void OnUpdate(){
            if (my_enemie.value == Notonmywatch.value)
                EndAction(true);
        }

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}