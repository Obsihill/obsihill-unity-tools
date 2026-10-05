# Changelog

All notable changes to this project will be documented in this file.

## [Unreleased]

### Added

- Added a Hierarchy-only G shortcut to invert each selected GameObject's active state, with Undo/Redo and prefab instance override support.

### Fixed

- Added an Editor-only assembly definition so UPM compiles the package scripts.
- Moved toolbar samples into an Editor folder and guarded their UnityEditor references for player builds.
- Limited the selection counter to scene GameObjects instead of counting project assets.
- Refreshed the scene toolbar on active scene changes, new scenes, scene saves, and Play Mode transitions.
- Aligned the scene toolbar's version guard with Unity 6000.3, disabled scene switching during Play Mode, and distinguished same-named scenes by path.
- Corrected the package installation URL, assembly layout documentation, and sample import path.

## [0.2.1] - 2026-09-20

### Fixed

- Added the missing Unity meta file for `Toolbar/SceneWarpToolBar`.
- Renamed the package changelog to the UPM standard `CHANGELOG.md` and added its meta file.

### Changed

- Added UPM documentation, changelog, license, and sample metadata to `package.json`.

## [0.2.0] - 2026-01-29

### Added

- Added `SceneWarpToolBar` for quickly switching between scenes registered in Build Settings.
