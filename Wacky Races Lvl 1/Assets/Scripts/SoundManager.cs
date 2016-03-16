using UnityEngine;
using System.Collections;


/// sounds can also be individualized
/// like for enemies etc.


public class SoundManager : MonoBehaviour {


    public static SoundManager _instance = null;
    public AudioSource sfxsource;
    

	void Start ()
    {
        // init
        sfxsource = GetComponent<AudioSource>();

        // create audio component
        if (!sfxsource)
        {
            sfxsource = gameObject.AddComponent<AudioSource>();
        }

        // limit SoundManagers to 1
        if (instance)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }


    // Sound Effects (from Player)
    public void PlaySFX(AudioClip clip)
    {
        // assign audio clip to play thru source
        sfxsource.clip = clip;

        // play sound
        sfxsource.Play();
    }
	


    // instance tracker for SoundManager
    public static SoundManager instance
    {
        get
        {
            return _instance;
        }

        set // this probably wont be used lmao
        {
            _instance = value;      // assign copy of SoundManager to _instance
        }
    }
}
