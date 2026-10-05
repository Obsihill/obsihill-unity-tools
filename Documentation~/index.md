# Obsihill Tools 문서

Obsihill Tools는 Unity 에디터 워크플로우를 개선하기 위한 도구 모음입니다.

## 개요

이 패키지는 Unity 에디터 확장 도구들을 제공하여 개발 생산성을 향상시킵니다. 모든 도구는 Editor 전용이며 빌드에는 포함되지 않습니다.

## 지원 Unity 버전

- Unity 6000.3 이상

## 설치

Unity Package Manager를 통해 설치할 수 있습니다:

```
https://github.com/Obsihill/obsihill-unity-tools.git
```

자세한 설치 방법은 [README](../README.md)를 참조하세요.

## 포함된 도구

### Selection Counter
하이어라키에서 선택된 오브젝트 개수를 메인 툴바에 표시합니다.

- **위치**: 메인 툴바 우측
- **기능**: 실시간 선택 개수 업데이트
- **요구사항**: Unity 6000.3 이상

자세한 내용은 [Selection Counter 문서](SelectionCounter.md)를 참조하세요.

### Scene Switcher

빌드 씬 목록의 활성 씬을 선택해 빠르게 전환합니다. 씬 이름과 경로를 함께 표시하고, 활성 씬 변경·새 씬 생성·저장 시 버튼을 갱신합니다. Play Mode와 Play Mode 전환 중에는 씬 전환이 비활성화됩니다.

### Hierarchy Active Toggle

하이어라키에서 게임오브젝트를 선택하고 **G** 키를 누르면 각 오브젝트의 `activeSelf`가 반전됩니다. 켜진 오브젝트는 꺼지고 꺼진 오브젝트는 켜집니다.

- 다중 선택과 부모·자식 동시 선택을 지원합니다.
- 변경 사항은 Undo/Redo로 되돌릴 수 있으며 프리팹 인스턴스 변경도 기록합니다.
- 하이어라키에 포커스가 있을 때만 동작하며 이름 변경과 텍스트 입력 중에는 실행되지 않습니다.
- 프로젝트의 프리팹 에셋과 편집 불가능한 오브젝트는 변경하지 않습니다.
- 부모가 비활성이면 자식의 `activeSelf`를 켜도 `activeInHierarchy`는 비활성입니다.
- **Edit > Shortcuts > Obsihill/Toggle Selected Active**에서 단축키를 변경할 수 있습니다.

## 구조

```
ObsihillTools/
├── package.json          # 패키지 메타데이터
├── README.md             # 패키지 소개
├── LICENSE               # 라이선스
├── CHANGELOG.md          # 변경 이력
├── Obsihill.Tools.Editor.asmdef # 패키지 전체의 Editor 전용 어셈블리
├── Documentation~/       # 문서 (Unity에서 제외됨)
├── Samples~/ToolbarExamples/Editor/ # 샘플 (선택적 임포트)
├── Hierarchy/Editor/     # G 키 활성 상태 토글
└── Toolbar/              # 툴바 도구
    ├── SceneWarpToolBar/Editor/
    └── SelectionCounter/Editor/
```

## Assembly Definition

패키지 루트의 `Obsihill.Tools.Editor.asmdef`는 `includePlatforms: ["Editor"]`로 설정되어 있습니다. 패키지 코드는 Editor에서만 컴파일되며 플레이어 빌드에는 포함되지 않습니다. 샘플은 임포트 후에도 `Editor` 폴더에 배치됩니다.

## 확장 가능성

이 패키지는 확장 가능하도록 설계되었습니다. 새로운 Editor 도구를 추가하려면:

1. 해당 도구의 `Editor` 폴더에 새 스크립트 추가
2. `Obsihill.Editor` 네임스페이스 사용
3. 필요시 `Obsihill.Tools.Editor.asmdef`에 의존성 추가

## 문제 해결

### Selection Counter가 보이지 않는 경우

1. Unity 버전이 6000.3 이상인지 확인
2. 메인 툴바를 우클릭하여 "Customize Main Toolbar" 확인
3. "Obsihill/Selection Count"가 활성화되어 있는지 확인

## 기여

이슈나 풀 리퀘스트는 GitHub 저장소에서 환영합니다.

## 라이선스

MIT License - [LICENSE](../LICENSE) 참조
