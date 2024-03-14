using TMPro;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField] private float _range;
    private bool _pickupActivated = false;
    private Collider _collider; //충돌체 저장

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private TextMeshProUGUI _pickupText;

    private void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKey(KeyCode.E))
        {
            PickUp();
        }
    }

    // 아이템 레이어마스크 검사
    private void CheckItem()
    {
        // 구의 형태로 충돌체를 찾음, 자신의 위치로부터 range범위만큼 layerMask에 해당하는 충돌체 정보
        Collider[] colliders = Physics.OverlapSphere(transform.position, _range, _layerMask);
        // 충돌체가 하나 이상 있을 때
        if (colliders.Length > 0)
        {
            // 충돌체 저장
            _collider = colliders[0];
            ItemInfoAppear();
        }
        else
        {
            _collider = null;
            ItemInfoDisappear();
        }
    }


    private void ItemInfoAppear()
    {
        _pickupActivated = true;
        _pickupText.gameObject.SetActive(true);
        _pickupText.text = _collider.transform.GetComponentInChildren<ItemObject>().item.ItemName + " 획득하기" + " [E]";
        // 빨간색 포션 + 획득하기 [E]
    }

    private void ItemInfoDisappear()
    {
        _pickupActivated = false;
        _pickupText.gameObject.SetActive(false);
    }

    private void PickUp()
    {
        if (_pickupActivated && _collider != null)
        {
            // 플레이어와 아이템 사이의 거리 계산
            float distance = Vector3.Distance(transform.position, _collider.transform.position);
            // 일정 범위 내에 있을 때만 아이템을 획득할 수 있도록 함
            if (distance <= _range)
            {
                // ItemObject의 itemData 인수를 넘겨줌
                Inventory.instance.PickupItem(_collider.transform.GetComponentInChildren<ItemObject>().item);
                Destroy(_collider.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}