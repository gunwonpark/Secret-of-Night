using System;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public virtual void Initialize()
    {

    }

    public static void BindEvent(GameObject go, Action action, UIEvent type = UIEvent.Click)
    {
        UIEventHandler evt = Utility.GetOrAddComponent<UIEventHandler>(go);

        switch (type)
        {
            case UIEvent.Click:
                evt.OnClickHandler -= action;
                evt.OnClickHandler += action;
                break;
        }
    }
}
