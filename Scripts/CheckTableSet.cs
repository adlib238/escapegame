using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTableSet : MonoBehaviour
{
	[SerializeField] GameObject doorKey = default;
	[SerializeField] GameObject wineGlass = default;
	[SerializeField] GameObject plate = default;
	public bool fin;

	void Start()
    {
		fin = false;
		doorKey.SetActive(false);
	}

    void Update()
    {
		if (wineGlass.activeSelf == false)
			return;
        if (plate.activeSelf == false)
			return;
        if (!fin)
        {
		    doorKey.SetActive(true);
			fin = true;
		}
	} 
}
