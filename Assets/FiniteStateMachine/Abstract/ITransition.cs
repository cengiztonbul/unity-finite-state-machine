namespace FiniteStateMachine.Abstract
{
	public interface ITransition
	{
		IState CurrentState { get; set; }

		IState NextState { get; set; }

		bool Condition();

		void InitTransition();
	}
}
