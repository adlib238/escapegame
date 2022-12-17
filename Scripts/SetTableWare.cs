using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTableWare : MonoBehaviour
{
    [SerializeField] GameObject tableWare = default;

    public void showTableWare()
    {
		int no = checkTableWareType();

        if (no == 0)
        {
            if (ItemBox.instance.CheckSelectItem(Item.Type.Plate))
            {
                ItemBox.instance.UseSelectItem();
                tableWare.SetActive(true);
            }
        }
        else if (no == 1)
        {
            if (ItemBox.instance.CheckSelectItem(Item.Type.WineGlass))
            {
                ItemBox.instance.UseSelectItem();
                tableWare.SetActive(true);
            }
        }
	}
    
    private int checkTableWareType()
    {
        if (tableWare.name == "plate1")
			return 0;
        else if (tableWare.name == "wine thin glass")
			return 1;
		return -1;
	}
}
