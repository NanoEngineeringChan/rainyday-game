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
    private string _characterName;

    // Each character will have its own AnimatorController that will 
    // be held in this variable
    [SerializeField]
    protected Animator _characterAnim;

    [SerializeField]
    protected SpriteRenderer _spriteRenderer;

    public string CharacterName
    {
        get { return _characterName; }
        set { _characterName = value; }
    }

    public Animator CharacterAnim
    {
        get { return _characterAnim; }
        set { _characterAnim = value; }
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
