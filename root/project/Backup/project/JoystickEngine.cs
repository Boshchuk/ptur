using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.DirectX.DirectInput;
using System.Diagnostics;


namespace project
{
    class JoystickEngine
    {
        private Device _jDevice;
        public Device jDevice
        {
            get 
            {
                return _jDevice;
            }
            set
            {
                _jDevice = value;
            }
        }

        private JoystickState _jState;

        public JoystickState jState
        {
            get
            {
                return _jState;
            }
            set
            {
                _jState = value;
            }
        }

        /// <summary>
        /// Init joy
        /// </summary>
        /// <param name="ParamForCoperativeLevel">insert pointer to the form </param>
        public void  FindGameControl(System.Windows.Forms.Control ParamForCoperativeLevel)
        {            
            DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl,
                EnumDevicesFlags.AttachedOnly); // Find all the GameControl devices that are attached.

            if (gameControllerList.Count > 0)// check that we have at least one device.
            {
                gameControllerList.MoveNext();// Move to the first device
                DeviceInstance deviceInstance = (DeviceInstance) gameControllerList.Current;
                
                // create a device from this controller.
                jDevice = new Device(deviceInstance.InstanceGuid);
                jDevice.SetCooperativeLevel( ParamForCoperativeLevel,
                    CooperativeLevelFlags.Background |
                    CooperativeLevelFlags.NonExclusive); 
            }
            jDevice.SetDataFormat(DeviceDataFormat.Joystick); // Tell DirectX that this is a Joystick.
            // Finally, acquire the device.
            jDevice.Acquire();
        }

        public void DisplayCapabilities()
        {
            // Find the capabilities of the joystick
            DeviceCaps cps = jDevice.Caps;
            // number of Axes
            Debug.WriteLine("Joystick Axis: " + cps.NumberAxes);
            // number of Buttons
            Debug.WriteLine("Joystick Buttons: " + cps.NumberButtons);
            // number of PoV hats
            Debug.WriteLine("Joystick PoV hats: " + cps.NumberPointOfViews);
        }

        private void Poll()
        {
            try
            {
                // poll the joystick
                jDevice.Poll(); // update the joystick state field
                jState = jDevice.CurrentJoystickState;
            }
            catch (Exception err)
            {
                // we probably lost connection to the joystick
                // was it unplugged or locked by another application?
                Debug.WriteLine(err.Message);
            }
        }
    }
}
