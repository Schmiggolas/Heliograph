# Heliograph
A VoIP implementation for Unity based on vis2k's Mirror HLAPI

## Summary
This is a very basic implementation of a VoIP service using vis2k's [Mirror](https://github.com/vis2k/Mirror) project.
At the moment this is as "barebones" as it gets but I could not find another (up to date) implementation of this. So I thought I might as well upload it. This whole thing was done in ~ 1h (including research) and is VERY basic, so don't expect too much.

## Usage
+ Install Mirror either via the [Asset Store](https://assetstore.unity.com/packages/tools/network/mirror-129321) or from the [GitHub page](https://github.com/vis2k/Mirror/releases).
+ Pull/download this repo and copy the `Heliograph/` folder with all its contents to your `Assets/` folder.
+ Add one `HelioRecorder` and one `HelioPlayer` component to each of your player prefabs (must be on the same object for now).
+ Add one `AudioSource` somewhere and reference it in `HelioPlayer`.
+ Customize your mic frequency in `Heliograph/Settings/MicrophoneSettings.cs` if you want to.
+ Start your game and connect some clients!

## ToDos
+ Some form of en/decoding
+ Push to talk
+ De-tangle the code and make it event-driven
+ (UnityPackage?)

## Contribute
Contributions are very welcome! Just start a PR.

## License
MIT. Do whatever you want.
