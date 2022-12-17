using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour
{
	[SerializeField] GameObject title = default;
	[SerializeField] GameObject itemBox = default;

    public void StartGame()
    {
		title.SetActive(false);
		itemBox.SetActive(true);
	}
}
