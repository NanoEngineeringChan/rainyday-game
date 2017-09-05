using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour 
{
    private int m_currentCharacter = 0;
    private int m_previousCharacter = 0;

    [SerializeField]
    private List<GameObject> m_currentParty;

	private void Start ()
	{
        m_currentParty = new List<GameObject>(transform.childCount);

        FillCurrentPartyList();

        SwitchCharacter();
	}

    private void Update()
    { 
        m_previousCharacter = m_currentCharacter;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_currentCharacter = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Alpha2) && (transform.childCount >= 2 ))
        {
            m_currentCharacter = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && (transform.childCount >= 3))
        {
            m_currentCharacter = 2;
        }

        if (m_previousCharacter != m_currentCharacter)
        {
            SwitchCharacter();
        }
	}

    private void FillCurrentPartyList()
    {
        int i = 0;

        foreach (Transform characters in this.transform)
        {
            m_currentParty.Add(characters.gameObject);

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

        Vector2 previousCharacterPos = m_currentParty[m_previousCharacter].transform.position;
        Vector2 previousCharacterScale = m_currentParty[m_previousCharacter].transform.localScale;
        bool previousFacingRight = m_currentParty[m_previousCharacter].GetComponent<PlayerMovement>().FacingRight;


        Debug.Log("PREVIOUS CHARACTER: " + m_previousCharacter);
        Debug.Log("NEW CHARACTER: " + m_currentCharacter);

        foreach (GameObject characters in m_currentParty)
        {
            if (i == m_currentCharacter)
            {
                // Update the position of the new character
                m_currentParty[i].transform.position = previousCharacterPos;

                // Face the new character in the same direction as the previous one
                if(m_currentParty[i].transform.localScale.x != previousCharacterScale.x)
                {
                    Debug.Log("PREVIOUS CHARACTER WAS FACING IN DIFFERENT DIRECTION");

                    m_currentParty[i].transform.localScale = previousCharacterScale;

                    m_currentParty[i].GetComponent<PlayerMovement>().FacingRight = previousFacingRight;
                }

                // Activate the new character
                m_currentParty[i].gameObject.SetActive(true);

            }
            else
            {
                m_currentParty[i].gameObject.SetActive(false);
            }

            i++;
        }
    }
}
