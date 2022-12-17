using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
	[SerializeField] GameObject GlassFrame = default;
	public GameObject[] paperState;
    private GameObject delPaper;
    private GameObject actPaper;
	private int state = 0;

	public void ChangePaper()
	{
		state = CheckState();
		if (state == -1 || state == 2)
			return;
		if (state == 0)
        {
            if (ItemBox.instance.CheckSelectItem(Item.Type.GlassFrame))
            {
                ItemBox.instance.UseSelectItem();
                delPaper.SetActive(false);
                actPaper.SetActive(true);
                GlassFrame.SetActive(true);
            }
        }
        else if (state == 1)
        {
            if (ItemBox.instance.CheckSelectItem(Item.Type.RedPen))
            {
                ItemBox.instance.UseSelectItem();
                delPaper.SetActive(false);
                actPaper.SetActive(true);
            }
        }
	}

    private int CheckState()
    {
		int i = 0;
		foreach(var obj in paperState)
        {
            if (i == 2)
				return i;
			if (obj.activeSelf == true)
            {
				delPaper = paperState[i];
				actPaper = paperState[i + 1];
				return i;
			}
			i++;
		}
		return -1;
	}
}
