using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseKey : TapCollider
{
	[SerializeField] GameObject key = default;
	[SerializeField] GameObject door = default;
	[SerializeField] GameObject openDoor = default;
	[SerializeField] GameObject clear = default;
	[SerializeField] GameObject gameUI = default;
	public string SlidePositionName;
	public GameObject SlideCollider;


	void Update()
    {
        if (EnableCameraPositionName == CameraManager.Instance.CurrentPositionName)
			GetComponent<BoxCollider>().enabled = true;
        else    
			GetComponent<BoxCollider>().enabled = false;
	}

    public void UnlockKey()
    {
		int no = CheckKeyType();
        
        if (no == 0)
        {
            if (ItemBox.instance.CheckSelectItem(Item.Type.key))
            {
                ItemBox.instance.UseSelectItem();
                Invoke(nameof(CameraMove), 0.5f);
            }
        }
        else if (no == 1)
        {
            if (ItemBox.instance.CheckSelectItem(Item.Type.DoorKey))
            {
                ItemBox.instance.UseSelectItem();
                Invoke(nameof(OpenDoor), 0.5f);
                Invoke(nameof(Clear), 1.5f);
            }
        }
    }

    private void CameraMove()
    {
		CameraManager.Instance.ChangeCameraPosition(SlidePositionName);
		SlideCollider.SetActive(true);
	}

    private void OpenDoor()
    {
		door.SetActive(false);
		openDoor.SetActive(true);
	}

    private void Clear()
    {
		gameUI.SetActive(false);
		clear.SetActive(true);
    }

    private int CheckKeyType()
    {
        if (key.name == "Key")
			return 0;
        else if (key.name == "DoorKey")
			return 1;
		return -1;
    }
}
