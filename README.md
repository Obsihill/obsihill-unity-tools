# Obsihill Tools

Unity Editor Tools by Obsihill.

[English](README.md) | [한국어](README.ko.md)

## Installation

You can install this package via Unity Package Manager using the Git URL.

### via UPM (Git URL)

1. Open **Package Manager** in Unity.
2. Click **+** > **Add package from git URL...**
3. Enter the following URL:
   ```
   https://github.com/Obsihill/obsihill-unity-tools.git
   ```

To install this release explicitly, use the `v0.2.1` tag:

```text
https://github.com/Obsihill/obsihill-unity-tools.git#v0.2.1
```

## Features

### SceneWarpToolBar

- A toolbar that displays the list of scenes registered in Build Settings for quick navigation.

### SelectionCounter

- A toolbar that displays the count of selected GameObjects in the Hierarchy.

The package also includes **Toolbar Examples** under the Package Manager's Samples tab.

### Hierarchy Active Toggle

- Focus the Hierarchy, select one or more GameObjects, and press **G** to invert each object's own active state (`activeSelf`).
- Supports inactive objects, mixed selections, Undo/Redo, and prefab instance overrides.
- Does not run while editing object names or text fields. With an inactive parent, enabling a child does not activate it in the scene until its parent is enabled.
- Change the binding in **Edit > Shortcuts > Obsihill/Toggle Selected Active**.

## Requirements

- Unity 6000.3 or newer.

## License

MIT License
