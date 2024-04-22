using Godot.Collections;
using System;

public partial class GameData
{
    public static Dictionary<string, int> gameData_Int = new Dictionary<string, int>();

    public void SetInt(string key, int value)
    {
        if (gameData_Int.ContainsKey(key))
        {
            gameData_Int[key] = value;
        }
        else
        {
            gameData_Int.Add(key, value);
        }
    }

    public void ChangeInt(string key, int value)
    {
        if(gameData_Int.ContainsKey(key))
        {
            gameData_Int[key] += value;
        }
        else
        {
            gameData_Int.Add(key, value);
        }
    }
}
