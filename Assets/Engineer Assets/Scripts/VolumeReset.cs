using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//Jonathon Wigley

public class VolumeReset : MonoBehaviour 
{
	public List<GameObject> objectsInVolume;
	public List<Transform> objectTransforms;

	private bool startTimer;
	private float timer;
	[SerializeField]
	private float timeBeforeReset;

	private GameObject player;
	private bool playerInBounds;

	private bool transformsCopied;

	private MeshRenderer mesh;

	void Awake()
	{
		GameObject.FindGameObjectWithTag("GameController").GetComponent<VolumeController>().
			volumes.Add(GetComponent<VolumeReset>());
	}

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		mesh = GetComponent<MeshRenderer>();
	}

	void Update () 
	{
		if(!transformsCopied)
		{
			copyTransforms();
			transformsCopied = true;
		}

		playerInBounds = mesh.bounds.Contains(player.transform.position);

		if(!playerInBounds)
		{
			startTimer = true;
		}else
		{
			startTimer = false;
			timer = 0;
		}

		if(startTimer && timer < timeBeforeReset)
		{
			timer += Time.deltaTime;
		}

		if(startTimer && timer >= timeBeforeReset)
		{
			for(int i = 0; i < objectsInVolume.Count; i++)
			{
				Debug.Log(objectsInVolume[i].transform.position);
				objectsInVolume[i].transform.position = objectTransforms[i].position;
			}

			startTimer = false;
		}

	}

	void copyTransforms()
	{
		foreach(GameObject obj in objectsInVolume)
		{
			objectTransforms.Add(obj.transform);
		}
	}
}
