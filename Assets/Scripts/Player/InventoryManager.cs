using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public List<Sprite> itemSpriteList;
    public GameObject core;
    public Image[] itemArray;
    public Sprite defaultSlotSprite;
    public TextMeshProUGUI keyNumberText;
    private int keyNumber = 0;
    public ItemPickupSO keySO;

    // Start is called before the first frame update
    void Start()
    {
        keyNumberText.text = "X " + keyNumber.ToString();
        UpdateInventory();
    }

    [ContextMenu("Update inventory")]
    public void UpdateInventory()
    {
        if (itemSpriteList.Count == 0)
        {
            for (int i = 0; i < itemArray.Length; i++)
            {
                itemArray[i].sprite = defaultSlotSprite;
            }
        }
        else
        {
            for (int i = 0; i < itemArray.Length; i++)
            {
                if (i < itemSpriteList.Count)
                {
                    itemArray[i].sprite = itemSpriteList[i];
                    Debug.Log("update item");
                }
                else
                {
                    itemArray[i].sprite = defaultSlotSprite;
                }
            }
        }
    }

    public void AddNewItem(ItemPickupSO newSO)
    {
        if (newSO == keySO)
        {
            keyNumber++;
            keyNumberText.text = "X " + keyNumber.ToString();
        }
        else
        {
            if (itemSpriteList.Count < itemArray.Length)
            {
                itemSpriteList.Add(newSO.sprite);
                Debug.Log(itemSpriteList.Count);
                UpdateInventory();
            }
            else
            {
                Debug.Log("inventory full");
            }
        }
    }

    [ContextMenu("Use key")]
    public void RemoveKey()
    {
        if (keyNumber > 0)
        {
            keyNumber--;
            keyNumberText.text = "X " + keyNumber.ToString();
        }
    }
}
