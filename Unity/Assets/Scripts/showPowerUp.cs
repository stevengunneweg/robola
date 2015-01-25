using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class showPowerUp : MonoBehaviour {
    private Text _text;
    private GameType[] types;

    void Awake()
    {
        _text = GetComponent<Text>();
        types = FindObjectsOfType<GameType>();
    }

    void Update()
    {
        foreach (GameType type in types)
        {
            if (type.enabled)
            {
                _text.text = type.TypeName;
                break;
            }
        }
    }
}
