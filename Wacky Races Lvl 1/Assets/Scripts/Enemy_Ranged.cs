using UnityEngine;
using System.Collections;

public class Enemy_Ranged : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public Projectile projectile;
    public bool isFacingRight;
    public Transform target;

    public float attackRange = 10;
    public float projectileSpeed = 15;

    public float fireTime = 2f;
    public float timeAfterShot = 0f;

    Rigidbody2D rb;

	
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
		//target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

		
	}
	
	

	void Update ()
	{
		if (!target)
		{
			target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
		}

		// aim at player
		if (target.position.x < rb.position.x && isFacingRight)
            flip();
        else if (target.position.x > rb.position.x && !isFacingRight)
            flip();


        // fire cannon
        float distance = Vector3.Distance(rb.transform.position, target.transform.position);
        //Debug.Log("Player distance to Tank: " + distance);

        if (distance < attackRange)
        {
            if (Time.time > timeAfterShot + fireTime)
            {
                fireProjectile();

                timeAfterShot = Time.time;
            }
        }

	}

    // Function to fire a projectile
    void fireProjectile()
    {
        // Create a prefab at a location specified by the variable 
        // projectileSpawnPoint
        // - Needs prefab to fire (projectile)
        // - Needs location to fire from (projectileSpawnPoint.position)
        // - Needs rotation for projectile (projectileSpawnPoint.rotation)
        Projectile temp = Instantiate(projectile, projectileSpawnPoint.position,
            projectileSpawnPoint.rotation) as Projectile;

        if (isFacingRight)
            temp.isFacingRight = true;
        else temp.isFacingRight = false;

        // Assign a speed for Projectile object
        if (isFacingRight)
        {
            temp.speed = projectileSpeed;
        }
            
        else
        {
            temp.speed = -projectileSpeed;
        }
            

        // Make projectile not hit Character
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(),
            temp.GetComponent<Collider2D>());

    } // Closes fireProjectile()


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
