
# VRChat Animator Controller Fixer #

Allows you to automagically handle the annoying "gotchas" of building complex Animator Controllers for VRChat avatars in Unity.


## Use ##
Import the .unitypackage or the AnimatorControllerFixer folder into your Unity project, then either:

A: Right click on your .controller file in your Project view, then choose an option from the Animation Controller Fixes submenu, or
![image](https://user-images.githubusercontent.com/46183407/164161141-728d5e97-d339-443f-93bd-2bf918d362b6.png)
B: Left click your .controller file in your Prject view, then press one of the corresponding hotkey combinations.



### Options ###
| Option                         | Functionality                                                                | Hotkey              |
|--------------------------------|------------------------------------------------------------------------------|---------------------|
| Fix Layer Weights              | Sets all Layer Weights to 1, ensuring animations are visible.                | Ctrl + W / Cmd + W  |
| Fix Exit Times                 | Sets all Transition Exit Times to 0, then unchecks "Has Exit Time" for each. | Ctrl + E / Cmd + E  |
| Fix Exit Times + Layer Weights | Performs the functions of both options listed above.                         | Ctrl + I / Cmd + I  |
