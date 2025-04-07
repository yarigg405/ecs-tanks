using Assets.Code.Gameplay.Input.Service;
using Fusion;


namespace Assets.Code.Gameplay.Input.Network
{
    public class NetworkInputPoller
    {
        private const string AXIS_HORIZONTAL = "Horizontal";
        private const string AXIS_VERTICAL = "Vertical";
        private const string BUTTON_FIRE1 = "Jump";


        public void SetInput(NetworkInput input)
        {
            PlayerNetworkInput localInput = new PlayerNetworkInput();

            localInput.HorizontalInput = UnityEngine.Input.GetAxis(AXIS_HORIZONTAL);
            localInput.VerticalInput = UnityEngine.Input.GetAxis(AXIS_VERTICAL);
            localInput.Buttons.Set(PlayerControlButtons.Fire, UnityEngine.Input.GetButton(BUTTON_FIRE1));

            input.Set(localInput);
        }

    }
}