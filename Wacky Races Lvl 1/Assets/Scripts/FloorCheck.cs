using UnityEngine;
using System.Collections;

public class FloorCheck : MonoBehaviour {

    private Player_Control player;

	void Start ()
    {
        player = GetComponentInParent<Player_Control>();
	}
	
	void OnTriggerEnter2D (Collider2D col)
    {
	    player.grounded = true;
	}

    void OnTriggerStay2D (Collider2D col)
    {
        player.grounded = true;
    }

    void OnTriggerExit2D (Collider2D col)
    {
        player.grounded = false;
    }
}
