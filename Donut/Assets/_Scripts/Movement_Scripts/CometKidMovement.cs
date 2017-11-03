using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometKidMovement : PlayerMovement
{
    private FloatingBehavior _floatingBehavior;

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();

        _floatingBehavior = GetComponent<FloatingBehavior>();
    }

    public override void Update()
    {
        base.Update();

        if (GetComponent<CometKid>().CharacterAnim.GetCurrentAnimatorStateInfo(0).IsName("CometKidIdle"))
        {
            //_floatingBehavior.Float(.3f);
        }
    }

    protected override void Move()
    {
        base.Move();
    }
}
