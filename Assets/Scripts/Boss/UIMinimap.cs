using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIMinimap : MonoBehaviour
{
    [SerializeField] private Camera minimapCamera;
    [SerializeField] private Canvas minimapCanvas;
    [SerializeField] private float zoomMin = 1;
    [SerializeField] private float zoomMax = 30;
    [SerializeField] private float zoomOneStep = 1;
    [SerializeField] private TextMeshProUGUI textMapName;

    private bool isMinimapActive = true;

    private void Awake()
    {
        // 맵 이름을 현재 씬 이름으로 설정 ( 원하는 이름으로 설정)
        textMapName.text = SceneManager.GetActiveScene().name;

        minimapCanvas = GetComponentInParent<Canvas>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            ToggleMinimap();
        }
       
    }

    private void ToggleMinimap()
    {
        isMinimapActive = !isMinimapActive; // 미니맵 상태 반전

        minimapCanvas.enabled = isMinimapActive;
    }

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
