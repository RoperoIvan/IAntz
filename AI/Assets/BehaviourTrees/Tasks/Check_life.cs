using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace AI{

	public class Check_life : ActionTask{
        public BBParameter<int> my_current_health;
        public BBParameter<int> health_to_flee;
		protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
            
		}

		protected override void OnUpdate(){
            if (my_current_health.value <= health_to_flee.value)
                EndAction(false);
        }

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}