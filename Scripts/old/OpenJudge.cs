using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenJudge : MonoBehaviour
{
	private bool _IsOpen = false;

	public TapObjectChange[] TapChanges;
	public int[] AnserIndexes;
	public string SlidePositionName;
	public GameObject SlideCollider;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_IsOpen)
			return;
		for (int i = 0; i < TapChanges.Length; i++)
        {
            if (TapChanges[i].Index != AnserIndexes[i])
				return;
		}
        // ここにきたら正解
		_IsOpen = true;
		foreach(var TapChanges in TapChanges)
        {
			TapChanges.enabled = false;
			TapChanges.gameObject.GetComponent<BoxCollider>().enabled = false;
		}
        // 0.5秒後に実行
		Invoke(nameof(CameraMove), 0.5f);
	}

    private void CameraMove()
    {
		CameraManager.Instance.ChangeCameraPosition(SlidePositionName);
		SlideCollider.SetActive(true);
	}
}
