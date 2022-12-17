using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
	[SerializeField] GameObject nowUI = default;
	[SerializeField] GameObject backUI = default;
	[SerializeField] GameObject nextUI = default;

    public void ChangeUI()
    {
		nowUI.SetActive(false);
		nextUI.SetActive(true);
        if (nextUI.name == "Title")
		    SceneManager.LoadScene(0);
	}

    public void BackUI()
    {
		nowUI.SetActive(false);
		backUI.SetActive(true);
	}
}
