using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour 
{
    private int _currentCharacter = 0;
    private int _previousCharacter = 0;

    [SerializeField]
    private List<GameObject> _currentParty;

	private void Start ()
	{
        _currentParty = new List<GameObject>(transform.childCount);

        FillCurrentPartyList();

//        SwitchCharacter();
	}

    private void Update()
    { 
        _previousCharacter = _currentCharacter;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _currentCharacter = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && (transform.childCount >= 2 ))
        {
            _currentCharacter = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && (transform.childCount >= 3))
        {
            _currentCharacter = 2;
        }

        if (_previousCharacter != _currentCharacter)
        {
            SwitchCharacter();
        }
	}

    private void FillCurrentPartyList()
    {
        int i = 0;

        foreach (Transform characters in this.transform)
        {
            _currentParty.Add(characters.gameObject);

            i++;
        }
    }

    private void SwitchCharacter()
    {
        /* When the button to change character's is pressed, set the current character
         * to the previous character, deactivate it, then activate the new character
         * 
         * But the positions of the characters currently in the party should be the same as eachother
         * at all times, so it should be updated up
         */

        int i = 0;

        Vector2 previousCharacterPos = _currentParty[_previousCharacter].transform.position;
        Vector2 previousCharacterScale = _currentParty[_previousCharacter].transform.localScale;
        bool previousFacingRight = _currentParty[_previousCharacter].GetComponent<PlayerMovement>().FacingRight;


        Debug.Log("PREVIOUS CHARACTER: " + _previousCharacter);
        Debug.Log("NEW CHARACTER: " + _currentCharacter);

        foreach (GameObject characters in _currentParty)
        {
            if (i == _currentCharacter)
            {
                // Update the position of the new character
                _currentParty[i].transform.position = previousCharacterPos;

                // Face the new character in the same direction as the previous one
                if(_currentParty[i].transform.localScale.x != previousCharacterScale.x)
                {
                    Debug.Log("PREVIOUS CHARACTER WAS FACING IN DIFFERENT DIRECTION");

                    _currentParty[i].transform.localScale = previousCharacterScale;

                    _currentParty[i].GetComponent<PlayerMovement>().FacingRight = previousFacingRight;
                }

                // Activate the new character
                _currentParty[i].gameObject.SetActive(true);

            }
            else
            {
                _currentParty[i].gameObject.SetActive(false);
            }

            i++;
        }
    }
}
