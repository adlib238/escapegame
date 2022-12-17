using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paint : MonoBehaviour
{
	[SerializeField] GameObject paint = default;

    public void showPaint()
    {
		int no = checkPaintType();

        if (no == 0)
        {
            if (ItemBox.instance.CheckSelectItem(Item.Type.PaintS))
            {
                ItemBox.instance.UseSelectItem();
                paint.SetActive(true);
            }
        }
        else if (no == 1)
        {
            if (ItemBox.instance.CheckSelectItem(Item.Type.PaintM))
            {
                ItemBox.instance.UseSelectItem();
                paint.SetActive(true);
            }
        }
	}
    
    private int checkPaintType()
    {
        if (paint.name == "Paint_06")
			return 0;
        else if (paint.name == "Paint_04")
			return 1;
		return -1;
	}
}
