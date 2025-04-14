using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util
{
   public static T GetOrAddComponent<T>(this GameObject obj) where T : Component
    {
        T com = obj.GetComponent<T>();
        if(com == null)
            com= obj.AddComponent<T>();

        return com;
    }
    public static LayerBullet AddLayer(this GameObject obj, float time)
    {
        LayerBullet layer = obj.AddComponent<LayerBullet>();
        layer.StartInit(time);
        return layer;
    }
}
