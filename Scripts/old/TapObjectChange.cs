using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapObjectChange : TapCollider
{
	public int Index { get; private set; }

	public GameObject[] Objects;

	// Start is called before the first frame update
	protected override void OnTap()
    {
		base.OnTap();

		Objects[Index].SetActive(false);

		Index++;
        if (Index >= Objects.Length)
			Index = 0;

		Objects[Index].SetActive(true);
	}	
}
