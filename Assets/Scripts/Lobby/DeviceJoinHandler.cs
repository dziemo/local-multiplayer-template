using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.InputSystem.Users;

namespace RoboBall
{
    public class DeviceJoinHandler
    {
        public event Action<InputUser> OnDeviceJoined;
        public bool IsEnabled => InputUser.listenForUnpairedDeviceActivity > 0;

        public void EnableJoining()
        {
            InputUser.listenForUnpairedDeviceActivity++;
            InputUser.onUnpairedDeviceUsed += InputUser_onUnpairedDeviceUsed;
        }

        public void DisableJoining()
        {
            InputUser.listenForUnpairedDeviceActivity--;
            InputUser.onUnpairedDeviceUsed -= InputUser_onUnpairedDeviceUsed;
        }

        private void InputUser_onUnpairedDeviceUsed(InputControl inputControl, InputEventPtr eventPtr)
        {
            if (inputControl.device is Mouse)
            {
                return;
            }

            InputUser newUser = InputUser.PerformPairingWithDevice(inputControl.device);
            OnDeviceJoined?.Invoke(newUser);
        }
    }
}
