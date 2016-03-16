using UnityEngine;
using System.Collections;

public class SnailLead : MonoBehaviour {

    private SnailAI snail;

    void Start ()
	{
        snail = GetComponentInParent<SnailAI>();
	}

   
}
