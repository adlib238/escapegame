using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candle : TapCollider
{
	public GameObject[] candles;
	public GameObject[] afterCandles;

	void Update()
	{
		if (EnableCameraPositionName == CameraManager.Instance.CurrentPositionName)
			GetComponent<BoxCollider>().enabled = true;
		else
			GetComponent<BoxCollider>().enabled = false;
	}

	public void useCandle()
	{
		if (ItemBox.instance.CheckSelectItem(Item.Type.Match))
		{
			ItemBox.instance.UseSelectItem();
			foreach (var obj in candles)
				obj.SetActive(false);

			foreach (var obj in afterCandles)
				obj.SetActive(true);
		}
	}
}
