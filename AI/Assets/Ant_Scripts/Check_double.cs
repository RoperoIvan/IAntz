using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace IAntz{

	public class Check_double : ActionTask{
        public BBParameter<int> current_life;
        public int total_life;


		protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
            if (current_life.value == total_life)
                EndAction(true);
            else
                EndAction(false);
		}

		protected override void OnUpdate(){
			
		}

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}