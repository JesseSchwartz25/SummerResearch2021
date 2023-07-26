# Intuitive Physics Tower Research

*Bei Xiao, Jesse Schwartz, Chenxi Liao*


## Outline

The goal of this research is to study how well humans can percieve intuitive physics interactions in virtual reality. Users are placed in a VR/Haptic environment (Pimax 5k HMD and 3DS TouchX Haptic Device) and asked to view towers, which vary in their stability. After viewing and freely rotating the towers in VR, while also being able to touch and feel the tower blocks using the TouchX device, the users are asked to:
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
   - When prompted to input height, place the HMD on the floor and input `0`. This has historicaly led to better height recognition and tracking from the HMD, base stations, and Unity than accurately measuring the height of the desk/user.
   - If there are any major issues with the device, the `Restart HMD` and `Restart Service` buttons reset the device and the app, respectively. Usually restarting both is worthwile if there are issues.
3. In Unity, The headset is called `PVRCameraRig`, as well as `PVRSession`. These should be both already set to useable settings and should be able to be copied and pasted into new scenes with little issue
