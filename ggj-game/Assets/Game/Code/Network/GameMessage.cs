using System;
using UnityEngine;

[Serializable]
public class GameMessage {

    public string type = null;
    // Event
    public string e = null;


    public string ToJson() {

        return JsonUtility.ToJson(this);

    }


    public static GameMessage CreateFromJSON(string jsonString) {

        return JsonUtility.FromJson<GameMessage>(jsonString);

    }

}

