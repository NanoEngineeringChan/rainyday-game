using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * ----------public class PlayableCharacter---------
 * A Playable Character will hold a playable character's
 * movement based on user input, health bars, stats, 
 * ability bars, etc. Will always have a movement script
 * attached to it. 
 * 
 * Each new character controller will inherit from this 
 * (i.e SludgeWaveCharacter or CometKidCharacter should both inherit this)
 * -------------------------------------------------
 */
 [System.Serializable]

public class PlayableCharacter : BaseCharacter
{
    /*    TODO:
     *  - Add Health component
     *  - Figure out where I want to handle abilities and UI health bars, etc.
     *  - Add whatever else a PlayableCharacter might need
     */

    // Every playable character needs access to this script    
    protected PlayerMovement m_playerMovement;

    public void Awake()
    {
        m_playerMovement = GetComponent<PlayerMovement>();
    }

    public void Start()
    {
        Debug.Log("Calling Start in PlayableCharacter");
    }
}
