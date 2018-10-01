using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace Ronin.UWA.Controls
{
    public class DeviceStateTrigger : StateTriggerBase
    {
        private object _deviceFamily;

        public object DeviceFamily
        {
            get
            {
                return _deviceFamily;
            }
            set
            {
                _deviceFamily = value;
                SetActive(_deviceFamily.ToString() == "true");

            }
        }
    }
}
