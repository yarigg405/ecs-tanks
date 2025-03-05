using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.States.StatesInfrastructure;


namespace Assets.Code.Infrastructure.States.GameStates
{
    public sealed class BattleEnterState : SimpleState
    {
        private readonly IStateMachine _stateMachine;

        public BattleEnterState(IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            PlacePlayer();
            _stateMachine.Enter<BattleLoopState>();
        }

        private void PlacePlayer()
        {
        }
    }
}
