using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    #region
    /// <summary>
    /// all the private variables
    /// </summary>
    private int _floorMask;
    private float _h, _v;
    private Vector3 _movement, _input;
    private Rigidbody _playerRigidbody;
    private Quaternion _playerRotation;
    #endregion

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

        #region
        /// <summary>
        ///  code to make rotate the player towards you look
        /// </summary>
        if (_input != Vector3.zero)
        {
            _playerRotation = Quaternion.LookRotation(_input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, _playerRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        }
        #endregion

        Move(_h, _v);       
    }

    void Move(float h, float v)
    {
        // Set the movement vector based on the axis input.
        _movement.Set(h, 0f, v);

        // Normalise the movement vector and make it proportional to the speed per second.
        _movement = _movement.normalized * speed * Time.deltaTime;

        // Move the player to it's current position plus the movement.
        _playerRigidbody.MovePosition(_playerRigidbody.position + _movement);

       

    }
}
