using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    private List<UIBase> _popup = new List<UIBase>();
    public T ShowPopupUI<T>(string name = null, Transform parent = null) where T : UIBase
    {
        if (string.IsNullOrEmpty(name))
            name = typeof(T).Name;

        GameObject prefab = Resources.Load<GameObject>($"Prefabs/UI/{name}");

        GameObject go = Instantiate(prefab);

        T popup = Utility.GetOrAddComponent<T>(go);

        if (parent != null)
            go.transform.SetParent(parent);

        go.transform.localScale = Vector3.one;
        go.transform.localPosition = prefab.transform.position;

        _popup.Add(popup);

        return popup;
    }
}
