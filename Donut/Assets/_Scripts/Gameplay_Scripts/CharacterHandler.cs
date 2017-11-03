using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHandler : MonoBehaviour
{
    #region Singleton
    public static CharacterHandler _instance;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Error: More than one instance of CharacterSwitchHandler");
        }

        _instance = this;
    }

    public static CharacterHandler Instance
    {
        get { return _instance; }
    }
    #endregion

    // Indices into the character list for the current and previous characters 
    private int _currChar = 0;
    private int _prevChar = 0;

    // List of GameObjects that contains the available characters
    // for the player to choose from
    [SerializeField]
    private List<GameObject> _characters;

    // Holds the object of whatever character is currently active
    // Access should be global so I don't have to declare a million references
    // to the current character. Will allow me to easily pass this object around for 
    // handling animations/abilities/whatever for any of the characters. 
    public GameObject _currentCharacter;

    // Have a reference to the previous character in order to update transforms upon switch
    [SerializeField]
    private GameObject _previousCharacter;

    private void Start()
    {
        // Create the list - this script will be attached to an empty
        // GameObject and the children will be the GameObjects of the available
        // characters to choose from
        _characters = new List<GameObject>(transform.childCount);

        // Fill up the list with the available characters
        foreach (Transform characters in this.transform)
        {
            _characters.Add(characters.gameObject);
        }

        // Initially, set the current character to the first object in the characters list
        _currentCharacter = _characters[0];
    }

    private void Update()
    {
        SwitchCharacter();
    }

    // Switch Characters on button press - if the button pressed is not the same as the
    // index for the current character, call HandleCharacterSwitch to update positions,
    // disable current character, and enable new character
    private void SwitchCharacter()
    {
        _prevChar = _currChar;
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _prevChar = _currChar;
            _previousCharacter = _characters[_prevChar];

            _currChar = 0;
            _currentCharacter = _characters[_currChar];
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && (transform.childCount >= 2 ))
        {
            _prevChar = _currChar;
            _previousCharacter = _characters[_prevChar];


            _currChar = 1;
           _currentCharacter = _characters[_currChar];
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && (transform.childCount >= 3))
        {
            _prevChar = _currChar;
            _previousCharacter = _characters[_prevChar];


            _currChar = 2;
            _currentCharacter = _characters[_currChar];
        }

        if (_prevChar != _currChar)
        {
            HandleCharacterSwitch();
        }

    }

    // Handles updating positions for new characters, changing directions of the new character
    // if the previous character was facing a different direction, swap health bars, and anything else
    // that needs to be changed
    private void HandleCharacterSwitch()
    {
        Debug.Log("CURRENT CHAR: " + _currentCharacter.name);
        Debug.Log("PREVIOUS CHAR: " + _previousCharacter.name);

        // On switch, set the new character's position to the previously active character's position
        _currentCharacter.transform.position = _previousCharacter.transform.position;

        // If the previous character and the new character are facing in different directions, 
        // then make sure to face the new character in the right direction
        if (((0 > _previousCharacter.transform.localScale.x) && (0 < _currentCharacter.transform.localScale.x) ||
             ((0 < _previousCharacter.transform.localScale.x) && (0 > _currentCharacter.transform.localScale.x))))
        {
            Debug.Log("FLIPPING CHARACTER: " + _currentCharacter.name);

            _currentCharacter.GetComponent<PlayerMovement>().ChangeCharacterDirection();
            _currentCharacter.GetComponent<PlayerMovement>().FacingRight = _previousCharacter.GetComponent<PlayerMovement>().FacingRight;
        }

        

        // Now, enable the new character, and disable the previous character
        _currentCharacter.SetActive(true);
        _previousCharacter.SetActive(false);
    }
}
