# Intuitive Physics Tower Research

*Bei Xiao, Jesse Schwartz, Chenxi Liao*


## Outline

The goal of this research is to study how well humans can perceive intuitive physics interactions in virtual reality. Users are placed in a VR/Haptic environment (Pimax 5k HMD and 3DS TouchX Haptic Device) and asked to view towers, which vary in their stability. After viewing and freely rotating the towers in VR, while also being able to touch and feel the tower blocks using the TouchX device, the users are asked to:
1. Judge the stability of the tower on a scale of `1-7`, 1 being least and 7 being most stable
2. Assess which zone(s) the tower will fall into. There are 5 zones, one in each cardinal direction and a stable zone. The user can pick 2 zones but is only required to pick one.
   - There are colors in the UI that match the colors on the floor of the trial area, so users can match the UI to the trial even if they've rotated the tower extensively.
3. After submitting their answers, the towers get reset to center and the users watch the towers fall.
4. Users assess 50 towers 3 times each.

## Setup

This experiment uses Unity 2020.3.8f1 -- Newer versions will likely still work but may cause issues. It's advised to stay with this version unless absolutely necessary for newer features.

### Pimax HMD

The Pimax should be relatively easy to set up but can sometimes be a bit finicky:
1. Make sure both base stations are plugged in and point at the experiment
   - One should be set to mode `b`, the other should be set to mode `c`. It shouldn't matter which one as long as they are different.
   - In the Xiao lab, it generally works best if one is set on the counter while the other is next to the round table, both pointed at the center. They should be about the same height and looking almost directly at each other
2. Open the PiTool app. Here you can see if the headset is being properly tracked. While it may keep tracking after ending/starting a new session, it's advised to re-run the guide every session.
   - Run the `Guide` command in the PiTool app.
   - Select `USB` mode
   - When prompted to center, ensure the HMD is pointed in the forward direction -- this will affect the starting orientation of the user in the experiment so its vital that they face forward.
   - When prompted to input height, place the HMD on the floor and input `0`. This has historically led to better height recognition and tracking from the HMD, base stations, and Unity than accurately measuring the height of the desk/user.
   - If there are any major issues with the device, the `Restart HMD` and `Restart Service` buttons reset the device and the app, respectively. Usually restarting both is worthwhile if there are issues.
3. In Unity, The headset is called `PVRCameraRig`, as well as `PVRSession`. These should be both already set to useable settings and should be able to be copied and pasted into new scenes with little issue


### 3DS TouchX Haptic Device

The TouchX is an awesome device that is mostly self contained. That being said, it can make it harder to diagnose problems with it. It should work as intended most times and unlike the Pimax, you should *not* have to set this up every time you use it. In the event you *do* need to set it up, it is luckily also very easy.

1. Make sure everything is plugged in. This is simple but because the device never moves you might forget and not check.
2. Open `Touch Smart Setup`, its has a TSS icon.
   - It will scan for devices. You will likely have to press the pairing button at some point in the process. It is a dome/bulb shaped button located next to the other input jacks on the back of the device (Note: this button is facing downwards, not outwards).
   - Once the device is recognized and paired, you will have to do a short calibration. This can *sometimes* break so if the Z calibration takes more than a few minutes you may need to restart the process.
   - After completing calibration, you should save the configuration and then everything should be good to go with the device!
3. In Unity, the device is managed by the `OpenHaptics` plugin. Simply put: this plugin works but is not optimized. It can and will cause crashes (usually just on starting the program, though). Make sure to regularly save and you should be fine.

### Codebase

On the local machine, the Unity project can be found at `C:\Users\js9764a\Documents\GitHub\SummerResearch2021`. 
If you are on the local machine and want to make sure everything is up to date, the Github Repo is [here](https://github.com/JesseSchwartz25/SummerResearch2021).
If anyone in the future makes significant edits to the repo on another branch or fork, please update this to point to the most up to date repo.

### Unity

As long as you have Unity 2020.3.8f1 installed, this should run fine. It also uses a few plugins which are already installed in the repo:
- OpenHaptics
  - Manages the 3DS TouchX. Mostly stock with a few changes to fix some physics interactions. Changes should be marked with a comment.
- PVRUnity
  - Stock. For managing the headset
- LeanTween
  - Gives smooth animations via code with multiple styles of interpolation (linear, cubic, etc.). Used for animating the tower reset
- TextMeshPro
  - Standard Unity text editor



## Running the Experiment

### Start

In order to correctly save the data, ensure that you start from the menu scene, not the experiment scene. This will make the user input their name. Data is the saved in the file [name]_Data.txt with \t tab delimiters so that it can be easily moved into a .csv file. In the future, this data collection can be improved to input immediately into a .csv. Make sure the name does not exist in the folder of names already, otherwise it will append that already existing file located at `C:\Users\js9764a\Desktop\IntPhysTowersExperimentData`.

Before starting the experiment, ensure that the directions are read to the participant. [Directions document here](https://docs.google.com/document/d/18CdPhZKjmHznhepUMiwOmcbTAlHSCKC77-jME1xk-kU/edit?usp=sharing). It is important that all participants are given the same instructions so that they all equally understand the task.

If the participants have any questions, feel free to walk them through trial number 1, as it is always 100% stable so it can be used as a control for the experiment. Any "incorrect" answers in trial 1 are likely due to misunderstanding the task.

### The Towers

In iteration 1 of the experiment, we used 50 handmade towers and ran through them 3 times each (in the same order) for a total of 150 trials. This proved to be a bit long and some of the towers were not ideal candidates for the task. Iteration 2 will be slightly shorter and include more purposeful tower construction.
 
- TODO: New tower building tool

 While inside the main tower experiment scene (`TestEnvironment`), Things should mostly run as planned. The towers should reset every time the user submits and the playground blocks should respawn near the user. There is, however, a lingering bug in the tower construction which appears to be hardware dependant:
  
- The bug looks like the blocks floating rather than sitting directly on top of each other.
  - This is caused (we think) by an issue with the previous blocks not destroying fast enough. There are multiple fixes for this such as moving the previous tower before deleting and delaying spawning the new tower for a small amount of time, but occasionally the bug does still happen
  - Once it happens once, it is more likely to happen again.
  - Generally this bug only happens after the user takes a break and puts the headset down for an extended period, though not exclusively.
- Fix #1:
  - In the GameManagerObject, make note of the blocksIndex, then click `Reset Tower Rotation` if the tower is not at its base rotation, then click `Reset Tower Blocks`
  - This should rebuild the tower as intended. Ensure that the blocksIndex ends at the same number it was beforehand
- Fix #2:
  - If fix #1 doesn't make the tower build as intended, make note of the blocksIndex from GameManagerObject and also `epochs` from `DataManagerObject`
  - Restart the experiment, inputting the same exact name, then once in the experiment, fill the epoch and blocksIndex back to the previous numbers, then hit `Reset Tower Blocks`
  - This should rebuild the broken tower

Mitigation of the bug:
- The bug tends to happen most often after the headset falls asleep, which happens after of a few minutes of no movement. The trackers are very sensitive, so even a light nudge will activate them.
- If the user takes the headset off for a break, make sure to move the headset every few minutes to minimize chances of the bug occurring.


### The Data

Data is collected through the DataManager script, located in DataManagerObject, and saved after each trial into [name]_data.txt.

After each user completes their experiment, upload the data to [this spreadsheet](https://docs.google.com/spreadsheets/d/1z3X1jz-alfPHS3n1UmnFDq3567TfRbxicGSaQzE7T0M/edit?usp=sharing) (Please change if updated to new location)

In iteration 1 of the experiment, we saved:
- Zone1
  - First zone selected by the user, 0-5.
- Zone2	
  - Second zone selected by the user, 0-5, may be -1 if not selected
- Stability
  - Stability score selected by the user, 1-7
- Time
  - How long since the tower was spawned until an answer was submitted, in seconds
- Avg Pos
  - Mean position of the center of all blocks after the tower has fallen, in vector3 [x,y,z]
- Furthest
  - Which block moved the furthest in the xz plane from the [0,0]	in vector3 [x,y,z]
- CenterOfMass
  -  Mean position of the center of all blocks after the tower has fallen, accounting for mass. In iteration 1 this is the same as Avg position because all blocks have the same mass, in vector3 [x,y,z]
- Y Rotation
  - Final Y rotation seen by the user before hitting submit. Broken in iteration 1 as it used quaternion y instead of euler y
  - Fixed for future iterations	
- Majority
  - Which zones the middle/unity origin of the blocks were in, array form: [0,2,0,4,0], for example, where each index indicates how many blocks were in that zone.
  - This data is often later manipulated because a block can 'fall' but still be counted in zone 0.
- Start Pos	
  - The unity origin for all blocks before falling, in vector3[] [x,y,z]
- Final Pos
  - The unity origin for all blocks after falling, in vector3[] [x,y,z]



To change for iteration 2+:
- Screenshot of the tower when user submits
- Updated towers and tower building utility



## Code

All files are heavily commented. Nearly everything important happens in either the Game or Data manager scripts. Other issues with specific game objects is usually dealt with in a specific script (ie: haptic grabber issues in the haptic grabber script).

For more in depth dev logs, there is also [this document](https://docs.google.com/document/d/1Mpk0qSbZy6-qwDmoSCXvc7S2BMZcAvKvoU3Kt5uq95s/edit?usp=sharing) which logged all of the initial development and main issues with the haptic grabber and other tower building assorted issues.

Most variables are public and accessible via the inspector. GameManager is slightly different, in that it has a custom editor script to help with the bug. If you need to access additional variables in that script, be sure to enable debug mode.