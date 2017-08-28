using UnityEngine;

/*-----------public abstract class BaseCharacter--------------
 * Holds everything that any type of character will need such
 * as any basic attributes such as health systems, character
 * names, and death functionality
 * 
 * Both Playable Characters and NPCs should always inherit from 
 * this class
 * ----------------------------------------------------------
 */
public class BaseCharacter : MonoBehaviour 
{
    [SerializeField]
    private string m_characterName;

    public string CharacterName
    {
        get { return m_characterName; }
        set { m_characterName = value; }
    }

    protected void InitializeCharacter(string name)
    {
        CharacterName = name;
    }
}
