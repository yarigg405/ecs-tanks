using Fusion;


namespace Assets.Code.Gameplay.Input.Service
{
    public struct PlayerNetworkInput : INetworkInput
    {
        public float HorizontalInput;
        public float VerticalInput;
        public NetworkButtons Buttons;
    }

    public enum PlayerControlButtons
    {
        Fire = 0,
    }
}
