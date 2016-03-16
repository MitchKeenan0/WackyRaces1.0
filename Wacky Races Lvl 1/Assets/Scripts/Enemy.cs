using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public float speed = 10;
    public float jump = 2;
    public bool isFacingRight;

    Rigidbody2D rb;
    Animator anim;

	void SnowmanRun()
	{
		if (isFacingRight)
			rb.velocity = new Vector2(speed, rb.velocity.y);
		else
			rb.velocity = new Vector2(-speed, rb.velocity.y);
	}

	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }
	
	
	// run
	void Update ()
    {
		SnowmanRun();
    }


	// Jump
    void OnCollisionEnter2D(Collision2D c)
	{

		rb.AddForce(Vector2.up * jump, ForceMode2D.Impulse);

		
	}



	void flip()
    {
        isFacingRight = !isFacingRight;

        // Make a copy of Character's local scale
        Vector3 scaleFactor = transform.localScale;

        // Flip the character
        scaleFactor.x *= -1;    // this changes scale to (-1,1,1) which flips our character

        // Update scale of character
        transform.localScale = scaleFactor;
    }
}



// NOTES 

/*

// When Enemy collides with something
void OnCollisionEnter2D(Collision2D c)
{
	if(c.gameObject.layer != LayerMask.NameToLayer("Player") )
	{
		// Flip Enemy
		flip();

	}
}







*/
