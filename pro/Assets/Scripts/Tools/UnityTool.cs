using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityTool  {

    public static GameObject FindChild(GameObject parent, string childName)
    {
        Transform[] childrens = parent.GetComponents<Transform>();
        bool isFinded = false;
        Transform child = null;
        foreach (Transform t in childrens)
        {
            if (t.name.Equals(childName))
            {
                if (isFinded)
                {
                    Debug.LogWarning("you want to find child is not the only");
                }
                isFinded = true;
                child = t;
            }
        }
        return child.gameObject;
    }

    public static void Attach(GameObject parent, GameObject child)
    {
        child.transform.parent = parent.transform;
        child.transform.localPosition = Vector3.zero;
        child.transform.localScale = Vector3.one;
        child.transform.localRotation = Quaternion.identity;
    }
}
