using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector2 _velocity;

    [SerializeField]
    private GameObject _player;

    private float _smoothTimeX;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");

        _smoothTimeX = 0.05f;
    }

    private void Update()
    {
        // Have to update the player object regularly so it doesn't break when we switch characters
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void FixedUpdate()
    {
            float posX = Mathf.SmoothDamp(transform.position.x, _player.transform.position.x, ref _velocity.x, _smoothTimeX);

            transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
