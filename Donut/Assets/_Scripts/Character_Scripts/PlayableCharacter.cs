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
    public void Awake()
    {
    }

    public void Start()
    {
        Debug.Log("Calling Start in PlayableCharacter");
    }

    protected override void Initialize()
    {
        base.Initialize();
    }
}
