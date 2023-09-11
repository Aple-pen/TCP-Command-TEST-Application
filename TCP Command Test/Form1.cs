using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCP_Command_Test.utils;

namespace TCP_Command_Test
{
    public partial class Form1 : Form
    {
        private bool isConnected = false;
        private TcpClient tcpClient;
        private static StreamReader streamReader;
        private static StreamWriter streamWriter;
        string serverIp = IniFile.GetValue("network", "ip", "127.0.0.1");
        int serverPort = Convert.ToInt32(IniFile.GetValue("network", "port", "5600"));
        private byte[] readBuffer;

        public Form1()
        {
            InitializeComponent();
            tb_ip.Text = serverIp;
            tb_port.Text = serverPort.ToString();
            textBox4.ScrollBars = ScrollBars.Vertical;

            // 서버의 IP 주소와 포트 번호
        }

        void SendData(TcpClient client, string data)
        {
            // 데이터 전송을 위한 스트림 생성
            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(data);
                stream.Write(buffer, 0, buffer.Length);
                Console.WriteLine("데이터를 전송했습니다: " + data);
            }
        }

        string ReceiveData(TcpClient client)
        {
            // 데이터 수신을 위한 스트림 생성
            using (NetworkStream stream = client.GetStream())
            {
                byte[] buffer = new byte[client.ReceiveBufferSize];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string receivedData = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                return receivedData;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TCP 클라이언트 생성

            if (!isConnected)
            {
                var r = ConnectTcp();
                if (!r)
                {
                    MessageBox.Show("IP와 Port를 확인 후 다시 시도 해주세요.", "연결 실패", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }


                btn_connect.Text = "연결해제";
                isConnected = true;
                IniFile.SetValue("network", "ip", tb_ip.Text);
                IniFile.SetValue("network", "port", tb_port.Text);
            }
            else
            {
                Disconnect();
                btn_connect.Text = "연결";
                isConnected = false;
            }
        }

        async Task SendDataAsync(TcpClient client, string data)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            await client.GetStream().WriteAsync(buffer, 0, buffer.Length);
            Console.WriteLine("데이터를 비동기적으로 전송했습니다: " + data);
        }

        bool ConnectTcp()
        {
            //연결이 되어있지 않은 경우
            if (tcpClient == null)
            {
                tcpClient = new TcpClient(); // TcpClient 객체 생성
                try
                {
                    // 서버에 연결 요청
                    if (!tcpClient.ConnectAsync(tb_ip.Text, Int32.Parse(tb_port.Text)).Wait(1000))
                    {
                        //connect timeout 처리
                        tcpClient = null;
                        return false;
                    }

                    // Debug.WriteLine("서버 연결됨...");
                    streamReader = new StreamReader(tcpClient.GetStream()); // 읽기 스트림 연결
                    streamWriter = new StreamWriter(tcpClient.GetStream()); // 쓰기 스트림 연결
                    streamWriter.AutoFlush = true; //자동으로 버퍼 비워줌.
                    //전역변수로 연결되었는지를 설정

                    streamReader.BaseStream.ReadTimeout = 2000;

                    SEND_COMMAND("*IDN?");
                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
            }

            //이미 연결되어있을 경우.
            if (tcpClient.Connected)
            {
                //전역변수로 연결되었는지를 설정
                return true;
            }

            tcpClient = null;
            return false;
        }

        public string SEND_COMMAND(string com)
        {
            string str = null;
            //Debug.WriteLine("send com : " + com);
            try
            {
                if (tcpClient != null)
                {
                    if (tcpClient.Connected) // 클라이언트가 연결되어 있는 동안
                    {
                        streamWriter.WriteLine(com);
                        if (com.Contains("?"))
                        {
                            while (str == null)
                            {
                                str = streamReader.ReadLine(); // 수신 데이타를 읽어서 receiveData1 변수에 저장
                                continue;
                            }
                        }
                    }
                }

                if (str != null)
                {
                    Invoke(new MethodInvoker(() =>
                    {
                        textBox4.AppendText(str);
                        textBox4.AppendText("\r\n");
                    }));
                }


                return str == null ? "" : str;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                Invoke(new MethodInvoker(() =>
                {
                    textBox4.AppendText("IO EXCEPTION");
                    textBox4.AppendText("\r\n");
                }));
                return "err";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                MessageBox.Show(e.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Disconnect();
                Invoke(new MethodInvoker(() => { btn_connect.Text = "연결"; }));
                isConnected = false;
                return "err";
            }
            
        }

        public void Disconnect()
        {
            streamReader.Close();
            streamReader.Dispose();
            streamWriter.Close();
            streamWriter.Dispose();
            tcpClient.Close();
            tcpClient.Dispose();
            tcpClient = null;
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("TCP 연결 해주세요", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CommandSend();
        }

        private void Command_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Command_list.SelectedItem.ToString();
        }

        private void ReceiveData_Clear_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
        }

        private void CommandList_Clear_Click(object sender, EventArgs e)
        {
            Command_list.Items.Clear();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CommandSend();
            }
        }

        private void CommandSend()
        {
            Task.Run(() => SEND_COMMAND(textBox1.Text));
            Command_list.Items.Add(textBox1.Text);
        }
    }
}