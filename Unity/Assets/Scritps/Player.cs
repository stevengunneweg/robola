using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    private int _floorMask;
    private float _h, _v;
    private Vector3 _movement, _input;
    private Rigidbody _playerRigidbody;
    private Quaternion _playerRotation;

    public float speed, rotationSpeed;

    void Awake()
    {
        _floorMask = LayerMask.GetMask("Floor");
        _playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        _h = Input.GetAxisRaw("Horizontal");
        _v = Input.GetAxisRaw("Vertical");

        Move(_h, _v);

        if (_input != Vector3.zero)
        {
            _playerRotation = Quaternion.LookRotation(_input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, _playerRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        _movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        _movement = _movement.normalized * speed * Time.deltaTime;
        //_movement = _input * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        _playerRigidbody.MovePosition(transform.position + _movement);

        //_playerRigidbody.AddForce(_input + _movement);

    }
}
