using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_backGrounds;

    // How much we want each background to move
    [SerializeField]
    private float[] m_parallaxAmounts;

    [SerializeField]
    private float m_smoothingAmount;


    private Transform m_camera;
    private Vector3 m_prevCameraPos;

    public void Awake()
    {
        m_camera = Camera.main.transform;
    }

    public void Start()
    {
        m_prevCameraPos = m_camera.position;

        // Set the size of the parallax array
        m_parallaxAmounts = new float[m_backGrounds.Length];

        for (int i = 0; i < m_parallaxAmounts.Length; i++)
        {
            m_parallaxAmounts[i] = m_backGrounds[i].position.z * -1;
        }

        m_smoothingAmount = 2.5f;
    }

    public void Update()
    {
        for (int i = 0; i < m_backGrounds.Length; i++)
        {
            float parallax = (m_prevCameraPos.x - transform.position.x) *
                               (m_parallaxAmounts[i] / m_smoothingAmount);

            float backgroundTargetPosX = m_backGrounds[i].position.x + parallax;
//            float backgroundTargetPosY = m_backGrounds[i].position.y + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, m_backGrounds[i].position.y, m_backGrounds[i].position.z);

            m_backGrounds[i].position = Vector3.Lerp(m_backGrounds[i].position, backgroundTargetPos, (m_smoothingAmount * Time.deltaTime));
        }

        m_prevCameraPos = m_camera.position;
    }
}