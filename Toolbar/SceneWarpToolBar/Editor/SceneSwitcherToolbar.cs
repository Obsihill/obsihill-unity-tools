using UnityEditor;
using UnityEditor.SceneManagement; // 씬 관리를 위해 필수
using UnityEngine;
#if UNITY_6000_0_OR_NEWER
using UnityEditor.Toolbars; // 유니티 6 툴바 네임스페이스

namespace Obsihill.Editor
{
    /// <summary>
    /// 메인 툴바에 씬 전환 드롭다운 버튼을 추가합니다.
    /// Build Settings에 등록된 씬 목록을 보여줍니다.
    /// </summary>
    public static class SceneSwitcherToolbar
    {
        // 툴바 요소의 고유 ID
        private const string ElementPath = "Obsihill/Scene Switcher";

        // 1. [MainToolbarElement] 속성으로 툴바에 등록
        // Play 버튼 근처(Center)나 오른쪽(Right)에 배치할 수 있습니다.
        [MainToolbarElement(ElementPath, defaultDockPosition = MainToolbarDockPosition.Middle)]
        public static MainToolbarElement CreateSceneSwitcher()
        {
            // 2. 버튼의 텍스트와 툴팁 설정
            // 현재 씬 이름을 버튼 텍스트로 표시하면 더 직관적입니다.
            string currentSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            if (string.IsNullOrEmpty(currentSceneName)) currentSceneName = "Unsaved Scene";

            var content = new MainToolbarContent($"🎬 {currentSceneName}", "Click to switch scenes");

            // 3. 버튼 생성 (클릭 시 ShowSceneMenu 함수 실행)
            var button = new MainToolbarButton(content, ShowSceneMenu);
            
            return button;
        }

        // 4. 드롭다운 메뉴 표시 로직
        private static void ShowSceneMenu()
        {
            GenericMenu menu = new GenericMenu();
            var scenes = EditorBuildSettings.scenes;

            if (scenes.Length == 0)
            {
                menu.AddDisabledItem(new GUIContent("No scenes in Build Settings"));
            }
            else
            {
                // Build Settings에 있는 모든 씬을 루프
                foreach (var scene in scenes)
                {
                    if (!scene.enabled) continue; // 비활성화된 씬 제외

                    string name = System.IO.Path.GetFileNameWithoutExtension(scene.path);
                    string path = scene.path;

                    // 메뉴 아이템 추가
                    menu.AddItem(new GUIContent(name), false, () => {
                        OpenScene(path);
                    });
                }
            }
            
            // 메뉴 구분선 및 Build Settings 바로가기 추가
            menu.AddSeparator("");
            menu.AddItem(new GUIContent("Open Build Settings..."), false, () => {
                EditorWindow.GetWindow(typeof(BuildPlayerWindow));
            });

            // 마우스 위치에 메뉴 표시
            menu.ShowAsContext();
        }

        // 5. 실제 씬 이동 로직
        private static void OpenScene(string scenePath)
        {
            // 변경사항이 있다면 저장할지 물어보는 안전장치
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(scenePath);
                
                // 씬이 변경되었으므로 버튼 텍스트(현재 씬 이름)를 갱신 요청
                MainToolbar.Refresh(ElementPath); 
            }
        }

        // 6. 씬이 변경될 때마다 툴바 UI(현재 씬 이름) 갱신
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            EditorSceneManager.sceneOpened -= OnSceneOpened;
            EditorSceneManager.sceneOpened += OnSceneOpened;
        }

        private static void OnSceneOpened(UnityEngine.SceneManagement.Scene scene, OpenSceneMode mode)
        {
            MainToolbar.Refresh(ElementPath);
        }
    }
}
#endif