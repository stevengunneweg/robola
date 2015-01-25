using UnityEngine;
using System.Collections;

public class Presistant : MonoBehaviour {

    void Awake()
    {
            DontDestroyOnLoad(gameObject);
    }

}
