using System;
using UnityEngine;

[Serializable]
public class GameMessage {

    public string type = null;
    public string e = null; // Event
    public string player = null;
    public int targetId = 0;

    [Serializable]
    public struct GmDt
    {
        public int score;
    };
    public GmDt details;



    public string ToJson() {

        return JsonUtility.ToJson(this);

    }


    public static GameMessage CreateFromJSON(string jsonString) {

        GameMessage Msg = JsonUtility.FromJson<GameMessage>(jsonString);
        if (Msg != null) {

            if (Msg.player == "red")
                Msg.targetId = 3;
            else if (Msg.player == "green")
                Msg.targetId = 2;
            else if (Msg.player == "yellow")
                Msg.targetId = 1;
            else if (Msg.player == "blue")
                Msg.targetId = 0;
        }

        return Msg;
    }

}

