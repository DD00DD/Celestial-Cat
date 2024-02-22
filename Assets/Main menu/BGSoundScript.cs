using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGSoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private static BGSoundScript _instance = null;
    public static BGSoundScript Instance
    {
        get { return _instance; }
    }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;

        DontDestroyOnLoad(gameObject);
    }
}