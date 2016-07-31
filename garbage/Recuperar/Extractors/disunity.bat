@echo off
java -jar "%~dp0\disunity.jar" %* 

@disunity.bat asset unpack sharedassets0.assets
@disunity.bat asset unpack sharedassets1.assets
@disunity.bat bundle unpack sharedassets0.assets
@disunity.bat bundle unpack sharedassets1.assets
@disunity.bat asset unpack fofao.unity3d
@disunity.bat bundle unpack fofao.unity3d