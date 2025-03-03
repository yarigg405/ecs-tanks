using Cysharp.Threading.Tasks;


namespace Assets.Code.Infrastructure.States.StatesInfrastructure
{
    public interface IExitableState
    {
        void BeginExit();
        void EndExit();
    }
}
