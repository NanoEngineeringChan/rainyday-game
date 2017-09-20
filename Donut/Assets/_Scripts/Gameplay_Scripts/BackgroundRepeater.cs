using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeater : MonoBehaviour
 {
    [SerializeField]
    private float m_scrollSpeed;

    private SpriteRenderer renderer;

	void Start ()
	{
        m_scrollSpeed = 1.0f;

        renderer = GetComponent<SpriteRenderer>();
	}
	
	void Update ()
	{
        Vector2 offset = new Vector2( (Time.time * m_scrollSpeed), 0);

        renderer.material.mainTextureOffset = offset;
	}
}
