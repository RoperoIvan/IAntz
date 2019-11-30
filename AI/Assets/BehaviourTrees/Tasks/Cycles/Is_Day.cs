using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace AI{

	public class Is_Day : ActionTask{
        //vars:
        public BBParameter<bool> day;



		protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
			
		}

		protected override void OnUpdate(){
			if (day.value == false)
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