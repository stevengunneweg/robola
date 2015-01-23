using UnityEngine;
using System.Collections;

public class PlayerType : MonoBehaviour {
    private Player _player;
    private Light _light;

    public bool infected;

    void Awake()
    {
        _player = this.gameObject.GetComponent<Player>();
        _light = this.transform.FindChild("Point light").GetComponent<Light>();
    }

    void Update()
    { 
        if (infected)
        {
            _player.speed = 5.75f;
            _light.color = Color.green;
        }else {
            _player.speed = 5f;
            _light.color = Color.white;
        }
    }
}
