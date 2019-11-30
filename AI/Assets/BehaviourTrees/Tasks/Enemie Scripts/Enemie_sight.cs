using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI{

	public class Enemie_sight : ActionTask{
        public BBParameter<GameObject> my_enemie;
        
		protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
			
		}

		protected override void OnUpdate(){
            if (my_enemie.value != null)
                EndAction(true);
		}

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}