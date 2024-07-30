using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBackground : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        BackGroundMover();
    }

    private void BackGroundMover()
    {
        if (transform.position.y >= -10)
        {
            transform.Translate(Vector2.down * 2.5f * Time.deltaTime);
        }
        else if (transform.position.y <= -10)
        {
            transform.position = new Vector2(transform.position.x, 10);
        }
    }
}
