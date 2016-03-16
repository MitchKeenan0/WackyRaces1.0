using UnityEngine;
using System.Collections;

public class Character_Projectile : MonoBehaviour {

    // Used to spawn projectile at a location
    public Transform projectileSpawnPoint;

    // Used to create projectile prefab
    public Projectile projectile;

    // sound for projectile fire
    public AudioClip sfxShoot;

	// Use this for initialization
	void Start () {

        // Check if Transform is attached to GameObject
        if (!projectileSpawnPoint)
        {
            Debug.LogError("No projectileSpawnPoint attached, please attach a projectileSpawnPoint in Inspector.");
        }

        // Check if Projectile is attached to GameObject
        if (!projectile)
        {
            Debug.LogError("No Projectile attached, please attach a Projectile in Inspector.");
        }
	}

	// Update is called once per frame
	void Update () {

        // Check if Fire1 button was pressed
        if (Input.GetButtonDown("Fire1"))
        {
            // Call/Invoke function to fire a projectile
            fireProjectile();
        }
	} // Closes Update()


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

        if (GetComponent<Player_Control>().isFacingRight)
            temp.isFacingRight = false;
        else temp.isFacingRight = true;

        // Assign a speed for Projectile object
        if (GetComponent<Player_Control>().isFacingRight)
            temp.speed = -5.0f;
        else
            temp.speed = 5.0f;

        // Make projectile not hit Character
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(),
            temp.GetComponent<Collider2D>());

        SoundManager.instance.PlaySFX(sfxShoot);

    } // Closes fireProjectile()



} // Closes class
// Nothing gets added below this point
