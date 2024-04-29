using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMinimap : MonoBehaviour
{
    [SerializeField] private Camera minimapCamera;
    [SerializeField] private float zoomMin = 1;
    [SerializeField] private float zoomMax = 30;
    [SerializeField] private float zoomOneStep = 1;
    [SerializeField] private TextMeshProUGUI textMapName;
   
    public void ZoomIn()
    {
        // 카메라의 orthographicSize 값을 감소시켜 카메라에 보이는 사물 크기 확대
        minimapCamera.orthographicSize = Mathf.Max(minimapCamera.orthographicSize - zoomOneStep, zoomMin);
    }

    public void ZoomOut()
    {
        // 카메라의 orthographicSize 값을 증가시켜 카메라에 보이는 사물 크기 축소
        minimapCamera.orthographicSize = Mathf.Min(minimapCamera.orthographicSize + zoomOneStep, zoomMax);
    }
}
