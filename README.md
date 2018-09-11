# UnityCannon
Tutorial project intended as a light introduction to Unity.

## Audience
Intended for engineers, but useful as an overview for designers. BBC D&E teams.

## Getting started

### Installing Unity
1. Install Unity [here](https://unity3d.com/get-unity/download).
1. Open project in Unity by [opening](https://answers.unity.com/questions/29138/how-do-i-open-an-existing-project-in-unity.html) the `Main.unity` file.
	* Alternatively use the Unity landing screen to "Open" and existing project.

### Installing dependencies
#### Local dependencies
1. *Check for a /Dependancies directory in the project. If present; continue.*
1. In the Unity IDE find your asset hierarchy view called the [Project Window](https://docs.unity3d.com/Manual/ProjectView.html).
1. Right-click the top Assets folder and choose `Import Package > Custom Package` from the context menu.
1. Use your directory navigator to find the './Dependancies' folder in the root of the project and select all `.unitypackage` files therein.
	* This may take time to process, presenting you a window where you can filter what is imported from these packages.
	* If this is your initial setup, leave all ticked.
1. Dependencies should be visibly added to your Project window.

#### Remote dependencies
1. In the Unity IDE open the [Asset Store Window](https://docs.unity3d.com/Manual/AssetStore.html).
1. Log in if you are not.
1. Find the following list of free store Assets and `Import` each one to your project.
	* [Unity Particle Pack](https://www.assetstore.unity3d.com/en/?stay#!/content/73777).

### Opening main scene
If Unity was opened via the landing screen then the project may have opened a default scene.
You'll find the `Main.unity` in the directory `./Assets/_Src/Scenes`

### Running the app
For this demonstration we won't be building the app to an executable, simply press the play button at the top of the application window.

## Troubleshooting
ToDo
