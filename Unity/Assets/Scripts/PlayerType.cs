using UnityEngine;
using System.Collections;

public class PlayerType : MonoBehaviour {
    private Player _player;
    private Light _light;
    private Rigidbody _PlayerRigidbody;
    private PowerUps _powerUps;


    public float infectedSpeed, uninfectedSpeed;
    public KeyCode actionButton;
    public bool infected;

    void Awake()
    {
        _player = this.gameObject.GetComponent<Player>();
        _light = this.transform.FindChild("Point light").GetComponent<Light>();
        _PlayerRigidbody = this.gameObject.GetComponent<Rigidbody>();
        _powerUps = GameObject.Find("GameManager").GetComponent<PowerUps>();
    }

    void Update()
    {
        #region
        /// <summary>
        /// Speed and Light differance between non-infected and infected
        /// </summary>
        if (infected)
        {
            _player.speed = infectedSpeed;
            _light.color = Color.green;
        }else {
            _player.speed = uninfectedSpeed;
            _light.color = Color.white;
        }
        #endregion
        #region
        if (!infected)
        {
            if (Input.GetKeyDown(actionButton))
            {
                Debug.Log("test");
                UsePowerUp();
            }
        }
        #endregion
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            CollisionPlayer(col);
        }
    }

    void CollisionPlayer(Collision col)
    {
        if (this.infected)
        {
            col.gameObject.GetComponent<PlayerType>().infected = this.infected;
        }
    }

    void UsePowerUp()
    {
        _powerUps.TileDrop(_PlayerRigidbody);
        //_powerUps.Blink(_PlayerRigidbody, _player.input);
    }
}
