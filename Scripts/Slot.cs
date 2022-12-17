using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
	// 選択パネル
	[SerializeField] GameObject backPanel = default;
	[SerializeField] Image image = default;
	Item item = null;

	private void Start()
	{
		backPanel.SetActive(false);
	}

	/* 
    private void Awake()
    {
		image = GetComponent<Image>();
	}
	 */

    /* プロパティー
    public bool IsEmpty
    {
		get => item == null;
	}
    */

    public bool IsEmpty()
    {
        if (item == null)
			return true;
		return false;
	}

	public void Set(Item item)
    {
		this.item = item;
		image.sprite = item.sprite;
		// UpdateImage(item);
	}

	public void RemoveItem()
	{
		item = null;
		image.sprite = null;
		HideBackPanel();
	}

	public Item GetItem()
	{
		return item;
	}

	// アイテムを受け取ったら画像をスロットに表示
	// void UpdateImage(Item item)
	// {
	// 	image.sprite = item.sprite;
	// }

	public void OnSelect()
	{
		backPanel.SetActive(true);
	}
	public void HideBackPanel()
	{
		backPanel.SetActive(false);
	}
}
