using UnityEngine;
using System.Collections;

public class SnailAI : MonoBehaviour {

    public Rigidbody2D snailrb;
    public Animator snailanim;
 
    public float snailSpeed = 10;
    public float snailMax = 3;
    public float snailJump = 10;

    void Start () {
        snailrb = GetComponent<Rigidbody2D>();
        snailanim = GetComponent<Animator>();
	}

    void Update ()
    {
        // snail movement
        Vector2 motion = new Vector2(-1, 0);
        snailrb.AddForce(motion * snailSpeed);

        // snail speed ceiling
        if (snailrb.velocity.x > snailMax)
            snailrb.velocity = new Vector2(snailMax, snailrb.velocity.y);
    }

    void FixedUpdate()
    {
        // Snail Jump
        if (snailrb.velocity.x == 0)
            snailrb.AddForce(Vector2.up * snailJump, ForceMode2D.Impulse);

    }

    
}
