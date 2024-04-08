using UnityEngine;
using UnityEngine.Playables;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector director; // 타임라인을 제어하는 PlayableDirector 컴포넌트
    public GameObject[] disabledVirtualCamera; // 비활성화할 가상 카메라

    private void Start()
    {
        // 타임라인이 끝나면 OnDirectorStopped 메서드를 호출하도록 설정합니다.
        director.stopped += OnDirectorStopped;
    }

    private void OnDirectorStopped(PlayableDirector director)
    {
        // 타임라인이 끝났으므로 가상 카메라를 비활성화합니다.
        foreach (var camera in disabledVirtualCamera)
        {
            camera.SetActive(false);
        }
    }
    private void OnDestroy()
    {
        director.stopped -= OnDirectorStopped;
    }
}
