using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace IAntz{

	public class Should_not_follow_f : ActionTask{
        public BBParameter<bool> should_i_follow;

		protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
			
		}

		protected override void OnUpdate(){
            if (should_i_follow.value == false)
                EndAction(false);
		}

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}