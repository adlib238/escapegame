using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    public string MovePositionName;

	public Vector3 MovePosition;
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

		if (MovePositionName == CameraManager.Instance.CurrentPositionName)
            origin.localPosition = MovePosition;
        else
			origin.position = _InitPos;
	}
}
