using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Items : MonoBehaviour
{
    protected string itemName;
    public string ItemName
    {
        get { return itemName; }
        set { itemName = value; }
    }
    protected abstract void MoveItem();
}
