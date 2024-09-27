using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;

public class ControllerInput : MonoBehaviour
{
    public TextMeshProUGUI deviceInfoText; // Assign your TextMeshProUGUI component in the Inspector

    void Start()
    {
        UpdateDeviceInfo();
    }

    void Update()
    {
        UpdateDeviceInfo();
    }

    private void UpdateDeviceInfo()
    {
        var devices = InputSystem.devices;

        string deviceInfo = "Controller State:\n";

        foreach (var device in devices)
        {
            if (device is XInputController || device is Gamepad)
            {
                deviceInfo += $"Device: {device.displayName}, Connected: {device.added}\n";

                if (device is Gamepad gamepad)
                {
                    deviceInfo += $"A Button: {gamepad.aButton.isPressed}\n";
                    deviceInfo += $"B Button: {gamepad.bButton.isPressed}\n";
                    deviceInfo += $"X Button: {gamepad.xButton.isPressed}\n";
                    deviceInfo += $"Y Button: {gamepad.yButton.isPressed}\n";
                    deviceInfo += $"D-Pad Up: {gamepad.dpad.up.isPressed}\n";
                    deviceInfo += $"D-Pad Down: {gamepad.dpad.down.isPressed}\n";
                    deviceInfo += $"D-Pad Left: {gamepad.dpad.left.isPressed}\n";
                    deviceInfo += $"D-Pad Right: {gamepad.dpad.right.isPressed}\n";
                    deviceInfo += $"Left Trigger: {gamepad.leftTrigger.ReadValue()}\n";
                    deviceInfo += $"Right Trigger: {gamepad.rightTrigger.ReadValue()}\n";
                    deviceInfo += $"Left Stick: {gamepad.leftStick.ReadValue()}\n";
                    deviceInfo += $"Right Stick: {gamepad.rightStick.ReadValue()}\n";
                }
                deviceInfo += "\n";
            }
        }
        deviceInfoText.text = deviceInfo;
    }
}
