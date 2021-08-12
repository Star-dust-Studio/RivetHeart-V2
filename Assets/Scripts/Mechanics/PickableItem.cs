using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour
{
    public ItemPickupSO itemSO;

    public void Execute()
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = itemSO.sprite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickup pickup = collision.gameObject.GetComponent<IPickup>();

        if (pickup != null)
        {
            pickup.PickUpItem(itemSO);
            Destroy(this.gameObject);
        }
    }
}
