using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemsobjects : MonoBehaviour
{
    [System.Serializable]
    public struct GameItems
    {
        public GameObject item;
    }

    
    public GameItems[] gameItems;
}
