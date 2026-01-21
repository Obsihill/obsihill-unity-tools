# Selection Count Main Toolbar

Displays the count of currently selected objects in the Unity main toolbar.

## Features

- **Real-time Selection Count**: Automatically updates when objects are selected/deselected in the Hierarchy
- **Main Toolbar Integration**: Appears as a toolbar element to the right of the Play button
- **Non-interactive Label**: Acts as a read-only label (button clicks are disabled)
- **Tooltip Support**: Shows helpful tooltip text when hovered

## Requirements

- **Unity Version**: Unity 6.3 or higher
- **Package**: UnityEditor.Toolbars (included in Unity 6+)

## Usage

The toolbar element automatically appears in the main Unity toolbar when:
1. Unity 6.3+ is detected
2. The editor is running in Play mode or Edit mode
3. Objects are selected in the Hierarchy

## Implementation Details

- Uses `MainToolbarElement` attribute for toolbar integration
- Subscribes to `Selection.selectionChanged` event for real-time updates
- Uses `MainToolbar.Refresh()` to update the UI
- Protected by `#if UNITY_6000_3_OR_NEWER` preprocessor directive

## Example Output

When 5 objects are selected:
```
Selected: 5
```
![SelectionCountMainToolbar screenshot](ScreenShot.png)
Tooltip text:
```
Number of objects selected in Hierarchy
```
