using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTag : TapCollider
{
	[SerializeField] GameObject bfTag = default;
	[SerializeField] GameObject candle = default;
	[SerializeField] GameObject afTag = default;

    public void Burn()
    {
        if (checkTag())
        {
            if (ItemBox.instance.CheckSelectItem(Item.Type.Tag))
            {
                ItemBox.instance.UseSelectItem();
    			afTag.SetActive(true);
            }
		}
    }

    private bool checkTag()
    {
        if (bfTag.activeSelf == false && candle.activeSelf == false)
			return true;
		return false;
	}
}
