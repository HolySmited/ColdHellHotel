using UnityEngine;
using System.Collections;

public class Menu_JW : MonoBehaviour 
{
	public GameObject[] panels = new GameObject[3];

	public void TitleToStory()
	{
		panels[1].SetActive(true);
	}

	public void StoryToControls()
	{
		panels[2].SetActive(true);
	}

	public void ControlsToStartGame()
	{
		Application.LoadLevel(1);
	}
}
