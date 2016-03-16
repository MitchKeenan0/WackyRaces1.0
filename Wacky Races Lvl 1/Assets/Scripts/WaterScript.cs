using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WaterScript : MonoBehaviour {

    void Start () { }

	// touching water resets the scene
	void OnTriggerEnter2D(Collider2D col)
    {
        SceneManager.LoadScene(0);
    }
}
