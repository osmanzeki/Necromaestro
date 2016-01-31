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


	void Awake () {
		GameEvents.GameConnectedSignal.AddListener(StartGame);
	}

    void Start() {
		UnityEngine.Object.DontDestroyOnLoad(gameObject);

        ThreadStart ts = new ThreadStart(Listen);
        Thread = new Thread(ts);
        Thread.Start();
    }

	void OnDestroy () {
		GameEvents.GameConnectedSignal.RemoveListener(StartGame);
    }

    void OnApplicationQuit() {
        if (client != null)
            client.Close();
    }

    void StartGame () {
		Debug.Log("Game BEGINS");
	}

    void Listen() {

        try {

            client = new TcpClient("52.90.77.154", 11000);

            Stream s = client.GetStream();
            sr = new StreamReader(s);
            sw = new StreamWriter(s);
            sw.AutoFlush = true;

			GameEvents.GameConnectedSignal.Dispatch();
        }
        catch (Exception) {

            Debug.Log("Connection to server failed.");
            client.Close();
            return;

        }

        Debug.Log("Connected to server.");

        while (true) {

            string Data = null;

            try {

                Data = sr.ReadLine();

            }
            catch(Exception) {

                break;

            }

            if (Data == null || Data == "" || Data.Length == 0)
                break;

            Debug.Log(Data);

            try {

                GameMessage Msg = GameMessage.CreateFromJSON(Data);
				if (Msg != null) {
					//Debug.Log("Type: " + Msg.type + "; Event: " + Msg.e);

                    // Input events
                    GameController.gameController.addMessage(Msg);
                }

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

