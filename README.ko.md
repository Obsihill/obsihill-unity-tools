# Obsihill Tools

Unity Editor Tools by Obsihill.

[English](README.md) | [한국어](README.ko.md)

## 설치 방법

Unity Package Manager를 통해 Git URL로 이 패키지를 설치할 수 있습니다.

### UPM을 통한 설치 (Git URL)

1. Unity에서 **Package Manager**를 엽니다.
2. **+** > **Add package from git URL...** 을 클릭합니다.
3. 다음 URL을 입력합니다:
   ```
   https://github.com/Obsihill/obsihill-unity-tools.git
   ```

특정 릴리스 버전을 설치하려면 `v0.2.1` 태그를 사용합니다:

```text
https://github.com/Obsihill/obsihill-unity-tools.git#v0.2.1
```

## 기능

### SceneWarpToolBar

- 빌드시 등록된 씬목록을 보여주고 빠른이동이 가능한 툴바.

### SelectionCounter

- 하이어라키에 선택한 게임오브젝트 카운트를 표시하는 툴바.

Package Manager의 Samples 탭에서 **Toolbar Examples** 샘플도 가져올 수 있습니다.

### Hierarchy Active Toggle

- 하이어라키에 포커스를 두고 게임오브젝트를 선택한 뒤 **G** 키를 누르면 각 오브젝트의 활성 상태(`activeSelf`)가 반전됩니다.
- 다중 선택, 비활성 오브젝트, Undo/Redo, 프리팹 인스턴스 변경 기록을 지원합니다.
- 오브젝트 이름이나 텍스트 입력 중에는 동작하지 않습니다. 부모가 비활성이면 자식을 켜도 부모를 켜기 전까지 씬에서는 비활성 상태입니다.
- **Edit > Shortcuts > Obsihill/Toggle Selected Active**에서 키를 변경할 수 있습니다.

## 요구사항

- Unity 6000.3 이상

## 라이선스

MIT License
