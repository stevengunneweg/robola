using UnityEngine;
using System.Collections;

public class PlayerType : MonoBehaviour {
    private Light _light;
    private Rigidbody _PlayerRigidbody;
    private float standardUninfectedSpeed, standardInfectedSpeed;
    private ParticleSystem _partSyst;
    private TrailRenderer trail;

    public Player player { get; private set; }
    public float infectedSpeed, uninfectedSpeed, cooldown, duration;
    public KeyCode actionButton;
    public bool infected;
    public Color PlayerColor;

    void Awake()
    {
        standardInfectedSpeed = infectedSpeed;
        standardUninfectedSpeed = uninfectedSpeed;
        player = this.gameObject.GetComponent<Player>();
        _light = this.transform.FindChild("Point light").GetComponent<Light>();
        _PlayerRigidbody = this.gameObject.GetComponent<Rigidbody>();

        if (Application.loadedLevelName.Contains("Game_Scene")) {
            _partSyst = GetComponent<ParticleSystem>();
            trail = GetComponent<TrailRenderer>();
        }
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
           if (Random.value > 0.97)
            {
                if (_light.enabled)
                {
                    _light.enabled = false;
                }
                else
                {
                    _light.enabled = true;
                }
            }
            if (_partSyst != null)
            {
                _partSyst.startSize = 2f;
                _partSyst.startColor = Color.black;
                _partSyst.startLifetime = .5f;
                _partSyst.Emit(2);

            }
        }else {
            player.speed = uninfectedSpeed;
            _light.color = PlayerColor;
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
        else
        {
            uninfectedSpeed = standardUninfectedSpeed;
            infectedSpeed = standardInfectedSpeed;
            if (Application.loadedLevelName.Contains("Game_Scene"))
            {
                trail.enabled = false;
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            CollisionPlayer(col);
            
        }
    }

	void PlaySound(string file){
		AudioClip clip = Resources.Load(file) as AudioClip;
		audio.PlayOneShot(clip);
	}

    void CollisionPlayer(Collision col)
    {
        if (this.infected)
        {
            col.gameObject.GetComponent<PlayerType>().infected = this.infected;
            if (_partSyst != null)
            {
                _partSyst.startSize = 1f;
                _partSyst.startColor = Color.green;
                _partSyst.Emit(20);
            }
			PlaySound("Sounds/takeover sfx");
		} else{			
            if (_partSyst != null)
            {
                _partSyst.startSize = 3f;
                _partSyst.startColor = PlayerColor;
                _partSyst.Emit(20);
            }
            PlaySound("Sounds/hit sfx");
		}
	}
}
