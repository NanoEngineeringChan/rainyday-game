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

    private void FixedUpdate()
    {
        CometEffects();

        if (Input.GetKeyDown(KeyCode.F))
        {
            CometPunch();
        }
    }
    private void CometEffects()
    {
        _floatingBehavior.Float(_floatStr);
        transform.Rotate(Vector3.forward);
    }

    private void CometPunch()
    {
        Debug.Log("PUNCHING!");

        Vector3 currPos   = transform.position;
        Vector3 targetPos = new Vector3(transform.position.x + 15f, transform.position.y, transform.position.z);

        transform.position = Vector3.Lerp(currPos, targetPos, Time.deltaTime * 7.0f);
    }
}
