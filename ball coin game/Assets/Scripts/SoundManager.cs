using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public AudioSource coinssource;
    public AudioClip coinSound;
    private void awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coinssource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
