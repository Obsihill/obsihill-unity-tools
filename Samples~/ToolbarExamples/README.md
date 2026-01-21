# Toolbar Examples

이 샘플은 Obsihill Tools 패키지의 툴바 확장 기능을 사용하는 예제를 제공합니다.

## 포함된 예제

### 1. CustomToolbarButton.cs
메인 툴바에 커스텀 버튼을 추가하는 예제입니다.

### 2. DynamicToolbarLabel.cs
실시간으로 업데이트되는 동적 라벨 예제입니다.

## 사용 방법

이 샘플을 임포트하려면:

1. Package Manager에서 Obsihill Tools 패키지를 찾습니다
2. "Samples" 섹션을 확장합니다
3. "Toolbar Examples" 옆의 "Import" 버튼을 클릭합니다

임포트 후, 스크립트는 `Assets/Samples/Obsihill Tools/1.0.0/Toolbar Examples/` 경로에 저장됩니다.

## 예제 설명

### CustomToolbarButton
단순한 버튼을 툴바에 추가하고 클릭 이벤트를 처리하는 방법을 보여줍니다.

```csharp
[MainToolbarElement("Examples/My Button")]
public static MainToolbarElement CreateButton()
{
    var content = new MainToolbarContent("Click Me", "Example button");
    return new MainToolbarButton(content, OnButtonClick);
}
```

### DynamicToolbarLabel
시간이나 프로젝트 상태와 같은 동적 정보를 표시하는 방법을 보여줍니다.

## 추가 리소스

- [Unity Toolbar API 문서](https://docs.unity3d.com/ScriptReference/Toolbars.html)
- [패키지 메인 문서](../../Documentation~/index.md)
