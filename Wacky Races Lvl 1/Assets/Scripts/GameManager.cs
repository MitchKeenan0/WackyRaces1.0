using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    static GameManager _instance = null;    // static means this variable is stored one time only. != const

    public Canvas canvasTitle;
    public Canvas canvasHud;
    
    // used to create player when game starts
    public GameObject playerPrefab;

	public int spawnPoint = 0;
	private bool playerSpawned = false;

	void Start()
	{
		canvasTitle.enabled = true;
		canvasHud.enabled = false;

		if (instance)
		{
			DestroyImmediate(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this);
		}
	}


	void Update ()
    {

		if (Input.GetKeyDown(KeyCode.Return))
        {
            if (SceneManager.GetActiveScene().name == "Scene_Title")
            {
				StartGame();
            }
            
        }

		if (SceneManager.GetActiveScene().name == "World1" && !playerSpawned)
		{
			SpawnPlayer(spawnPoint);
		}


	}//end update

    


    /// Other Functions

    /// UI button
    public void StartGame()
    {
        SceneManager.LoadScene("World1");
        canvasTitle.enabled = false;
        canvasHud.enabled = true;

		
	}


    /// spawn player
    public void SpawnPlayer(int levelLocation)
    {
        string spawnPoint = SceneManager.GetActiveScene().name + "_" + levelLocation;

        Transform spawnPointTransform = GameObject.Find(spawnPoint).GetComponent<Transform>();

        Instantiate(playerPrefab, spawnPointTransform.position, spawnPointTransform.rotation);
		playerSpawned = true;
    }


    /// instance tracker for GameManager
    public static GameManager instance
    {
        get
        {
            return _instance;
        }

        set
        {
            _instance = value;      /// assign copy of GameManager to _instance
        }
    }

}


/*	NOTES

	// for RandomSpawn Lab
	//public GameObject gem;
    //public GameObject wings;

    
    public GameObject[] SpawnPoints;

    public int numberOfCollectables;
    public GameObject[] allCollectables;




	SpawnPoints = GameObject.FindGameObjectsWithTag("Spawner");
       
    for (int i = 0; i < SpawnPoints.Length; i++)
    {
        int select = Mathf.FloorToInt(Random.Range(1.0f, 3.0f));

        if (select < 1.5f)
        {
            Instantiate(wings, SpawnPoints[i].transform.position, Quaternion.identity);
        }

        if (select > 1.5f)
        {
            Instantiate(gem, SpawnPoints[i].transform.position, Quaternion.identity);
        }
    }



	// FindGameObjectsWithTag is for Start() only!
		allCollectables = GameObject.FindGameObjectsWithTag("Collectable");

        numberOfCollectables = (GameObject.FindGameObjectsWithTag("Collectable").Length
            + GameObject.FindGameObjectsWithTag("Gem").Length + GameObject.FindGameObjectsWithTag("Wings").Length);
*/
