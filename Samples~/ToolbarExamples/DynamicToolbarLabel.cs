using UnityEditor;
using UnityEngine;

#if UNITY_6000_3_OR_NEWER
using UnityEditor.Toolbars;

namespace Obsihill.Editor.Examples
{
    /// <summary>
    /// 동적으로 업데이트되는 라벨을 메인 툴바에 추가하는 예제입니다.
    /// 현재 시간을 표시하며 1초마다 업데이트됩니다.
    /// </summary>
    public static class DynamicToolbarLabel
    {
        private const string ElementPath = "Examples/Current Time";

        [MainToolbarElement(ElementPath, defaultDockPosition = MainToolbarDockPosition.Right)]
        public static MainToolbarElement CreateTimeLabel()
        {
            string currentTime = System.DateTime.Now.ToString("HH:mm:ss");
            string displayText = $"⏰ {currentTime}";
            
            var content = new MainToolbarContent(displayText, "Current time (updates every second)");
            var element = new MainToolbarButton(content, null)
            {
                enabled = false // 클릭 불가능한 라벨로 사용
            };
            
            return element;
        }

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            // EditorApplication.update를 사용하여 주기적으로 갱신
            EditorApplication.update -= UpdateTime;
            EditorApplication.update += UpdateTime;
        }

        private static double lastUpdateTime = 0;
        
        private static void UpdateTime()
        {
            // 1초마다 업데이트
            if (EditorApplication.timeSinceStartup - lastUpdateTime > 1.0)
            {
                lastUpdateTime = EditorApplication.timeSinceStartup;
                MainToolbar.Refresh(ElementPath);
            }
        }
    }
}
#endif
