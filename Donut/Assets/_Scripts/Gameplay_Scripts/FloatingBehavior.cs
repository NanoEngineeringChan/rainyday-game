using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingBehavior : MonoBehaviour
{
    private Vector2 _floatY;
    private float _originalY;

    public Transform _parentTransform;

    public float _offset;

	void Start ()
    {
        _originalY = this.transform.position.y;
	}

    public void Float(float floatStrength)
    {
        if (null != _parentTransform)
        {
            this.transform.position = new Vector3(_parentTransform.position.x + _offset,
                _originalY + Mathf.Sin(Time.time) * floatStrength, 5f);
        }
        else
        {
            this.transform.position = new Vector3(transform.position.x + _offset,
                _originalY + Mathf.Sin(Time.time) * floatStrength, 5f);
        }
    }
}
