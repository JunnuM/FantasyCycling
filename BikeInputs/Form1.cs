using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;

namespace BikeInputs
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
        }

        #region Get serial port referecne
        public SerialPort GetSerialPort()
        {
            return sp_bike;
        }
        #endregion

        #region Buttons
        private void btn_Toggle_Click(object sender, EventArgs e)
        {
            // Display visually loop status
            bool isLooping = !Program.bikeInputs.isLooping;
            if (isLooping)  btn_Toggle.Text = "on";
            else            btn_Toggle.Text = "off";

            Program.ToggleLoop();
        }
        #endregion

        #region Timers
        private void timer_Tick(object sender, EventArgs e)
        {
            OnTimerTick?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Custom events
        public event EventHandler<EventArgs> OnTimerTick;
        #endregion

        #region Debug functions
        List<string> debugMessages = new List<string>();
        public void DebugLine(string message)
        {
            debugMessages.Add(message);
            if (debugMessages.Count > 10) debugMessages.RemoveAt(0);

            string newMessage = "";
            foreach (string msg in debugMessages)
            {
                newMessage += msg + "\n";
            }
            lbl_debug.Text = newMessage;
        }
        public void DebugList(List<string> _message)
        {
            string message = String.Join("\n", _message);
            lbl_debug.Text = message;
            debugMessages.Clear();

            
        }
        #endregion

        #region Set lable functions
        public enum LabelType
        {
            // Bike stats
            speedStatus,
            isReversing,
            rpm,
            isCycling,
            cyclesCount,
            // Variables
            maxTimeDif,
            stopTime,
            reverseTime,
            slowThreshold,
            mediumThreshold,
            fastThreshold,
            // Inputs
            input
        }
        public void SetLabelText(LabelType _lblType, string _text)
        {
            Label lbl;
            switch(_lblType)
            {
                // Bike stats
                case LabelType.speedStatus:         lbl = lbl_speedStatus;          break;
                case LabelType.isReversing:         lbl = lbl_isReversing;          break;
                case LabelType.rpm:                 lbl = lbl_rpm;                  break;
                case LabelType.isCycling:           lbl = lbl_isCycling;            break;
                case LabelType.cyclesCount:         lbl = lbl_cyclesCount;          break;
                // Variables
                case LabelType.maxTimeDif:          lbl = lbl_maxTimeDif;           break;
                case LabelType.stopTime:            lbl = lbl_stopTime;             break;
                case LabelType.reverseTime:         lbl = lbl_reverseTime;          break;
                case LabelType.slowThreshold:       lbl = lbl_slowThreshold;        break;
                case LabelType.mediumThreshold:     lbl = lbl_mediumThreshold;      break;
                case LabelType.fastThreshold:       lbl = lbl_fastThreshold;        break;
                // Inputs
                case LabelType.input:               lbl = lbl_input;                break;

                // Error case
                default:
                    Console.Write("Error in getting label for " + _lblType.ToString());
                    lbl = lbl_debug;
                    break;
            }
            lbl.Text = _text;
        }
        public void SetSpeedBar(int _fillPercentage)
        {
            // Clamp between min and max values
            _fillPercentage = Math.Min(Math.Max(_fillPercentage, bar_speed.Minimum), bar_speed.Maximum);
            bar_speed.Value = _fillPercentage;
        }
        #endregion
    }
}
