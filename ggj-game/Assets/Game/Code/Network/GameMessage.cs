using System;
using UnityEngine;

[Serializable]
public class GameMessage {

    public string type = null;
    public string e = null; // Event
    public string target = null;
    public int targetId = 0;


    public string ToJson() {

        return JsonUtility.ToJson(this);

    }


    public static GameMessage CreateFromJSON(string jsonString) {

        GameMessage Msg = JsonUtility.FromJson<GameMessage>(jsonString);
        if (Msg != null) {

            if (Msg.target == "red")
                Msg.targetId = 0;
            else if (Msg.target == "green")
                Msg.targetId = 1;
            else if (Msg.target == "yellow")
                Msg.targetId = 2;
            else if (Msg.target == "blue")
                Msg.targetId = 3;
        }

        return Msg;
    }

}

