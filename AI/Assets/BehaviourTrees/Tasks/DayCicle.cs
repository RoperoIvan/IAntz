using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions{

	public class DayCicle : ConditionTask{
        public GameObject daycicle;
        protected override string OnInit(){
           
            return null;
		}

		protected override bool OnCheck(){
            bool ret = false;
            if (daycicle.GetComponent<Day_night>().day)
                ret = true;

            return ret;
		}
	}
}