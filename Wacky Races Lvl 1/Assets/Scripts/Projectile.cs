using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

    // Length of time projectile exists
    public float lifeTime;
    public float speed;
    public bool isFacingRight;
    

	// Use this for initialization
	void Start () {
	
        // Check that lifeTime is not 0 or a negative value
        if(lifeTime <= 0)
        {
            // Sets a default time if one is not entered
            lifeTime = 1.0f;
        }

        // Destroy projectile GameObject if it doesnt collide with anything
        Destroy(gameObject, lifeTime);

        // Make projectile move when instantiated
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed,0.0f);

        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Flip Bullet
        if (isFacingRight)
            flip();
	}

    void flip()
    {
        // Method 1: shorthand for method2
        isFacingRight = !isFacingRight;

        // Make a copy of Character's local scale
        Vector3 scaleFactor = transform.localScale;

        // Flip the character
        scaleFactor.x *= -1;    // this changes scale to (-1,1,1) which flips our character

        // Update scale of character
        transform.localScale = scaleFactor;
    }
}
