using UnityEngine;

/*-----------public class BaseCharacter--------------
 * Holds everything that any type of character will need such
 * as any basic attributes such as health systems, character
 * names, etc. 
 * 
 * Both Playable Characters and NPCs should always inherit from 
 * this class
 * ----------------------------------------------------------
 */
public class BaseCharacter : MonoBehaviour
{
    [SerializeField]
    private string m_characterName;

    // Each character will have its own AnimatorController that will 
    // be held in this variable
    [SerializeField]
    protected Animator m_characterAnim; 

    public string CharacterName
    {
        get { return m_characterName; }
        set { m_characterName = value; }
    }

    public Animator CharacterAnim
    {
        get { return m_characterAnim; }
        set { m_characterAnim = value; }
    }

    protected virtual void Initialize()
    {
        // Name will be set in super class

        // Get the animator component
        CharacterAnim = GetComponent<Animator>();

        if (CharacterAnim == null)
        {
            Debug.Log("ERROR: Character did not have an Animator attached to it!");
        }
    }

}
