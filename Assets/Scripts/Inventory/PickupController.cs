using TMPro;
using UnityEngine;


public class PickupController : MonoBehaviour
{
    [SerializeField] private float _range;
    private bool _pickupActivated = false;
    private Collider _collider; //�浹ü ����

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

    // ������ ���̾��ũ �˻�
    private void CheckItem()
    {
        // ���� ���·� �浹ü�� ã��, �ڽ��� ��ġ�κ��� range������ŭ layerMask�� �ش��ϴ� �浹ü ����
        Collider[] colliders = Physics.OverlapSphere(transform.position, _range, _layerMask);
        // �浹ü�� �ϳ� �̻� ���� ��
        if (colliders.Length > 0)
        {
            // �浹ü ����
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
        _pickupText.text = _collider.transform.GetComponentInChildren<ItemObject>().item.ItemName + " ȹ���ϱ�" + " [E]";
        // ������ ���� + ȹ���ϱ� [E]
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
            // �÷��̾�� ������ ������ �Ÿ� ���
            float distance = Vector3.Distance(transform.position, _collider.transform.position);
            // ���� ���� ���� ���� ���� �������� ȹ���� �� �ֵ��� ��
            if (distance <= _range)
            {
                // ItemObject�� itemData �μ��� �Ѱ���
                Inventory.instance.AddItem(_collider.transform.GetComponentInChildren<ItemObject>().item);
                Destroy(_collider.gameObject);
                ItemInfoDisappear();
            }
        }
    }
}