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
    // F 대화, G 상호작용, tap inven, q, e 퀵슬롯, x 설정창
}
