using UnityEngine;
using UnityEngine.SceneManagement;

public class Click : MonoBehaviour
{

    public int sceneIndex;

   Ray ray;
	RaycastHit hit;
	
	void Update()
	{
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if(Physics.Raycast(ray, out hit))
		{
			if(Input.GetMouseButtonDown(0))
				SceneManager.LoadScene(sceneIndex);
		}
	}
}
