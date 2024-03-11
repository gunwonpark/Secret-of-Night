using TMPro;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    [SerializeField] private float _range;
    private bool _pickupActivated = false;
    private RaycastHit hit;

    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private TextMeshProUGUI _pickupText;

    [SerializeField] private Inventory _inventory;

    private void Update()
    {
        CheckItem();
        TryAction();
    }

    private void TryAction()
    {
        if (Input.GetKey(KeyCode.E))
        {
            CheckItem();
            PickUp();
        }
    }

    // 아이템 레이어마스크 검사
    private void CheckItem()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, _range, _layerMask))
        {
            ItemInfoAppear();
        }
        else
            ItemInfoDisappear();
    }


    private void ItemInfoAppear()
    {
        _pickupActivated = true;
        _pickupText.gameObject.SetActive(true);
        _pickupText.text = hit.transform.GetComponent<ItemObject>().itemData.name + " 획득하기" + " [E]";
    }

    private void ItemInfoDisappear()
    {
        _pickupActivated = false;
        _pickupText.gameObject.SetActive(false);
    }

    private void PickUp()
    {
        if (_pickupActivated)
        {
            if (hit.transform != null)
            {
                Debug.Log(hit.transform.name);
                //ItemObject의 itemData 인수를 넘겨줌
                _inventory.PickupItem(hit.transform.GetComponent<ItemObject>().itemData);
                Destroy(hit.transform.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}
