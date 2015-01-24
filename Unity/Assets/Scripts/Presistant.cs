using UnityEngine;
using System.Collections;

public class Presistant : MonoBehaviour {

    public static Presistant persistant;

    void Awake()
    {
        if (persistant == null)
        {
            DontDestroyOnLoad(gameObject);
            persistant = this;
        }
        else if (persistant != this)
        {
            Destroy(gameObject);
        }
    }
}
