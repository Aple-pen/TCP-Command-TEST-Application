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

namespace TCP_Command_Test
{
    public partial class Form1 : Form
    {
        private bool isConnected = false;
        private TcpClient tcpClient;
        private static StreamReader streamReader;
        private static StreamWriter streamWriter;
        string serverIp = "192.168.123.102";
        int serverPort = 5025;
        private byte[] readBuffer;

        public Form1()
        {
            InitializeComponent();
            tb_ip.Text = serverIp;
            tb_port.Text = serverPort.ToString();

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
                if (!r) return;
                btn_connect.Text = "연결해제";
                isConnected = true;
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

                    SEND_COMMAND("*IDN?");
                    return true;
                }
                catch
                {
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
            //Debug.WriteLine("send com : " + com);
            string str = null;
            if (tcpClient != null)
            {
                if (tcpClient.Connected) // 클라이언트가 연결되어 있는 동안
                {
                    streamWriter.WriteLine(com);
                    while (str == null)
                    {
                        str = streamReader.ReadLine(); // 수신 데이타를 읽어서 receiveData1 변수에 저장
                        continue;
                    }
                }
            }

            textBox4.AppendText(str);
            textBox4.AppendText("");
            
            return str;
        }
        
        public void Disconnect()
        {
            streamReader.Close();
            streamReader.Dispose();
            streamWriter.Close();
            streamWriter.Dispose();
            tcpClient.Close();
            tcpClient.Dispose();
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            if (!isConnected)
            {
                MessageBox.Show("TCP 연결 해주세요","알림",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            SEND_COMMAND(textBox1.Text);
            Command_list.Items.Add(textBox1.Text);
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
    }
}