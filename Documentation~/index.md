# Obsihill Tools 문서

Obsihill Tools는 Unity 에디터 워크플로우를 개선하기 위한 도구 모음입니다.

## 개요

이 패키지는 Unity 에디터 확장 도구들을 제공하여 개발 생산성을 향상시킵니다. 모든 도구는 Editor 전용이며 빌드에는 포함되지 않습니다.

## 지원 Unity 버전

- Unity 6000.3 이상

## 설치

Unity Package Manager를 통해 설치할 수 있습니다:

```
https://github.com/YOUR_USERNAME/ProjectOA.git?path=Assets/ObsihillTools
```

자세한 설치 방법은 [README](../README.md)를 참조하세요.

## 포함된 도구

### Selection Counter
하이어라키에서 선택된 오브젝트 개수를 메인 툴바에 표시합니다.

- **위치**: 메인 툴바 우측
- **기능**: 실시간 선택 개수 업데이트
- **요구사항**: Unity 6000.3 이상

자세한 내용은 [Selection Counter 문서](SelectionCounter.md)를 참조하세요.

## 구조

```
ObsihillTools/
├── package.json          # 패키지 메타데이터
├── README.md             # 패키지 소개
├── LICENSE               # 라이선스
├── CHANGELOG.md          # 변경 이력
├── Documentation~/       # 문서 (Unity에서 제외됨)
├── Samples~/            # 샘플 (선택적 임포트)
└── Editor/              # Editor 전용 코드
    ├── Obsihill.Editor.asmdef
    └── Toolbar/
        └── SelectionCounter/
```

## Assembly Definition

패키지는 `Obsihill.Editor` assembly definition을 사용합니다. Editor 전용 코드만 포함되어 있으며, 런타임에는 포함되지 않습니다.

## 확장 가능성

이 패키지는 확장 가능하도록 설계되었습니다. 새로운 Editor 도구를 추가하려면:

1. `Editor` 폴더에 새 스크립트 추가
2. `Obsihill.Editor` 네임스페이스 사용
3. 필요시 `Obsihill.Editor.asmdef`에 의존성 추가

## 문제 해결

### Selection Counter가 보이지 않는 경우

1. Unity 버전이 6000.3 이상인지 확인
2. 메인 툴바를 우클릭하여 "Customize Main Toolbar" 확인
3. "Obsihill/Selection Count"가 활성화되어 있는지 확인

## 기여

이슈나 풀 리퀘스트는 GitHub 저장소에서 환영합니다.

## 라이선스

MIT License - [LICENSE](../LICENSE) 참조
