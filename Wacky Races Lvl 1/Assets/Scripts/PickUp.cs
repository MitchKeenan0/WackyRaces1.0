using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    
	void Start () { }
	
	void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
    }
}
