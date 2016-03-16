using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {

    public int spawnPoint = 0;

	// Use this for initialization
	void Start ()
	{
        // spawn player at specified spawn location
        // - works because instance is static
        GameManager.instance.SpawnPlayer(spawnPoint);
	}

}
