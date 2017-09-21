using UnityEngine;

[System.Serializable]

/*
 * Base Class for a stat
 */
public class Stat
{
    [SerializeField]
    private int m_baseValue;

    public int GetValue()
    {
        return m_baseValue;
    }
}
