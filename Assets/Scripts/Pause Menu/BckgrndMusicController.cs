using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BckgrndMusicController : MonoBehaviour
{
    public GameObject backgroundMusic;
    public float backgroundMusicMax = 0.2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void musicVolume(float val)
    {
        backgroundMusic.GetComponent<AudioSource>().volume = backgroundMusicMax * val;
    }
}