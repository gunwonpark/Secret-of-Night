using UnityEngine.Playables;
using UnityEngine.Timeline;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TimelineCallbackBoss : MonoBehaviour
{
    private PlayableDirector playableDirector;
    [SerializeField] private GameObject Boss;

    private void Start()
    {
        playableDirector = GetComponent<PlayableDirector>();        
        // 타임라인 종료 콜백 함수 등록
        playableDirector.stopped += OnTimelineStopped;
    } 

    // 타임라인 종료 시 호출되는 콜백 함수
    private void OnTimelineStopped(PlayableDirector director)
    {
        Debug.Log("타임라인이 종료되었습니다.");
        Boss.SetActive(true);
       
        // 타임라인 종료 시 필요한 작업 수행
    }   
}
