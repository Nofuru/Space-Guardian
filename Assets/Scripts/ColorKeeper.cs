using System.Collections.Generic;
using UnityEngine;

public class ColorKeeper : MonoBehaviour
{
    public static int savedColor = 0;

    private void Awake()
    {
        savedColor = PlayerPrefs.GetInt("SavedColor");
    }
}
