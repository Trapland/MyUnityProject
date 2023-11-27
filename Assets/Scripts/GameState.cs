using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int pipesPassed { get; set; }

    public static bool isWkeyEnabled { get; set; }

    public static float pipePeriod { get; set; }

    public static float vitality { get; set; }

    public static float DPS { get; set; }

    public static int scoreValue { get; set; }

    public static String toJson()
    {
        return JsonUtility.ToJson(new SaveData());
    }
    public static void fromJson(String json)
    {
        var data = JsonUtility.FromJson<SaveData>(json);
        pipePeriod = data.pipePeriod;
        isWkeyEnabled = data.isWkeyEnabled;
        DPS = data.DPS;
    }
}
[Serializable]
public class SaveData
{
    public float pipePeriod;
    public float DPS;
    public bool isWkeyEnabled;

    public SaveData() 
    {
        pipePeriod = GameState.pipePeriod;
        isWkeyEnabled = GameState.isWkeyEnabled;
        DPS = GameState.DPS;
        GameState.scoreValue = Convert.ToInt32(GameState.DPS) + Convert.ToInt32(GameState.isWkeyEnabled) + Convert.ToInt32(GameState.pipePeriod);
    }
}
/* Об'єкт-стан -- доступний для усіх скриптів "центр"
 * збереження загальної інформації щодо стану ігри
 * 
 */
