using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VolumeController : MonoBehaviour 
{
	public List<VolumeReset> volumes;

	public void sendTransform(Transform pos)
	{
		foreach(VolumeReset volume in volumes)
		{
			if(volume.GetComponent<MeshRenderer>().bounds.Contains(pos.position))
			{
				volume.objectsInVolume.Add(pos.gameObject);
				Debug.Log(pos.position);
			}
		}
	}
}
