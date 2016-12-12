using UnityEngine;
using System.Collections;

public class LevelTransition : MonoBehaviour {

	public void TransitionToScene (string sceneName)
	{
		Application.LoadLevel(sceneName);
	}
}
