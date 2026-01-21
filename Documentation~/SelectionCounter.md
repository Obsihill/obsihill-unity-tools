# Selection Counter

Unity 6 메인 툴바에 하이어라키 선택 오브젝트 개수를 표시하는 도구입니다.

## 기능

- 하이어라키에서 선택된 오브젝트 수를 실시간으로 표시
- 메인 툴바에 자동으로 통합
- 선택 변경 시 즉시 업데이트

## 요구사항

- Unity 6000.3 이상
- Editor 환경

## 사용 방법

패키지를 설치하면 자동으로 메인 툴바 우측에 추가됩니다. 별도의 설정이 필요하지 않습니다.

### 기본 동작

1. 하이어라키에서 오브젝트를 선택합니다
2. 메인 툴바에 "Selected: N" 형식으로 개수가 표시됩니다
3. 선택을 변경하면 자동으로 업데이트됩니다

### 툴바 위치 커스터마이징

Unity 6의 툴바 커스터마이징 기능을 사용하여 위치를 변경할 수 있습니다:

1. 메인 툴바 우클릭
2. "Customize Main Toolbar..." 선택
3. "Obsihill/Selection Count" 항목을 원하는 위치로 드래그

## 기술 세부사항

### 구현

- `MainToolbarElement` API 사용
- `Selection.selectionChanged` 이벤트 구독
- `InitializeOnLoadMethod`를 통한 자동 초기화

### 코드 구조

```csharp
namespace Obsihill.Editor
{
    public static class SelectionCountMainToolbar
    {
        private const string ElementPath = "Obsihill/Selection Count";
        
        [MainToolbarElement(ElementPath, defaultDockPosition = MainToolbarDockPosition.Right)]
        public static MainToolbarElement CreateSelectionCountLabel()
        {
            // 툴바 요소 생성
        }
        
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            // 이벤트 구독
        }
        
        private static void RefreshLabel()
        {
            // UI 갱신
        }
    }
}
```

### 조건부 컴파일

Unity 6 이상에서만 컴파일되도록 `#if UNITY_6000_3_OR_NEWER` 지시문을 사용합니다. 이전 버전에서는 코드가 포함되지 않습니다.

## 확장

이 도구를 기반으로 다른 정보를 표시하도록 확장할 수 있습니다:

### 예제: 선택된 오브젝트 타입 표시

```csharp
[MainToolbarElement("Obsihill/Selection Type")]
public static MainToolbarElement CreateSelectionTypeLabel()
{
    var selection = Selection.activeGameObject;
    string displayText = selection != null 
        ? $"Type: {selection.GetType().Name}" 
        : "Type: None";
    
    var content = new MainToolbarContent(displayText, "Type of selected object");
    return new MainToolbarButton(content, null) { enabled = false };
}
```

## 문제 해결

### 툴바에 표시되지 않는 경우

**증상**: Selection Counter가 메인 툴바에 나타나지 않습니다.

**해결 방법**:
1. Unity 버전 확인 (6000.3 이상 필요)
2. 에디터 로그 확인 (컴파일 에러가 없는지)
3. 메인 툴바 커스터마이징 메뉴에서 활성화 상태 확인

### 개수가 업데이트되지 않는 경우

**증상**: 선택을 변경해도 개수가 업데이트되지 않습니다.

**해결 방법**:
1. 에디터를 재시작합니다
2. 스크립트 재컴파일 (Ctrl+R)
3. 콘솔에서 에러 메시지 확인

## 성능

- 선택 이벤트는 Unity에서 관리하므로 성능 오버헤드가 거의 없습니다
- UI 갱신은 이벤트 기반으로 동작하여 폴링이 없습니다

## 참고 자료

- [Unity MainToolbar API](https://docs.unity3d.com/ScriptReference/Toolbars.MainToolbar.html)
- [Unity Selection API](https://docs.unity3d.com/ScriptReference/Selection.html)
- [Unity Editor Extension](https://docs.unity3d.com/Manual/ExtendingTheEditor.html)
