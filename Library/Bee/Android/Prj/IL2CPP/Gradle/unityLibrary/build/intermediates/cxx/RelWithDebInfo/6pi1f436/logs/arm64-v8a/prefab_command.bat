@echo off
"D:\\Unity\\2023.1.11f1\\Editor\\Data\\PlaybackEngines\\AndroidPlayer\\OpenJDK\\bin\\java" ^
  --class-path ^
  "C:\\Users\\phaml\\.gradle\\caches\\modules-2\\files-2.1\\com.google.prefab\\cli\\2.0.0\\f2702b5ca13df54e3ca92f29d6b403fb6285d8df\\cli-2.0.0-all.jar" ^
  com.google.prefab.cli.AppKt ^
  --build-system ^
  cmake ^
  --platform ^
  android ^
  --abi ^
  arm64-v8a ^
  --os-version ^
  22 ^
  --stl ^
  c++_shared ^
  --ndk-version ^
  23 ^
  --output ^
  "D:\\Unity\\Project\\PrototypeTileMaster\\.utmp\\RelWithDebInfo\\6pi1f436\\prefab\\arm64-v8a\\prefab-configure" ^
  "C:\\Users\\phaml\\.gradle\\caches\\transforms-3\\121b6b243cedf8bef90d462440e4bf24\\transformed\\jetified-games-frame-pacing-1.10.0\\prefab"