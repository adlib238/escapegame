using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideLowBox : MonoBehaviour
{
    public string SlidePositionName;

	public Vector3 SlidePosition;
	private Vector3 _InitPos;

	// Start is called before the first frame update
	void Start()
    {
		_InitPos = this.transform.position;
	}

    // Update is called once per frame
    void Update()
    {
		Transform origin = this.transform;

		if (SlidePositionName == CameraManager.Instance.CurrentPositionName)
            origin.localPosition = SlidePosition;
        else
			origin.position = _InitPos;
	}
}
