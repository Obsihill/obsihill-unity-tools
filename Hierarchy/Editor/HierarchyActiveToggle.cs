using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEditor.ShortcutManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Obsihill.Editor
{
    public sealed class HierarchyShortcutContext : IShortcutContext
    {
        public bool active => IsHierarchyWindow(EditorWindow.focusedWindow)
            && !EditorGUIUtility.editingTextField;

        private static bool IsHierarchyWindow(EditorWindow window)
        {
            if (window == null)
                return false;

            // Unity 6000.6 uses the new Hierarchy window; earlier versions use SceneHierarchyWindow.
            string windowType = window.GetType().FullName;
            return windowType == "UnityEditor.SceneHierarchyWindow"
                || windowType == "Unity.Hierarchy.Editor.HierarchyWindow";
        }
    }

    public static class HierarchyActiveToggle
    {
        private static readonly HierarchyShortcutContext Context = new HierarchyShortcutContext();

        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            ShortcutManager.UnregisterContext(Context);
            ShortcutManager.RegisterContext(Context);
            AssemblyReloadEvents.beforeAssemblyReload -= UnregisterContext;
            AssemblyReloadEvents.beforeAssemblyReload += UnregisterContext;
        }

        private static void UnregisterContext()
        {
            ShortcutManager.UnregisterContext(Context);
        }

        [Shortcut("Obsihill/Toggle Selected Active", typeof(HierarchyShortcutContext), KeyCode.G)]
        private static void ToggleActive()
        {
            if (Context.active)
                ToggleSelectedObjects();
        }

        internal static void ToggleSelectedObjects()
        {
            var objects = new List<GameObject>();
            var nextStates = new List<bool>();
            foreach (var gameObject in Selection.gameObjects)
            {
                if (gameObject == null || EditorUtility.IsPersistent(gameObject)
                    || !gameObject.scene.IsValid() || !gameObject.scene.isLoaded
                    || (gameObject.hideFlags & HideFlags.NotEditable) != 0)
                    continue;

                objects.Add(gameObject);
                // Snapshot each object's own state before parent/child changes trigger callbacks.
                nextStates.Add(!gameObject.activeSelf);
            }

            if (objects.Count == 0)
                return;

            Undo.IncrementCurrentGroup();
            int undoGroup = Undo.GetCurrentGroup();
            Undo.SetCurrentGroupName("Toggle Selected Active");
            Undo.RecordObjects(objects.ToArray(), "Toggle Selected Active");

            var changedScenes = new HashSet<Scene>();
            for (int i = 0; i < objects.Count; i++)
            {
                var gameObject = objects[i];
                if (gameObject == null)
                    continue;

                gameObject.SetActive(nextStates[i]);
                PrefabUtility.RecordPrefabInstancePropertyModifications(gameObject);
                changedScenes.Add(gameObject.scene);
            }

            if (!EditorApplication.isPlaying)
            {
                foreach (var scene in changedScenes)
                    EditorSceneManager.MarkSceneDirty(scene);
            }

            Undo.CollapseUndoOperations(undoGroup);
            EditorApplication.RepaintHierarchyWindow();
        }
    }
}
