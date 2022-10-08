using System;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace OpticalSwitchGUI
{
    public partial class Form1 : Form
    {
        #region Private fields

        private string _TestHostName = "Test";
        private string _TestHost = "192.168.0.178";

        private string _TXSwitchHostName = "TX";
        private string _TXSwitchHost = "192.168.108.180";

        private string _RXSwitchHostName = "RX";
        private string _RXSwitchHost = "192.168.108.181";

        private string _KMInSwitchHostName = "KM IN";
        private string _KMInSwitchHost = "192.168.108.178";

        private string _KMOutSwitchHostName = "KM OUT";
        private string _KMOutSwitchHost = "192.168.108.179";

        private string _maxChannelCmd = "<AD01_MAX_?>";
        private string _currentChannelCmd = "<AD01_T_CHN?>";

        private string _maxChannelResponce = string.Empty;
        private string _currentChannelResponce = string.Empty;

        private string _substringMaxChannel;
        private string _substringCurrentChannel;
        private bool _upChannelBtn = false;
        private bool _downChannelBtn = false;

        #endregion Private fields

        #region Constructor

        public Form1()
        {
            InitializeComponent();
        }

        #endregion Constructor

        #region SwitchesLstBx_SelectedIndexChanged

        /// <summary>
        /// When the user clicks on a switch in the list, they're then able to click the up/down button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SwitchesLstBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpBtn.Enabled = true;
            DownBtn.Enabled = true;

            using (TcpClient tcpClnt = new TcpClient())
            {
                DisplayChannel(tcpClnt);

                using (NetworkStream stream = tcpClnt.GetStream())
                {
                    RecallChannel(_maxChannelCmd, tcpClnt, stream);
                    RecallChannel(_currentChannelCmd, tcpClnt, stream);

                    _substringCurrentChannel = _currentChannelResponce.Substring(6, 2);//Current channel e.g. 02
                    CurrentChannelLbl.Text = _substringCurrentChannel;
                }
            }
        }

        #endregion SwitchesLstBx_SelectedIndexChanged

        #region UpBtn_Click

        private void UpBtn_Click(object sender, EventArgs e)
        {
            using (TcpClient tcpClnt = new TcpClient())
            {
                _upChannelBtn = true;

                DisplayChannel(tcpClnt);

                using (NetworkStream stream = tcpClnt.GetStream())
                {
                    RecallChannel(_maxChannelCmd, tcpClnt, stream);
                    RecallChannel(_currentChannelCmd, tcpClnt, stream);

                    _substringMaxChannel = _maxChannelResponce.Substring(11, 2);//Max channel e.g. 48
                    _substringCurrentChannel = _currentChannelResponce.Substring(6, 2);//Current channel e.g. 02

                    if (_upChannelBtn == true && _downChannelBtn == false)
                    {
                        int number = int.Parse(_substringCurrentChannel);
                        _substringCurrentChannel = (number + 1).ToString();//Move the current channel up one e.g. from 1 to 2

                        Add0ToChannel();

                        //The current channel is more than the maximum channel e.g. 48
                        if (_upChannelBtn == true && int.Parse(_substringCurrentChannel) > int.Parse(_substringMaxChannel))
                        {
                            _substringCurrentChannel = "00";
                            CurrentChannelLbl.Text = "00";
                        }

                        //The current channel is less than the maximum channel e.g. 48
                        if (_upChannelBtn == true && int.Parse(_substringCurrentChannel) < int.Parse(_substringMaxChannel))
                        {
                            RecallChannel(_currentChannelCmd, tcpClnt, stream);
                            CurrentChannelLbl.Text = _currentChannelResponce.Substring(6, 2);//Current channel e.g. 02
                        }
                    }
                    ChangeChannelCommand(tcpClnt, stream);

                    _upChannelBtn = false;

                    RecallChannel(_currentChannelCmd, tcpClnt, stream);
                    CurrentChannelLbl.Text = _currentChannelResponce.Substring(6, 2);//New current channel e.g. 02
                }
            }
        }

        #endregion UpBtn_Click

        #region DownBtn_Click

        private void DownBtn_Click(object sender, EventArgs e)
        {
            using (TcpClient tcpClnt = new TcpClient())
            {
                _downChannelBtn = true;

                DisplayChannel(tcpClnt);

                using (NetworkStream stream = tcpClnt.GetStream())
                {
                    RecallChannel(_maxChannelCmd, tcpClnt, stream);
                    RecallChannel(_currentChannelCmd, tcpClnt, stream);
                    _substringMaxChannel = _maxChannelResponce.Substring(11, 2);//Max channel e.g. 48
                    _substringCurrentChannel = _currentChannelResponce.Substring(6, 2);//Current channel e.g. 02

                    if (_downChannelBtn == true && _upChannelBtn == false)
                    {
                        int number = int.Parse(_substringCurrentChannel);
                        _substringCurrentChannel = (number - 1).ToString();//Move the current channel down e.g. from 2 to 1

                        Add0ToChannel();

                        //Change the text to the maximum channel (e.g. 48) because its below 0
                        if (_downChannelBtn == true && _substringCurrentChannel.Contains("0-1"))
                        {
                            RecallChannel(_maxChannelCmd, tcpClnt, stream);
                            _substringCurrentChannel = _substringMaxChannel;
                            CurrentChannelLbl.Text = _substringMaxChannel;
                        }

                        //The current channel is more than 0
                        if (_downChannelBtn == true && int.Parse(_substringCurrentChannel) > 0)
                        {
                            RecallChannel(_currentChannelCmd, tcpClnt, stream);
                            CurrentChannelLbl.Text = _currentChannelResponce.Substring(6, 2);//Current channel e.g. 02
                        }
                    }
                    ChangeChannelCommand(tcpClnt, stream);

                    _downChannelBtn = false;

                    RecallChannel(_currentChannelCmd, tcpClnt, stream);
                    CurrentChannelLbl.Text = _currentChannelResponce.Substring(6, 2);//New current channel e.g. 02
                }
            }
        }

        #endregion DownBtn_Click

        #region ConnectToIPv4

        /// <summary>
        /// Connect to optical switch on ethernet
        /// </summary>
        public void ConnectToIPv4(TcpClient tcpClnt, string host, string hostname)
        {
            try
            {
                StatusLbl.Text = "Connecting...";
                tcpClnt.Connect(host, 4001);
            }
            catch (Exception exception)
            {
                StatusLbl.Text = "Failed";
                MessageBox.Show("Connection failed: " + exception + "\nClosing app");//If no connection is found
                Close();
            }
            StatusLbl.Text = "Connected to: " + hostname;
        }

        #endregion ConnectToIPv4

        #region RecallChannel

        /// <summary>
        /// Talk to the optical switch and get the sent parameter
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="tcpClnt"></param>
        public void RecallChannel(string channel, TcpClient tcpClnt, NetworkStream stream)
        {
            byte[] data = Encoding.ASCII.GetBytes(channel);//Translate passed message
            int bytes;

            //Send a message to the server
            stream.Write(data, 0, data.Length);
            Cursor.Current = Cursors.WaitCursor;

            //Receive the responce from the server
            data = new byte[256];
            bytes = stream.Read(data, 0, data.Length);

            if (channel == _maxChannelCmd || channel == _substringMaxChannel)
            {
                _maxChannelResponce = Encoding.ASCII.GetString(data, 0, bytes);
            }

            if (channel == _substringCurrentChannel && _upChannelBtn == true || _downChannelBtn == true)
            {
                _currentChannelResponce = Encoding.ASCII.GetString(data, 0, bytes);
            }

            if (channel == _currentChannelCmd && _upChannelBtn == false || _downChannelBtn == false)
            {
                _currentChannelResponce = Encoding.ASCII.GetString(data, 0, bytes);
            }
            Cursor.Current = Cursors.Default;
        }

        #endregion RecallChannel

        #region Add0ToChannel

        /// <summary>
        /// Current channel is less than 10
        /// </summary>
        public void Add0ToChannel()
        {
            if (int.Parse(_substringCurrentChannel) < 10)
            {
                _substringCurrentChannel = "0" + _substringCurrentChannel;//Add a 0 to the channel if its below 10
            }
        }

        #endregion Add0ToChannel

        #region ChangeChannelCommand

        /// <summary>
        /// Change the current channel depending on the user clicking the up/down button
        /// </summary>
        public void ChangeChannelCommand(TcpClient tcpClnt, NetworkStream stream)
        {
            _substringCurrentChannel = _substringCurrentChannel.Insert(0, "<AD01_S_");
            _substringCurrentChannel = _substringCurrentChannel.Insert(10, ">");

            RecallChannel(_substringCurrentChannel, tcpClnt, stream);
            _substringCurrentChannel = _currentChannelResponce.Substring(6, 2);//New current channel e.g. 02
        }

        #endregion ChangeChannelCommand

        #region DisplayChannel

        /// <summary>
        /// Show the current channel to the user
        /// </summary>
        /// <param name="tcpClnt"></param>
        public void DisplayChannel(TcpClient tcpClnt)
        {
            if (SwitchesLstBx.GetItemText(SwitchesLstBx.SelectedItem) == "Test")
            {
                ConnectToIPv4(tcpClnt, _TestHost, _TestHostName);
            }
            else if (SwitchesLstBx.GetItemText(SwitchesLstBx.SelectedItem) == "TX")
            {
                ConnectToIPv4(tcpClnt, _TXSwitchHost, _TXSwitchHostName);
            }
            else if (SwitchesLstBx.GetItemText(SwitchesLstBx.SelectedItem) == "RX")
            {
                ConnectToIPv4(tcpClnt, _RXSwitchHost, _RXSwitchHostName);
            }
            else if (SwitchesLstBx.GetItemText(SwitchesLstBx.SelectedItem) == "KM IN")
            {
                ConnectToIPv4(tcpClnt, _KMInSwitchHost, _KMInSwitchHostName);
            }
            else if (SwitchesLstBx.GetItemText(SwitchesLstBx.SelectedItem) == "KM OUT")
            {
                ConnectToIPv4(tcpClnt, _KMOutSwitchHost, _KMOutSwitchHostName);
            }
        }
    }

    #endregion DisplayChannel
}