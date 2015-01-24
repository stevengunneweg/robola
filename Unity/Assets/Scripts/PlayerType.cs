using UnityEngine;
using System.Collections;

public class PlayerType : MonoBehaviour {
    private Light _light;
    private Rigidbody _PlayerRigidbody;
    private PowerUps _powerUps;

    public Player player { get; private set; }
    public float infectedSpeed, uninfectedSpeed, cooldown, duration;
    public KeyCode actionButton;
    public bool infected;

    void Awake()
    {
        player = this.gameObject.GetComponent<Player>();
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
            player.speed = infectedSpeed;
            _light.color = Color.green;
        }else {
            player.speed = uninfectedSpeed;
            _light.color = Color.white;
        }
        #endregion

        //aftel gedeelte voor cooldown
        if (cooldown > 0)
        {
            cooldown -= 1 * Time.deltaTime;
        }

        //aftel gedeelte voor duration
        if (duration > 0)
        {
            duration -= 1 * Time.deltaTime;
        }
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
}
