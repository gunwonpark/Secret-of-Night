using System;
using UnityEngine;
using UnityEngine.EventSystems;

// 이벤트 핸들러가 필요한 곳들에 붙혀준다
public class UIEventHandler : MonoBehaviour, IPointerClickHandler
{
    public Action OnClickHandler = null;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("OnClick");
        OnClickHandler?.Invoke();
    }
}
