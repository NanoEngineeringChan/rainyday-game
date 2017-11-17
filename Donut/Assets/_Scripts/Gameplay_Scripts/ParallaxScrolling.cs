using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    [SerializeField]
    private Transform[] _backGrounds;

    // How much we want each background to move
    [SerializeField]
    private float[] _parallaxAmounts;

    [SerializeField]
    private float _smoothingAmount;


    private Transform _camera;
    private Vector3 _prevCameraPos;

    public void Awake()
    {
        _camera = Camera.main.transform;
    }

    public void Start()
    {
        _prevCameraPos = _camera.position;

        // Set the size of the parallax array
        _parallaxAmounts = new float[_backGrounds.Length];

        for (int i = 0; i < _parallaxAmounts.Length; i++)
        {
            _parallaxAmounts[i] = _backGrounds[i].position.z * -1;
        }

        _smoothingAmount = 2f;
    }

    public void Update()
    {
        for (int i = 0; i < _backGrounds.Length; i++)
        {
            float parallax = (_prevCameraPos.x - transform.position.x) *
                               (_parallaxAmounts[i] / _smoothingAmount);

            float backgroundTargetPosX = _backGrounds[i].position.x + parallax;
//            float backgroundTargetPosY = _backGrounds[i].position.y + parallax;

            Vector3 backgroundTargetPos = new Vector3(backgroundTargetPosX, _backGrounds[i].position.y,
                                                      _backGrounds[i].position.z);

            _backGrounds[i].position = Vector3.Lerp(_backGrounds[i].position, 
                                                     backgroundTargetPos, (_smoothingAmount * Time.deltaTime));
        }

        _prevCameraPos = _camera.position;
    }
}