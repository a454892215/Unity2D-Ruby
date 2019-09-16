using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SP
{
    public static void SetgitBool(string key, bool value)
    {
        PlayerPrefs.SetString(key + "Bool", value.ToString());
    }

    public static bool GetBool(string key)
    {
        try
        {
            return bool.Parse(PlayerPrefs.GetString(key + "Bool"));
        }
        catch (System.Exception e)
        {
            return false;
        }

    }

    public static void SetString(string key, string value)
    {
        PlayerPrefs.SetString(key, value);
    }

    public static string GetString(string key)
    {
        return PlayerPrefs.GetString(key);
    }

    public static void SetFloat(string key, float value)
    {
        PlayerPrefs.SetFloat(key, value);
    }

    public static float GetFloat(string key)
    {
        return PlayerPrefs.GetFloat(key);
    }
    public static void SetInt(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int GetInt(string key)
    {
        return PlayerPrefs.GetInt(key);
    }

}
