using UnityEngine;
using System.Collections;

public class Presistant : MonoBehaviour {

    public static Presistant persistant;
    public GameType Picked;

    void Awake()
    {
        if (persistant == null)
        {
            DontDestroyOnLoad(gameObject);
            persistant = this;
        }
    }

    public void DisablePicked()
    {
        Picked.enabled = false;
    }
}
