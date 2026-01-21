using UnityEditor;

#if UNITY_6000_3_OR_NEWER
using UnityEditor.Toolbars;

namespace Obsihill.Editor
{
    /// <summary>
    /// Displays the count of currently selected objects in the main toolbar.
    /// Works on Unity 6 and above.
    /// </summary>
    public static class SelectionCountMainToolbar
    {
        private const string ElementPath = "Obsihill/Selection Count";

        // Create toolbar element (place to the right of Play button)
        [MainToolbarElement(ElementPath, defaultDockPosition = MainToolbarDockPosition.Right)]
        public static MainToolbarElement CreateSelectionCountLabel()
        {
            int count = Selection.count;
            string displayText = $"Selected: {count}";

            var content = new MainToolbarContent(displayText, "Number of objects selected in Hierarchy");

            var element = new MainToolbarButton(content, null)
            {
                enabled = false // Disable button click (use as label)
            };

            return element;
        }

        // Subscribe to events on editor load
        [InitializeOnLoadMethod]
        private static void Initialize()
        {
            // Remove first to prevent duplicate subscriptions
            Selection.selectionChanged -= RefreshLabel;
            Selection.selectionChanged += RefreshLabel;
        }

        private static void RefreshLabel()
        {
            // Request UI refresh
            MainToolbar.Refresh(ElementPath);
        }
    }
}
#endif