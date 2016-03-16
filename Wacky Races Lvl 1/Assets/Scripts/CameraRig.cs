using UnityEngine;
using System.Collections;

public class CameraRig : MonoBehaviour {

    private Vector2 velocity;
    public float smoothX;
    public float CameraHeight = 0f;
	public bool Bounds = true;

    public Vector3 MinimumPosition;
    public Vector3 MaximumPosition;

    public GameObject player;


	void Start ()
    {
		player = GameObject.Find("Character");
	}


    void FixedUpdate ()
    {
		if (!player)
		{
			player = GameObject.FindGameObjectWithTag("Player");
		}

		float posX = Mathf.SmoothDamp(
		transform.position.x,
		player.transform.position.x,
		ref velocity.x, smoothX);

		transform.position = new Vector3(posX, CameraHeight, transform.position.z);

		// screen-bounding
		if (Bounds)
		{
			transform.position = new Vector3(
				Mathf.Clamp(transform.position.x, MinimumPosition.x, MaximumPosition.x),
				Mathf.Clamp(transform.position.y, MinimumPosition.y, MaximumPosition.y),
				Mathf.Clamp(transform.position.z, MinimumPosition.z, MaximumPosition.z));
		}
	}

}