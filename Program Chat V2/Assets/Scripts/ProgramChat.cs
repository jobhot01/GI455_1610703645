using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WebSocketSharp;


namespace Program_Chat
{
    public class ProgramChat : MonoBehaviour
    {
        public WebSocket webSocket;

        public InputField IP;
        public InputField Port;
        public InputField MassageIF;

        public Button ConnectButton;
        public Button SendButton;

        public GameObject MessagePF;
        public Transform MessageBoxPanel;
        public GameObject LogInPanel;
        public GameObject MainChatPanel;


        public void ReceivedMessage(object sender, MessageEventArgs args)
        {
            //แสดงข้อความ
            var prefabs = Instantiate(MessagePF, MessageBoxPanel.transform);
            var child = prefabs.transform.GetChild(0);

            //จัดตำแหน่งข้อความ
            MessagePF.GetComponent<VerticalLayoutGroup>().childAlignment = TextAnchor.LowerLeft;
            child.GetComponent<Text>().text = args.Data;
            child.GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        }

        public void Connect()
        {
            webSocket = new WebSocket($"ws://{IP.text}:{Port.text}/");
            
            //รับข้อความ
            webSocket.OnMessage += ReceivedMessage;
            
            //เชื่อมต่อเซิฟ
            webSocket.Connect();

            //สลับหน้าต่าง
            MainChatPanel.SetActive(true);
            LogInPanel.SetActive(false);
        }

        //ส่งข้อความไปที่เซิฟจาก Input Field
        public void SendMassage()
        {
            webSocket.Send(MassageIF.text);

            //จัดตำแหน่งข้อความ
            var prefabs = Instantiate(MessagePF, MessageBoxPanel.transform);
            var child = prefabs.transform.GetChild(0);

            child.GetComponent<Text>().text = MassageIF.text;
        }
    }
}

