namespace Assets.Code.Infrastructure.States.StatesInfrastructure
{
    public class SimplePayloadState<TPayload> : IPayloadState<TPayload>
    {
        public virtual void Enter(TPayload payload) { }
        public virtual void BeginExit() { }
        public virtual void EndExit() { }
    }
}
