using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.IO.Ports;
using System.Text;

namespace BikeInputs
{
    static class Program
    {
        #region Main
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form1 = new Form();
            bikeInputs = new BikeInputs();
            Application.Run(form1);
        }
        #endregion

        #region Variables and references
        public static Form form1;
        public static BikeInputs bikeInputs;
        #endregion

        #region Pass through functions
        // Program -> form
        public static void DebugLine(string _message) => form1.DebugLine(_message);
        public static void DebugList(List<string> _messages) => form1.DebugList(_messages);
        public static void SetLabelText(Form.LabelType _lblType, string _message) => form1.SetLabelText(_lblType, _message);
        public static void OnTimerTick_Sub(EventHandler<EventArgs> _eventHandler) => form1.OnTimerTick += _eventHandler;
        public static void SetSpeedBard(int _fillPercentage) => form1.SetSpeedBar(_fillPercentage);
        public static SerialPort GetSerialPort() => form1.GetSerialPort();

        // Program -> bikeInputs
        public static void ToggleLoop() => bikeInputs.ToggleLoop();
        #endregion
    }

    class BikeInputs
    {
        #region Imports
        [DllImport("USER32.DLL", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hwnd, StringBuilder ss, int count);
        private string ActiveWindowTitle()
        {
            //Create the variable
            const int nChar = 256;
            StringBuilder ss = new StringBuilder(nChar);

            //Run GetForeGroundWindows and get active window informations
            //assign them into handle pointer variable
            IntPtr handle = IntPtr.Zero;
            handle = GetForegroundWindow();

            if (GetWindowText(handle, ss, nChar) > 0) return ss.ToString();
            else return "";
        }
        #endregion

        #region enums
        private enum SpeedStatus
        {
            noCycle     = 0,
            slowCycle   = 1,
            mediumCycle = 2,
            fastCycle   = 3,
        }
        #endregion

        #region Variables and references
        // Variables
            // variables
        private float maxTimeDif = 3.0f;
        private float stopTime = 2.5f;
        private float reverseTime = 0.55f;
        private float slowThreshold = 0.05f;
        private float mediumThreshold = 0.68f;
        private float fastThreshold = 1.0f;
            // bike stats
        public float rpm = 0.0f;
        public bool isCycling = false;
        public bool isReversing = false;
        private SpeedStatus speedStatus = SpeedStatus.noCycle;

        public bool isLooping = false;

        // References
        private SerialPort sp;
        #endregion

        #region Constructor
        public BikeInputs()
        {
            InitializeSerialPort(Program.GetSerialPort());
            Program.OnTimerTick_Sub(OnTimerTick);

            // Set labels
                // variables
            Program.SetLabelText(Form.LabelType.maxTimeDif,        maxTimeDif.ToString());
            Program.SetLabelText(Form.LabelType.stopTime,          stopTime.ToString());
            Program.SetLabelText(Form.LabelType.reverseTime,       reverseTime.ToString());
            Program.SetLabelText(Form.LabelType.slowThreshold,     slowThreshold.ToString());
            Program.SetLabelText(Form.LabelType.mediumThreshold,   mediumThreshold.ToString());
            Program.SetLabelText(Form.LabelType.fastThreshold,     fastThreshold.ToString());
                // inputs
            Program.SetLabelText(Form.LabelType.input,             gameInput.WindowTitle);
        }
        #endregion

        #region Public functions
        public void ToggleLoop()
        {
            isLooping = !isLooping;
        }
        #endregion

        #region Other functions
        private void OnSpeedStatusChanged(SpeedStatus _oldStatus, SpeedStatus _newStatus)
        {
            // Handle inputs
            if (isLooping) HandleInputs(_oldStatus, _newStatus);
        }
        private void PrintReceivedTimes()
        {
            List<string> times = new List<string>();
            foreach (DateTime time in receivedTimes)
            {
                times.Add(time.ToString());
            }
            Program.DebugList(times);
        }
        private void InitializeSerialPort(SerialPort _sp)
        {
            sp = _sp;
            if (!sp.IsOpen)
            {
                try
                {
                    sp.Open();
                    Program.DebugLine("Serialport initialized");
                } catch
                {
                    Program.DebugLine("Unable to open port. Make sure port " + sp.PortName + " exists");
                }
                
            }
            sp.DataReceived += ProcessReceivedData;
        }
        #endregion

        #region OnTimerTick
        DateTime reversedTime = DateTime.MinValue;
        private void OnTimerTick(object sender, EventArgs args)
        {
            // Received stack
            for (int i = 0; i < receivedStack.Count; i++)
            {
                // Program.DebugLine(receivedStack[i].ToString());
            }
            receivedStack.Clear();
            // Received times
            // Delete all times older than x seconds
            if (receivedTimes.Count >= 1)
            {
                DateTime nowTime = DateTime.Now;
                for (int i = receivedTimes.Count - 1; i >= 0; i--)
                {
                    if (nowTime.Subtract(receivedTimes[i]) > TimeSpan.FromSeconds(maxTimeDif))
                    {
                        receivedTimes.RemoveAt(i);
                    }
                }
            }

            // Calculate rpm
                // count = count of rotations in maxTimeDif seconds
                // time = maxTimeDif
                // check stoptime first
            if(receivedTimes.Count == 0 || DateTime.Now.Subtract(receivedTimes.Last()).TotalSeconds > stopTime)
            {
                isCycling = false;
                rpm = 0;
            } else
            {
                isCycling = true;
                rpm = (float)receivedTimes.Count / maxTimeDif;
            }

            SpeedStatus newStatus;
            // Calculate speedStatus
            if (rpm > fastThreshold)        newStatus = SpeedStatus.fastCycle;
            else if(rpm > mediumThreshold)  newStatus = SpeedStatus.mediumCycle;
            else if (rpm > slowThreshold)   newStatus = SpeedStatus.slowCycle;
            else                            newStatus = SpeedStatus.noCycle;

            // Check if started reversing (last two times are very close)
            if (receivedTimes.Count >= 2)
            {
                DateTime newest0 = receivedTimes[receivedTimes.Count - 1];
                DateTime newest1 = receivedTimes[receivedTimes.Count - 2];

                if (newest0 == reversedTime) return;

                float difference = (float)newest0.Subtract(newest1).TotalSeconds;
                if (difference < reverseTime)
                {
                    isReversing = gameInput.ToggleReverse(!isReversing, (int)newStatus >= (int)SpeedStatus.slowCycle);
                    reversedTime = newest0;
                }
            }

            // SpeedStatus changed
            if (newStatus != speedStatus)
            {
                OnSpeedStatusChanged(speedStatus, newStatus);
                speedStatus = newStatus;
            }

            // Set labels
            Program.SetLabelText(Form.LabelType.rpm,           rpm.ToString("0.00"));
            Program.SetLabelText(Form.LabelType.isCycling,     isCycling.ToString());
            Program.SetLabelText(Form.LabelType.isReversing,   isReversing.ToString());
            Program.SetLabelText(Form.LabelType.cyclesCount,   receivedTimes.Count.ToString());
            Program.SetLabelText(Form.LabelType.speedStatus,   speedStatus.ToString());

            // Set speed bar
            Program.SetSpeedBard((int)((rpm / fastThreshold) * 100));
        }
        #endregion

        #region Inputs
        private GameInput gameInput = new GameInput_Minecraft();          // choose GameInput for wanted application
        private void HandleInputs(SpeedStatus _oldStatus, SpeedStatus _newStatus)
        {
            gameInput.UpdateGameInput(_oldStatus, _newStatus, ActiveWindowTitle());
        }
        #endregion

        #region GameInput class
        private abstract class GameInput
        {
            public abstract string WindowTitle { get; protected set; } // override with the window name of target application (or part of it)
            protected abstract void HandleInputs(SpeedStatus _oldStatus, SpeedStatus _newStatus);
            public abstract bool ToggleReverse(bool _reverse, bool _moving); // returns reversing value after completion

            public void UpdateGameInput(SpeedStatus _oldStatus, SpeedStatus _newStatus, string _activeWindowTitle)
            {
                if(_activeWindowTitle.Contains(WindowTitle))
                {
                    HandleInputs(_oldStatus, _newStatus);
                }
            }
        }
        private class GameInput_WoW : GameInput
        {
            /* NOTE:
             *  currently uses 'Ä' as key for toggling walking
             *  remember to keybind it in game
             */
            public override string WindowTitle {get { return "World of Warcraft"; } protected set { }}
            protected override void HandleInputs(SpeedStatus _oldStatus, SpeedStatus _newStatus)
            {
                switch (_newStatus)
                {
                    // WoW
                    case SpeedStatus.noCycle:
                        ToggleMoving(false);
                        break;
                    case SpeedStatus.slowCycle:
                        ToggleWalking(true);
                        ToggleMoving(true);
                        break;
                    case SpeedStatus.mediumCycle:
                        // toggle walk / run -> run
                        ToggleWalking(false);
                        break;
                    case SpeedStatus.fastCycle:
                        break;
                }
            }
            private bool isReversing = false;
            public override bool ToggleReverse(bool _reverse, bool _moving)
            {
                if (_reverse == isReversing) return isReversing;
                isReversing = !isReversing;
                ToggleMoving(_moving);
                return isReversing;
            }

            private bool isWalking = false;
            private void ToggleWalking(bool _value)
            {
                if (isWalking == _value) return;
                isWalking = _value;
                SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyDown, 0x28); // Ä
                SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x28);   // Ä
            }
            private void ToggleMoving(bool _moving)
            {
                if (_moving)
                {
                    if (!isReversing)
                    {       // forward - W
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x1f);   // S
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyDown, 0x11); // W
                    }
                    else  // reverse - S
                    {
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x11);   // W
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyDown, 0x1f); // S
                    }
                }
                else
                {
                    if (isReversing) SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x1f);  // S
                    else SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x11);              // W
                }
            }
        }

        private class GameInput_Minecraft : GameInput
        {
            public override string WindowTitle { get { return "Minecraft"; } protected set { } }
            protected override void HandleInputs(SpeedStatus _oldStatus, SpeedStatus _newStatus)
            {
                Console.WriteLine(_oldStatus.ToString() + " ->" + _newStatus.ToString());

                switch(_newStatus)
                {
                    case SpeedStatus.noCycle:
                        ToggleMoveModifiers(MoveStatus.noMove);
                        ToggleMoving(false);
                        break;
                    case SpeedStatus.slowCycle:
                        ToggleMoveModifiers(MoveStatus.crouch);
                        ToggleMoving(true);
                        break;
                    case SpeedStatus.mediumCycle:
                        ToggleMoveModifiers(MoveStatus.normal);
                        ToggleMoving(true);
                        break;
                    case SpeedStatus.fastCycle:
                        ToggleMoveModifiers(MoveStatus.run);
                        ToggleMoving(true);
                        break;
                }
            }
            public override bool ToggleReverse(bool _reverse, bool _moving)
            {
                if (_reverse == isReversing) return isReversing;
                isReversing = !isReversing;
                ToggleMoving(_moving);
                return isReversing;
            }

            bool isReversing = false;
            private void ToggleMoving(bool _moving)
            {
                if (_moving)
                {
                    if (!isReversing)
                    {       // forward - W
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x1f);
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyDown, 0x11);
                    }
                    else  // reverse - S
                    {
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x11);
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyDown, 0x1f);
                    }
                }
                else
                {
                    if (isReversing) SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x1f);
                    else SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x11);
                }
            }

            enum MoveStatus
            {
                noMove,
                crouch,
                normal,
                run
            }
            private MoveStatus moveStatus = MoveStatus.noMove;
            private void ToggleMoveModifiers(MoveStatus _newMoveStatus)
            {
                if (_newMoveStatus == moveStatus) return;
                
                // Remove old modifiers
                switch(moveStatus)
                {
                    case MoveStatus.crouch:
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x2a); // shift
                        break;
                    case MoveStatus.run:
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x11); // w 
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyUp, 0x1d); // ctrl
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyDown, 0x11); // w
                        break;
                }
                // Add new modifier
                switch(_newMoveStatus)
                {
                    case MoveStatus.crouch:
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyDown, 0x2a); // shift
                        break;
                    case MoveStatus.run:
                        SendingInputs.SendKeyboardInput(SendingInputs.KeyEventF.KeyDown, 0x1d); // ctrl
                        break;
                }

                moveStatus = _newMoveStatus;
            }

        }
        #endregion

        #region Receiving data via serialport
        List<DateTime> receivedTimes = new List<DateTime>();
        List<int> receivedStack = new List<int>();
        public void ProcessReceivedData(object sender, SerialDataReceivedEventArgs e)
        {
            string received = sp.ReadExisting();
            if (received != "A") return; // 'A' is sent by arduino with new cycle
            receivedStack.Add(1);
            receivedTimes.Add(DateTime.Now);
            sp.DiscardInBuffer();
        }
        #endregion
    }
}

public static class SendingInputs
{
    #region Imports
    [DllImport("user32.dll", SetLastError = true)]
    private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);
    [DllImport("user32.dll")]
    private static extern IntPtr GetMessageExtraInfo();
    #endregion

    #region Additional classes
    [StructLayout(LayoutKind.Sequential)]
    public struct KeyboardInput
    {
        public ushort wVk;
        public ushort wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct MouseInput
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct HardwareInput
    {
        public uint uMsg;
        public ushort wParamL;
        public ushort wParamH;
    }
    [StructLayout(LayoutKind.Explicit)]
    public struct InputUnion
    {
        [FieldOffset(0)] public MouseInput mi;
        [FieldOffset(0)] public KeyboardInput ki;
        [FieldOffset(0)] public HardwareInput hi;
    }
    public struct Input
    {
        public int type;
        public InputUnion u;
    }
    [Flags]
    public enum InputType
    {
        Mouse = 0,
        Keyboard = 1,
        Hardware = 2
    }
    [Flags]
    public enum KeyEventF
    {
        KeyDown = 0x0000,
        ExtendedKey = 0x0001,
        KeyUp = 0x0002,
        Unicode = 0x0004,
        Scancode = 0x0008
    }
    [Flags]
    public enum MouseEventF
    {
        Absolute = 0x8000,
        HWheel = 0x01000,
        Move = 0x0001,
        MoveNoCoalesce = 0x2000,
        LeftDown = 0x0002,
        LeftUp = 0x0004,
        RightDown = 0x0008,
        RightUp = 0x0010,
        MiddleDown = 0x0020,
        MiddleUp = 0x0040,
        VirtualDesk = 0x4000,
        Wheel = 0x0800,
        XDown = 0x0080,
        XUp = 0x0100
    }
    #endregion

    public static void SendKeyboardInput(KeyEventF _event, UInt16 _keycode)
    {
        Input[] inputs = new Input[]
        {
                new Input
                {
                    type = (int)InputType.Keyboard,
                    u = new InputUnion
                    {
                        ki = new KeyboardInput
                        {
                            wVk = 0,
                            wScan = _keycode,
                            dwFlags = (uint)(_event | KeyEventF.Scancode),
                            dwExtraInfo = GetMessageExtraInfo()
                        }
                    }
                }
        };
        SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(Input)));

    }
}