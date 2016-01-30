using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;


public class Server : MonoBehaviour {

    private TcpClient client = null;
    private StreamReader sr = null;
    private StreamWriter sw = null;

    private System.Object WriteLock = new System.Object();
    private Thread Thread;


    // Use this for initialization
    void Start() {

        ThreadStart ts = new ThreadStart(Listen);
        Thread = new Thread(ts);
        Thread.Start();

    }


    void Listen() {

        try {

            client = new TcpClient("52.90.77.154", 11000);

            Stream s = client.GetStream();
            sr = new StreamReader(s);
            sw = new StreamWriter(s);
            sw.AutoFlush = true;

        }
        catch (Exception e) {

            Debug.Log("Connection to server failed.");
            client.Close();
            return;

        }

        while (true) {

            string Data = sr.ReadLine();
            if (Data == "")
                break;

            Debug.Log(Data);

            try {

                GameMessage Msg = GameMessage.CreateFromJSON(Data);
                if (Msg != null)
                    Debug.Log("Type: " + Msg.type + "; Event: " + Msg.e);

            }
            catch (Exception e) {

                Debug.Log(e);

            }

        }

        client.Close();

    }


    public void Send(GameMessage Msg) {

        // Convert the string data to Json
        string Data = Msg.ToJson();

        // Send the data to the remote server
        lock (WriteLock) {

            sw.Write(Data);

        }

    }

}

