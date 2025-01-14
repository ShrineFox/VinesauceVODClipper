# VinesauceVODClipper
![VinesauceVODClipper screenshot](https://i.imgur.com/fAHgZBd.png)
When you're working with a remote team of video editors, sharing full, uncompressed VODs with your team can allow for the best picture quality. However, these VODs are time consuming to upload and download, and take up a lot of space.  
Fortunately, this tool can improve efficiency by allowing you to create short clips from source VODs without sacrificing quality.

# How It Works
## Step 1: Creating a Spreadsheet
When you start this program, you'll see a table with the rows: Title, Description, Path, Start Time and End Time.  
1. Fill out each row with the following information. Right click to Add rows (as well as to delete/copy/move rows if needed).
- **Title**: The name of the video you need a shortened clip of. Can be approximate as long as it's clear which video you want.
- **Description**: More context about the clip. This will be added to the clip filename (``Title - Description.mp4``).
- **Path**: The location of the source VOD matching this video. If you don't have it, leave this blank for now.
- **Start Time**: The timestamp in ``hours:minutes:seconds`` where your clip should start.
- **End Time**: The timestamp where your clip should end.
2. Once you have filled out all the rows, you can go to ``File > Export Video List`` to create a ``.tsv`` file.  
3. Share this ``.tsv`` file with whoever on your team has the VODs, and they can open it up in the program and proceed to the next step.  
(Note: You can use Google Sheets to create a video list if you prefer. See here for an example.)
## Step 2: Assigning Source VODs
1. If you have the VODs and a list of videos, start the program and go to ``File > Import Video List`` to load the ``.tsv`` file.
2. Next, drag the video file for each VOD that matches the requested video onto the table row. It should automatically fill in the Path.
3. Once each video has a Path assigned, click **Create Clips** and they should appear in your Clips folder.  
(Note: If you didn't assign a clips folder, an Output folder will be created next to the program's ``.exe`` file.)
## Step 3: Upload the Clips
Now that you have the shortened clips, you can share them with your team via Google Drive or the file host of your choice.

# Download
You can get the latest version of this program from the [Releases](https://github.com/ShrineFox/VinesauceVODClipper/releases) page.  
Just extract the ``.zip`` anywhere on your PC and run the ``.exe``.

# Requirements
- Install the [.NET 8.0 Runtime](https://dotnet.microsoft.com/en-us/download/dotnet/thank-you/runtime-desktop-8.0.11-windows-x64-installer).
- Place [ffmpeg.exe](https://github.com/yt-dlp/FFmpeg-Builds/releases/download/latest/ffmpeg-master-latest-win64-gpl.zip) in the program's ``Dependencies/`` folder.

# Keyboard Shortcuts
- **Delete**: Delete the currently selected row(s) from the table.
- **CTRL+Up Arrow**: Move the currently selected row(s) up one row.
- **CTRL+Down Arrow**: Move the currently selected row(s) down one row.

# Options
## Avoid Negative Timestamps 
Some video editors/players will expect the original length of the video, causing the clip to appear much longer than it is. By default, this program tries to correct that by setting the "Avoid Negative Timestamps" setting to ``make_zero``. You can change the mode by hovering over ``Options > Avoid Negative Timestamps`` and choosing from the following:  
- ``make_non_negative`` shifts timestamps to make them non-negative.
- ``make_zero`` shifts timestamps so that the first timestamp is ``0``.
- ``auto`` enables shifting when required by the target format.  
- ``disabled`` avoids using this setting.  
  
Using this setting may cause audio/video tracks to become slightly desynced from one another. This can be manually corrected in i.e. Adobe Premiere by right clicking and unlinking the tracks, and then moving them manually until they align again. However, if accuracy is a concern, you may want to disable this setting.

## Error Logging
By default, it's set to "verbose" which will show you the ``ffmpeg`` arguments the program is using in order to generate clips. This may be helpful for debugging if something goes wrong, but if you prefer a less wordy output log, you can set it to ``Error`` to only show this information when an error occurs.  
Also, a folder called ``Logs`` should appear next to the program's ``.exe`` file, where you can find the ``.txt`` files that are generated whenever ffmpeg throws an exception.