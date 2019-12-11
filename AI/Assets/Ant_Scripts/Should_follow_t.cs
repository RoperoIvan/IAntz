using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace IAntz{

	public class Should_follow_t : ActionTask{

		protected override string OnInit(){
			return null;
		}

		protected override void OnExecute(){
			EndAction(true);
		}

		protected override void OnUpdate(){
			
		}

		protected override void OnStop(){
			
		}

		protected override void OnPause(){
			
		}
	}
}