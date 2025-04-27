## 시연영상
https://www.youtube.com/watch?v=qop2KnrpkrA

## 핵심구현 
- 카메라 : 구조물로 인한 시야방해 해결
- 플레이어 이동 : FSM패턴을 통한 이동 및 공격
- 플레이어 스킬 : AnimatorStateInfo와 Animation Event를 통한 스킬 타이밍 제어
- 데이터 : excel을 통한 데이터 관리
- 메모리 :
  - LOD와 GPU instancing을 통한 batch연산 감소
  - Animation Key 해싱을 통한 string 최적화
  - 오브젝트 풀링을 통한 메모리 최적화
- 연출 : 타임라인과 시네마틱 카메라를 이용한 자연스러운 연출
- 사운드 : 자체제작 사운드 툴을 이용한 사운드 관리 및 적용
- UI :
  - 사운드, 마우스 감도, 해상도 조절
  - 옵저버 패턴을 활용한 동적 플레이어 스텟 업데이트
  
## 인게임 영상
![image](https://github.com/user-attachments/assets/a7802652-e377-473d-bf45-ecf9fd5dd708)
![image](https://github.com/user-attachments/assets/2d93e252-cc7a-4967-a504-7ebef897990a)
![image](https://github.com/user-attachments/assets/0e392e8d-ed13-415d-a6a1-b69adab45093)
![image](https://github.com/user-attachments/assets/c1a792e3-32a3-4073-8449-9dde16e99a16)
