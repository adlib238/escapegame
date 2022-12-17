using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObj : TapCollider
{
	[SerializeField] Slot[] slots;
	[SerializeField] Item.Type itemType;
	Item item;

	void Update()
    {
        if (EnableCameraPositionName == CameraManager.Instance.CurrentPositionName)
			GetComponent<BoxCollider>().enabled = true;
        else    
			GetComponent<BoxCollider>().enabled = false;
	}

	private void Start()
    {
		// itemTypeに応じてitemを生成
		item = ItemGenerater.instance.Spawn(itemType);
	}

	public void OnclickObj()
    {
		if (ItemBox.instance.ItemOver())
			return;
		ItemBox.instance.SetItem(item);
		gameObject.SetActive(false);
	}
}
