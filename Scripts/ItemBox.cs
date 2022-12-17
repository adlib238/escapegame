using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
	[SerializeField] Slot[] slots;
	// どこでも実行できるやつ
	public static ItemBox instance;
	// 選択スロット
	Slot selectSlot;

	private void Awake()
    {
        if (instance == null)
			instance = this;
	}

	// PickupObjがクリックされたら、スロットにアイテムを入れる
	public void SetItem(Item item)
    {
		foreach(Slot slot in slots)
        {
			if (slot.IsEmpty())
			{
				slot.Set(item);
				break;
			}
		}
	}

	// スロットをクリックした時
	public void OnslotClick(int position)
	{
		// 選択したところにアイテムがなかったら、何もしない
		if (slots[position].IsEmpty())
			return;
		// 一度全て白にする
		for (int i = 0; i < slots.Length; i++)
		{
			// slots[i]の背景をなくす
			slots[i].HideBackPanel();
		}
		// クリックしたスロットの背景を黒にする
		slots[position].OnSelect();
		// 選択アイテムとして、取得する
		selectSlot = slots[position];
	}

	// 選択しているか判定する関数
	public bool CheckSelectItem(Item.Type useItemType)
	{
		if (selectSlot == null)
			return false;
		if (selectSlot.GetItem().type == useItemType)
			return true;
		return false;
	}

	public void UseSelectItem()
	{
		selectSlot.RemoveItem();
		selectSlot = null;
	}

	public bool ItemOver()
	{
		foreach(Slot slot in slots)
		{
			if (slot.IsEmpty())
				return false;
		}
		return true;
	}
}
