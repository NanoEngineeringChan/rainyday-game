using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*

// Class to store stuff that I want to have global access
[System.Serializable]
public class _G_ : MonoBehaviour
{
    #region Singleton
    public static _G_ _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Error: More than one instance of _G_!!!!!!");
        }

        _instance = this;
    }

    public static _G_ Instance
    {
        get { return _instance; }
    }
    #endregion

    [SerializeField]
    public static GameObject _gCurrentCharacter;

    public static GameObject G_Current_Character
    {
        set
        {
            _gCurrentCharacter = value;
        }

        get
        {
            return _gCurrentCharacter;
        }
    }
}
*/