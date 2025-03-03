using Assets.Code.Infrastructure.States.StatesInfrastructure;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.States.StateMachine
{
    public sealed class GameStateMachine : ITickable, IStateMachine
    {
        private readonly IObjectResolver _resolver;
        private IExitableState _activeState;

        public GameStateMachine(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        void ITickable.Tick()
        {
            if (_activeState is IUpdatableState updatableState)
                updatableState.Update();
        }


        public void Enter<TState>() where TState : class, IState
        {
            RequestEnter<TState>();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            RequestEnter<TState, TPayload>(payload);
        }

        private TState RequestEnter<TState>() where TState : class, IState
        {
            var state = RequestChangeState<TState>();
            EnterState(state);

            return state;
        }

        private TState RequestEnter<TState, TPayload>(TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            var state = RequestChangeState<TState>();
            EnterPayloadState(state, payload);

            return state;
        }

        private TState EnterPayloadState<TState, TPayload>(TState state, TPayload payload) where TState : class, IPayloadState<TPayload>
        {
            _activeState = state;
            state.Enter(payload);

            return state;
        }

        private TState EnterState<TState>(TState state) where TState : class, IState
        {
            _activeState = state;
            state.Enter();

            return state;
        }

        private TState RequestChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.BeginExit();
            _activeState?.EndExit();

            return GetState<TState>();
        }

        private TState GetState<TState>() where TState : class, IExitableState
        {
            return _resolver.Resolve<TState>();
        }
    }
}