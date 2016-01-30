using System;
using UnityEngine;

[Serializable]
class GameMessage {

    public string type = null;
    // Event
    public string e = null;

    public static GameMessage CreateFromJSON(string jsonString) {

        return JsonUtility.FromJson<GameMessage>(jsonString);

    }

}

