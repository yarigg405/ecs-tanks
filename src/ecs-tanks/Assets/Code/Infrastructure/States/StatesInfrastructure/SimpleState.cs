namespace Assets.Code.Infrastructure.States.StatesInfrastructure
{
    public class SimpleState : IState
    {
        public virtual void Enter() { }

        public virtual void BeginExit() { }

        public virtual void EndExit() { }
    }
}
