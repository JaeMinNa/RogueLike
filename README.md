# 🖥️ Skull Soul4

## 📽️ 프로젝트 소개
 - 게임 이름 : Skull Soul4
 - 플랫폼 : PC
 - 장르 : 2D 로그라이크
 - 개발 기간 : 23.12.14 ~ 23.12.21
<br/>

## ⚙️ Environment
- `Unity 2022.3.2`
- **IDE** : Visual Studio 2019, 2022, MonoDevelop
- **VCS** : Git (GitHub Desktop)
- **Envrionment** : PC `only`
- **Resolution** :	1920 x 1080 `FHD`
<br/>

## 👤 Collaborator - Team Intro
- 팀장  `성연호` - 몬스터
- 팀원1 `김동현` - 맵 자동 생성
- 팀원2 `고민수` - 플레이어
- 팀원3 `고현규` - UI
- 팀원4 `이준호` - GameManager
- 팀원5 `나재민` - 아이템 / 스킬
<br/>

## ▶️ 게임 스크린샷
<p align="center">
  <img src="https://github.com/gusrb0296/RogueLike/assets/149379194/d0d27cc1-c6cc-4eac-9e7b-b7318f62011b" width="49%"/>
  <img src="https://github.com/gusrb0296/RogueLike/assets/149379194/22aa9a76-cfab-4c94-bb30-7d112db408c6" width="49%"/>
</p>
<p align="center">
  <img src="https://github.com/gusrb0296/RogueLike/assets/149379194/5df9b6bc-7749-419b-af46-381029da1bd7" width="49%"/>
  <img src="https://github.com/gusrb0296/RogueLike/assets/149379194/8241f9e5-5444-4e26-94ec-926bb30ba1ec" width="49%"/>
</p>
<p align="center">
  <img src="https://github.com/gusrb0296/RogueLike/assets/149379194/0d664d37-db47-4fc0-b588-7a0ad72db896" width="49%"/>
  <img src="https://github.com/gusrb0296/RogueLike/assets/149379194/8d981c75-96af-4cab-a6f3-aab2d8acfebe" width="49%"/>
</p>
<p align="center">
  <img src="https://github.com/gusrb0296/RogueLike/assets/149379194/ab7b2841-b101-4147-9646-f059d381bc17" width="49%"/>
  <img src="https://github.com/gusrb0296/RogueLike/assets/149379194/cc58fc1c-b94e-43ef-a821-d326926ae1b0" width="49%"/>
</p>
<br/>

## ✏️ 구현 기능

### 1. 스킬 아이템 구현
<img src="https://github.com/JaeMinNa/Ocean_Bloom/assets/149379194/0935979e-6a46-40a4-9ede-ce4098a92469" width="50%"/>

- 아이템을 먹으면 스킬이 활성화되고 스킬을 사용할 수 있도록 구현
- 단축키를 누르면 스킬 프리팹을 생성해서 좌 또는 우로 움직이도록 구현
<br/>

### 2. 포션 아이템 구현
<img src="https://github.com/JaeMinNa/Ocean_Bloom/assets/149379194/4e703166-ce89-4d45-b84e-2e95311970da" width="50%"/>

- 각각 아이템을 먹으면 Player의 Power, Speed, AttackSpeed를 일정 시간 동안 상승하도록 구현
<br/>

### 3. 스킬 쿨타임 표시 기능 구현
<img src="https://github.com/JaeMinNa/Ocean_Bloom/assets/149379194/31d9e376-e72f-41f6-b494-d3adbc55a0be" width="50%"/>

- Image Type을 Filled로 변경해서 쿨타임 시간 동안은 이미지가 점차 차는 효과를 코드로 구현
<img src="https://github.com/JaeMinNa/Ocean_Bloom/assets/149379194/ec05403f-c070-4d5f-a96c-6a911b66bbc7" width="50%"/>

```C#
IEnumerator CoolTimeRoutine()
{
    float coolTime = Player.Data.SkillData.SkillCoolTime;
    float timer = 0f;
    while (true)
    {
        timer += Time.deltaTime;
        float per = timer / coolTime;
        _image.fillAmount = per;

        if (timer >= coolTime)
        {
            _image.fillAmount = 1f;
            break;
        }
        yield return null;
    }
}
```
<br/>

### 4. 데미지 표시 구현
<img src="https://github.com/JaeMinNa/Ocean_Bloom/assets/149379194/3d2a5e16-ac68-4483-8ba2-870d7b6e0abe" width="50%"/>

- TextMeshPro-Text로 일반 공격, 스킬 공격 시, 적용 데미지를 Instantiate, Destroy로 구현
<br/>

## 💥 트러블 슈팅

### 1. 스킬 적중 시, 진동 효과 구현
<img src="https://github.com/JaeMinNa/Ocean_Bloom/assets/149379194/4877cc7a-5670-4c25-830b-8cbe80763347" width="50%"/>

#### MainCamera의 position 값 변경으로 카메라 흔들리는 효과 구현
- MainCamera가 Player의 position을 따라가도록 구현해서 어색함
```C#
IEnumerator Shake(float shakeAmount, float shakeTime)
{
    float timer = 0;
    while (timer <= shakeTime)
    {
        Camera.main.transform.position 
            = new Vector3 (UnityEngine.Random.insideUnitCircle.x * shakeAmount, UnityEngine.Random.insideUnitCircle.y * shakeAmount, -10);
        timer += Time.deltaTime;
        yield return null;
    }
    Camera.main.transform.position = new Vector3(0, 0, -10);
}
```
#### MainCamera의 rotation 값 변경으로 구현
- position 값을 변경하는 것과 유사한 효과
```C#
IEnumerator Shake(float shakeAmount, float shakeTime)
{
    float timer = 0;
    while (timer <= shakeTime)
    {
        Camera.main.transform.rotation = Quaternion.Euler((Vector3)UnityEngine.Random.insideUnitCircle * shakeAmount);
        timer += Time.deltaTime;
        yield return null;
    }
    Camera.main.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
}
```
<br/>


## 🎮 전체 구현 기능 
1. 랜덤 던전 생성
2. 캐릭터 조작
3. 아이템 수집
4. 몬스터 생성 및 AI
5. 전투 시스템
6. 피해와 체력 관리
7. 보스 전투
8. 퍼마데스
9. 아티팩트 및 효과
10. 레벨업 시스템
11. 사운드 효과 및 음악


### 랜덤 던전 생성
* 맵이 랜덤으로 생성됩니다.
* 시작지점을 중심으로 너비 우선 탐색으로 맵을 새롭게 생성합니다.
* V키를 누르면 맵이 랜덤으로 생성됩니다.
* 맵 중심으로 상하좌우를 가져와서 만들어진 방이면 예외처리하고, 네모형태를 배제하고 일자 형태로 만들기 위해 상하좌우 2개 이상 만들어지면 예외처리 합니다.
* 맵 끝 중 하나를 보스 방으로 생성하고, 또 하나는 레벨업 맵(상점)으로 만들었습니다. 그 외에 다른 맵들은 모두 전투맵으로 만들었습니다.
### 캐릭터 조작
* 좌우 방향키, 스페이스바로 점프 할 수 있습니다.
* Z키를 눌러 공격할 수 있습니다.
* A키를 눌러 스킬을 사용할 수 있습니다.
### 아이템 수집
* 몬스터를 잡으면 Gem 과 일시적 효과 아이템이 드랍됩니다.
* 캐릭터가 해당 아이템에 접촉하면 해당 아이템을 얻을 수 있습니다.
* 던전 룸을 클리어 할 때 마다 스킬 아이템을 얻을 수 있습니다.
* 스킬 아이템은 획득 후 A 버튼을 누르면 사용할 수 있습니다.
### 몬스터 생성 및 AI
* 몬스터가 스폰 위치에 랜덤하게 생성됩니다.
* 주위에 플레이어가 있으면 플레이어르 쫓아오고, 공격합니다.
### 전투 시스템
* 플레이어는 원거리 공격만 가능하고, 발사체가 몬스터에게 맞으면 됩니다.
* 점프 공격이 가능 합니다.
* 스킬 공격은 각자의 공격력과 쿨타임을 가지고 있습니다.
### 피해와 체력 관리
* 캐릭터가 피해를 입으면 일정 시간 동안 무적이 됩니다.
* UI 상에서 체력이 줄어든 만큼 텍스트와 bar가 줄어듭니다.
* 값에 직접 접근하지 않고 DataManager를 Private으로 만들어 내부에서만 접근하고, 내부에 접근할 수 있는 메서드를 GameManager를 통해서 접근합니다.
### 보스 전투
* 보스 맵에 들어가면 보스 방 HP bar가 화면 상단에 나타납니다.
* 보스는 날아다니며, 근접 공격과 원거리 공격을 사용합니다.
* 보스의 전투에서 승리하면 승리 텍스트와 함께 맵 중앙에 포탈이 생성됩니다.
* 포탈로 이동하면 다시 시작 씬으로 돌아가게 됩니다.
### 퍼마데스
* 체력이 모두 소모되면 사망 애니매이션이 나타납니다. 캐릭터는 이동할 수 없으며 Game Over 텍스트가 등장합니다.
* Game Over 텍스트가 등장하면, Enter를 눌렀을 때 메인화면으로 돌아갈 수 있습니다.
### 아티팩트 및 효과
* 몬스터가 드랍한 아이템을 먹으면 효과 지속시간 동안 캐릭터의 몸 색이 변합니다.
* 스킬이 벽에 맞거나, 몬스터에 맞으면 폭발하는 효과가 나타납니다.
* 스킬을 사용하면 쿨타임이 스킬창에 표시됩니다.
### 레벨업 시스템
* 레벨업 맵에 들어가서 NPC와 상호작용 하면 레벨업을 할 수 있습니다.
* 게임 내에서 먹은 Gem을 소모해서 원하는 스탯을 올릴 수 있습니다.
* 올릴 수 있는 스탯은 - 체력 / 공격력 / 이동 속도 / 공격 속도 - 입니다.
### 사운드 효과 및 음악
* 버튼을 누르면 버튼 효과음이 재생됩니다.
* 메인 씬으로 이동하거나, 스타트 씬으로 이동하면 음악이 재생 됩니다
* 전투 방을 이동하면 음악이 재생 됩니다
* 보스 방에 들어가면 음악이 재생됩니다.
<br/>


## 📋 프로젝트 회고
### 잘한 점
 - 스킬 진동 효과로 게임 재미 요소 추가
 - 스킬 쿨타임 기능 구현
<br/>

### 한계
- 스킬, 아이템 구현 종류 부족
<br/>

### 소감
만든 게임을 직접 플레이하고 처음으로 재미있다는 느낌을 받은 프로젝트였습니다. Github 사용법이 확실히 익숙해졌고, 다음 프로젝트에서 더 잘할 수 있을 것 같다는 자신감을 얻을 수 있었습니다.
