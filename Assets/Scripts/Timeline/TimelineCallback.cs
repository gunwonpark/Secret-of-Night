using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class TimelineCallback : MonoBehaviour
{
    private PlayableDirector playableDirector;

    private void Start()
    {


        playableDirector = GetComponent<PlayableDirector>();


        // 타임라인 시작 시점 감지를 위해 트랙의 첫 번째 클립 찾기
        TimelineAsset timeline = (TimelineAsset)playableDirector.playableAsset;
        if (timeline != null && timeline.GetOutputTrack(0) is TrackAsset track)
        {
            foreach (var clip in track.GetClips())
            {
                // 첫 번째 클립의 시작 시간이 타임라인 시작 시간과 일치하는지 확인
                if (clip.start == 0f)
                {
                    Debug.Log("타임라인이 시작되었습니다.");
                    GameManager.Instance.inputManager.DisablePlayerAction();
                    break;
                }
            }
        }

        // 타임라인 종료 콜백 함수 등록
        playableDirector.stopped += OnTimelineStopped;
    }

    // 타임라인 종료 시 호출되는 콜백 함수
    private void OnTimelineStopped(PlayableDirector director)
    {
        Debug.Log("타임라인이 종료되었습니다.");
        GameManager.Instance.inputManager.EnablePlayerAction();
        // 타임라인 종료 시 필요한 작업 수행
    }
}
