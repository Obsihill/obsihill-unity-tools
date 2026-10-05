#if UNITY_EDITOR
using UnityEditor;

#if UNITY_6000_3_OR_NEWER
using UnityEditor.Toolbars;

namespace Obsihill.Editor.Examples
{
    /// <summary>
    /// 메인 툴바에 커스텀 버튼을 추가하는 예제입니다.
    /// 버튼을 클릭하면 콘솔에 메시지를 출력합니다.
    /// </summary>
    public static class CustomToolbarButton
    {
        private const string ElementPath = "Examples/Custom Button";

        [MainToolbarElement(ElementPath, defaultDockPosition = MainToolbarDockPosition.Right)]
        public static MainToolbarElement CreateButton()
        {
            var content = new MainToolbarContent("🔧 Custom", "Click to test custom toolbar button");
            var button = new MainToolbarButton(content, OnButtonClick);
            return button;
        }

        private static void OnButtonClick()
        {
            UnityEngine.Debug.Log("Custom toolbar button clicked! 🎉");
            
            // 추가 기능 예시:
            // - 커스텀 에디터 윈도우 열기
            // - 프로젝트 상태 확인
            // - 빌드 프로세스 시작
            // - 등등...
        }
    }
}
#endif
#endif
