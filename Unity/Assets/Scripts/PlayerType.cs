using UnityEngine;
using System.Collections;

public class PlayerType : MonoBehaviour {
    private Player _player;
    private Light _light;

    public float infectedSpeed, uninfectedSpeed;

    public bool infected;

    void Awake()
    {
        _player = this.gameObject.GetComponent<Player>();
        _light = this.transform.FindChild("Point light").GetComponent<Light>();
    }

    void Update()
    {
        #region
        if (infected)
        {
            _player.speed = infectedSpeed;
            _light.color = Color.green;
        }else {
            _player.speed = uninfectedSpeed;
            _light.color = Color.white;
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
}
