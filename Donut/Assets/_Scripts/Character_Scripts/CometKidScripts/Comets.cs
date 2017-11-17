using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comets : MonoBehaviour
{ 
    private FloatingBehavior _floatingBehavior;

    public float _floatStr;

    private void Start()
    {
        _floatingBehavior = GetComponent<FloatingBehavior>();
    }

    private void Update()
    {
        CometEffects();
    }
    private void CometEffects()
    {
        _floatingBehavior.Float(_floatStr);
        transform.Rotate(Vector3.forward);
    }
}
