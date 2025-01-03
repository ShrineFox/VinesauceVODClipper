# VinesauceVODClipper
![VinesauceVODClipper screenshot](https://i.imgur.com/AoGrSF5.png)
Yet another ffmpeg wrapper. Uses a ``.txt`` file with timestamps to make shortened copies of videos without re-encoding! Perfect for saving hard drive space and time spent uploading/downloading full VODs-- all without sacrificing quality.

# Requirements
- Install the [.NET 8 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.11-windows-x64-installer).

# Usage
## Creating a .txt file
On each line of the .txt file, put the name of the video. At the end, put the start and end timestamps of the clip. For example:
```
[Vinesauce] Vinny & Friends - VRChat #6 45:10 48:40
Vinny - Mario 64 in Minecraft, Sonic, Doom, TF2, Blender, etc.. 1:12:00 1:13:26
[Vinesauce] Vinny - Mario & Luigi: Superstar Saga (part 1) 1:02:49 1:05:00
[Vinesauce] Vinny - Quick GameCube Corruptions 46:02 49:20
[Vinesauce] Vinny - Red Dead Redemption 2 (part 21) 1:05:14 1:06:26
```
## Creating clips
- Launch the program
- Choose your .txt file. This will load the list of video names and timestamps.
- For each video name, assign a video file. This can be done quickly by dragging the file onto the video name.
- Choose an output folder for your clips.
- Click the "Create clips" button to generate clips!
- Upload the clips to Google Drive and then you're done.