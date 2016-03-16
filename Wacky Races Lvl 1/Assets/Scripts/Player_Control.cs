using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

// Add these components if they don't exist
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]


public class Player_Control : MonoBehaviour {

    Rigidbody2D rb;
    Animator anim;
    AudioSource audiosource;
   
    public AudioClip sfxJump;   // alternate method from sfxShoot in SoundManager
    public AudioClip sfxDead;
    public AudioClip sfxGameOver;

    public float moveSpeed = 150f;
	public float jumpStrength = 33f;
    public float maxSpeed = 5f;

    int _lives = 3;
    int _score = 0;

    // anim bools
    public bool grounded;
    public bool isFacingRight;
    private bool crouch;
    private bool gotHitBool = false;
    bool gameOverBool = false;
    bool paused = false;

    // HUD
    Text scoreUI;       
    Text livesUI;


    public GameObject Checkpoint1;
    public Canvas canvasPause;


    void Start () 
	{
		rb = GetComponent<Rigidbody2D> ();
        anim = GetComponentInChildren<Animator>();

        scoreUI = GameObject.Find("Text_ScoreHud").GetComponentInChildren<Text>();
        scoreUI.text = "Score: " + score;

        canvasPause = GameObject.Find("Canvas_Paused").GetComponentInChildren<Canvas>();
        canvasPause.enabled = false;

        livesUI = GameObject.Find("Text_LivesHud").GetComponentInChildren<Text>();
        livesUI.text = "Lives: " + lives;

        Checkpoint1 = GameObject.Find("Checkpoint1");

        

        /// sound safety
        if (!audiosource)
        {
            audiosource = gameObject.AddComponent<AudioSource>();
        }

        rb.gravityScale = 10;

	}//start end


	void Update () 
	{
        anim.SetFloat("Speed", rb.velocity.x);
        anim.SetBool("Grounded", grounded);
        anim.SetBool("Reverse", isFacingRight);
        anim.SetBool("Low", crouch);

        // pause
        if (Input.GetKeyDown("p"))
        {
            if (!paused)
            {
                Time.timeScale = 0.0f;
                paused = true;
                canvasPause.enabled = true;
            }
            else
            {
                Time.timeScale = 1;
                paused = false;
                canvasPause.enabled = false;
            }
        }

        // jump
        if (Input.GetButtonDown("Jump") && grounded)
        {
			Debug.Log("jump");
			rb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);

            // play jump sound
            audiosource.clip = sfxJump;
            audiosource.Play();
        }


        // crouch
        if (Input.GetButton("Crouch"))
        {
            crouch = true;
            rb.gravityScale = 1;
        }
        if (Input.GetButtonUp("Crouch"))
        {
            rb.gravityScale = 10;
            crouch = false;
        }

        

    } // Update end



    void FixedUpdate()
    {
        // Movement
        float moveValue = Input.GetAxisRaw("Horizontal");
        
        if (!crouch)
        {
            rb.AddForce((Vector2.right * moveSpeed) * moveValue);
        }

        // speed ceiling
        if (rb.velocity.x > maxSpeed)
        {
            rb.velocity = new Vector2(maxSpeed, rb.velocity.y);
        }

        if (rb.velocity.x < -maxSpeed)
        {
            rb.velocity = new Vector2(-maxSpeed, rb.velocity.y);
        }


        // Check direction of character and flip if needed
        if (moveValue > 0 && isFacingRight)
            flip();
        else if (moveValue < 0 && !isFacingRight)
            flip();


    } // FixedUpdate end



    // game over?
    void GameOver()
    {
        if (lives < 1)
        {
            SceneManager.LoadScene("Game_Over");
        }
    }

    // COLLISION HANDLER
    void OnCollisionEnter2D(Collision2D c)
    {
        // good touch
        if ( (c.gameObject.tag == "Collectable") || (c.gameObject.tag == "Gem") )
        {
            score += 1;
            Destroy(c.gameObject);
        }

        // bad touch
        else if (c.gameObject.tag == "EnemyProjectile")
        {
            Destroy(c.gameObject);
            lives -= 1;
            gameObject.transform.position = Checkpoint1.transform.position;

            audiosource.clip = sfxDead;
            audiosource.Play();
            GameOver();
        }
            
    }

    // lives and score
    public int lives
    {
        get
        {
            return _lives;
        }

        set
        {
            _lives = value;
            livesUI.text = "Lives: " + lives;
        }
    }

    public int score
    {
        get
        {
            return _score;
        }

        set
        {
            _score = value;
            scoreUI.text = "Score: " + score;
            Debug.Log(score);
        }
    }

    // 2D turning
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

}// Player_Control end