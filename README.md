# VinesauceVODClipper
![VinesauceVODClipper screenshot](https://i.imgur.com/AoGrSF5.png)
Yet another ffmpeg wrapper. Uses a ``.txt`` file with timestamps to make shortened copies of videos without re-encoding! Perfect for saving hard drive space and time spent uploading/downloading full VODs-- all without sacrificing quality.

# Download
You can get the latest version of this program from the [Releases](https://github.com/ShrineFox/VinesauceVODClipper/releases) page.  
Just extract the ``.zip`` anywhere on your PC and run the ``.exe``.

# Requirements
- Install the [.NET 8.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.11-windows-x64-installer).
- Place [ffmpeg.exe](https://github.com/yt-dlp/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-win64-gpl.zip) in the program's ``Dependencies/`` folder.

# Usage
## Creating a .txt file
On each line of the ``.txt`` file, put the name of the video. At the end, put the start and end timestamps of the clip. For example:
```
[Vinesauce] Vinny & Friends - VRChat #6 45:10 48:40
Vinny - Mario 64 in Minecraft, Sonic, Doom, TF2, Blender, etc.. 1:12:00 1:13:26
[Vinesauce] Vinny - Mario & Luigi: Superstar Saga (part 1) 1:02:49 1:05:00
[Vinesauce] Vinny - Quick GameCube Corruptions 46:02 49:20
[Vinesauce] Vinny - Red Dead Redemption 2 (part 21) 1:05:14 1:06:26
```
## Creating clips
- Launch the program
- Choose your ``.txt`` file. This will load the list of video names and timestamps.
- For each video name, assign a video file. This can be done quickly by dragging the file onto the video name.
- Choose an output folder for your clips.
- Click the "Create clips" button to generate clips!
- Upload the clips to Google Drive and then you're done.

## How it works
Basically, ffmpeg snips all the audio and video tracks between the specified timestamps and saves them to a new file. The data is more or less unaltered, however it will try to adjust the timestamps of the new file so that it doesn't confuse video players/editors.  
This doesn't always work perfectly due to missing I-Frames in the beginning of the video, so the first second or two may appear blank, glitched, or frozen. You can account for this by providing starting timestamps that are **slightly earlier in the video** than you actually need.

## Re-encoding clips
If for some reason editing software still doesn't play friendly with the clip, you can try re-encoding it using the ``Tools > Re-Encode Clips`` option. Note that there may possibly be quality loss as a result.