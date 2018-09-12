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

## Exercises
The project has been split into three folders within the `./Assets/_Src` directory. The `FINISHED` folder is intended an end view that can be used for reference (note some prefabs and scripts are in the `Shared` folder).
Work should be carried out in the `Session` folder; currently containing one subdirectory `Prefabs` for the unfinished cannon asset.

*NOTE:* These exercises are not intended to teach C# or Javascript programming. Please reference the code in the `/FINISHED` or `/Shared` directories for samples.

### Exercise 1 - Setting the Scene
To get started we want to create a main scene which will act as our entry point. Into this scene we'll manually place fixed objects that we don't want instantiated by code.
1. Create a folder in `/Session` called "Scenes" and create a new Scene object inside "Main" (by right-click context menu in the [Project Window](https://docs.unity3d.com/Manual/ProjectView.html).
1. Explore the `/Shared/Prefabs` folder to create a scene that contains a test `Room` containing a `BrickWall` for blowing up.
1. Look in the `/Session/Prefabs` folder for the `UnfinishedCannon` and drag it into the scene too.
	* Take a look at what makes up the cannon prefab; currently missing all Behaviours (script components) that let it function.

### Exercise 2 - My first Behaviour
Unique features of 3D objects, how they move, operate and live are controlled by behaviours we write and share between objects. Behavioural programming tries to keep simple scripts with often generic purpose. Behaviours should be loosely coupled to one another, though there is functionality to stipulate dependencies on other components i.e. this 3D object must also have 'x' component.
1. Create a folder in `/Session` called "Scripts". Right-click create "C# Script" and name it something descriptive like "RotatingForever".
	* Behaviours should be a small and reusable as possible sticking to a single job ("Behaviour") named to reference what it is they do.
1. Open the new script in an editor of your choice (Unity comes with MonoDevelop or Visual Studio).
1. Make the behaviour continuously rotate the component it is part of (its parent object).
	* ```csharp
	...

	public void Update()
    {
        transform.Rotate( new Vector3( 0f, 10f, 0f ) * Time.deltaTime, Space.World );
    }
	```
	* This should rotate the 3D object by its y-axis by 10 degrees (euler angle) in relation to its world (think global) transformation matrix.
1. To add the new component to the Cannon's Gun:
	* Drag-and-drop your new script from the scripts folder to the 'UnfinishedCannon -> Gun' object in your scene (not in the project window `/Prefabs`).
	* OR click on the Gun object in the scene and observe the [Inspector Window](https://docs.unity3d.com/Manual/UsingTheInspector.html). It has a `Add Component` button that gives you a search field you can use to find and add your new script by name.
1. Click "Play" at the top of the Unity application window (The `Game` window should take focus and show you your scene from the view of the scene camera).
	* Observe your Cannon's Gun is now rotating forever.

#### Extra
* Try changing the second parameter of the `transform.Rotate` method call from 'world' to 'local' and observe how this effects the rotation of the cannon.
	* The cannon now spins relevant to its own y-axis which has already been offset at an angle compared to the global y-axis (the UP direction).

### Exercise 3 - Editor visibility
You'll notice the Gun in the previous exercise doesn't rotate very fast. We could change that in the behaviour script, but then we'd be missing out on a powerful feature of the Unity IDE. Instead we're going to easily make the rate of rotation editable in the [Inspector Window](https://docs.unity3d.com/Manual/UsingTheInspector.html).
1. Edit your behaviour script for rotating the Gun. Within the `transform.Rotate` method call, refactor the first parameter (Vector3) into a public class member.
	* ```csharp
	public Vector3 rotateBy = new Vector3( 0f, 10f, 0f );
	```
	* save the change and go back to the Unity IDE.
1. Click the Gun object to bring up its components in the Inspector. Once Unity updates for the external script modification you should see the behaviour now has an editable field for the new publicly scoped property.
	* Changing the values in the Inspector window will modify values for the instance of the object in the scene. It won't change prefab versions of the object or the script.

### Exercise 4 - Gun control
A controller is a simple behaviour which governs an entity and its local children which make it up. It should not be complicated or packed full of responsibilities, but can serve as a means of defining a more specific function (or set of) for a 3D object as a 'thing'.
1. Create and add a new component to the Gun object, name it "GunController". Which object it is added to changes the scope for local properties in the script. You could add it to the `UnfinishedCannon` calling it "CannonController"; in this example scope is unaffected as no local components are controlled by this script, only the components of child objects.
1. Edit the script to have one public method called "Fire".
	* Add the following debug message into the scope of the "Fire" method. ```csharp Debug.Log("Fire"); ```
1. Edit the script to call the new "Fire" method in the public lifecycle method "Start". (a lifecycle method is inherited by any Monobehaviour class and you can read about their [Execution Order](https://docs.unity3d.com/Manual/ExecutionOrder.html)).
1. When running this in the IDE observe how the debug message appears in the [Console Window](https://docs.unity3d.com/Manual/Console.html).

### Exercise 6 - Make Shot
Now that we have a firing instruction with the cannon; we need something to shoot.
#### 6.a - Creating the asset
1. Right-click anywhere in the [Hierarchy Window](https://docs.unity3d.com/Manual/Hierarchy.html) and create a `3D Object -> Sphere`. (Or any cannon shot shape you want).
1. In the Inspector window find the Transform component at the top of the view and change the scale of the sphere to 0.4 in all axis (or an appropriate scale that can be fired from your cannon).
1. Click the `Add Component` and add a new component called `RigidBody` (not the 2D version). Change the property to 10 (to give the shot some punch).
1. Rename the object in the hierarchy window from "Sphere" to "CannonShot".
#### 6.b - Store it as a prefabrication.
1. Create a new folder in the `/Session` directory called "Prefabs".
1. Drag-and-drop the "CannonShot" object from the hierarchy window into new folder to store it as a prefabrication object. A prefab is a manually pre-set formation of objects, children and components with initial settings for instantiation later through code. It can also serve as a pre-made entity for dragging and dropping into a scene as you did earlier with the `Room` and `BrickWall` prefabs.
1. You can delete the object from the scene as instances of it will be created from the cannon in the next exercises.
#### 6.c - Inform the cannon
1. Modify the "GunController" script from earlier to have a new public property typed `GameObject` named "cannonShotPrefab" and back in the Unity IDE drag-and-drop the new prefab from the `/prefabs` folder you created in the [Project Window](https://docs.unity3d.com/Manual/ProjectView.html) to the [Inspector Window](https://docs.unity3d.com/Manual/UsingTheInspector.html) when the Gun object is selected in the scene. This will update the GunController component (Behaviour) of cannon in the scene with a fixed reference to the cannon shot you want to fire.
	* You can also select the prefab by clicking the small icon to the right of the "Cannon Shot Prefab" property field; which will bring up a search window.

#### Extra
* Find the `/Shared/Materials` folder and drag-and-drop the `Metal` material onto the newly created shot; either on the prefab object directly (in your Asset folders) or before deleting it in the scene remembering to update the prefab by clicking `Apply` in the Inspector window.

### Exercise 7 - Fire
Now we have a Gun controller to give the command to fire and an object to blast out, we should marry the two together.
#### 7.a.0 - The pointy end.
Before we can instantiate the cannon shot prefab, we'll need to know where to instantiate it in the scene.
1. In the hierarchy window find the Gun object again and right-click on it; select `Create Empty`.
	* Observe a new 3D object has been created at the local centre point of the Gun object. The empty object simply means it is a 3D object with a 3D transform component, but not much else.
1. Move the empty object out on front of the Gun barrel, where you might expect a new cannon shot to appear when fired. *Note:* Most games development is all smoke and mirrors.
	* At the top of the Unity IDE select `Pivot` and `Local` from the Rect Tools, a guide to finding this can be found in the [Basic Layout](https://docs.unity3d.com/Manual/UIBasicLayout.html).
	* Pivot and local selected will allow you to better see the actual origin point of the selected object and its orientation.
	* In this case you want to +z-axis (often considered the forward direction) to point in the direction you want the cannon shot to fire.
1. Rename the empty object something memorable... "ProjectileSpawnPoint".
#### 7.a.1 - Again, inform the cannon
1. Modify the "GunController" script made earlier to have one new public property typed `Transform` named "barrelPoint".
1. In the Unity Inspector window drag-and-drop or select the "ProjectileSpawnPoint" for the cannon in the scene.
	* You'll see that because the property type is `Transform`, which is a component present in the "ProjectileSpawnPoint" object; so the assignment will not be rejected and the `Transform` component of the object is referenced here.
#### 7.b - Spawn the Shot as a projectile

### Exercise 5 - Keyboard input with editor actions

#### Extra
* Try adding another input component that tells the BrickWallController to reset.

## More Exercises

### Exercise 8 - Bang!
#### 8.a - Spawn on collision
#### 8.b - Tidy yourself up

### Further exploration
* Try adding more inputs so the cannon can be rotated on the x and y axis using the arrow keys instead of rotating forever.

## Troubleshooting
* "How do I create a new asset/script/object?" - Find the [Project Window](https://docs.unity3d.com/Manual/ProjectView.html) and either use the `Create` pull down menu or right-click to access a context menu with the same options.
* "My new script can't be found" - Likely the name of the new file doesn't match the name of the class inside. Both must match. This can be a common mistake when creating a new script and renaming it afterwards.
* "I've tested my scene by hitting Play then Stop, but now I cannot click on objects in the scene" - The 'Game' window is auto focused when you hit Play and this doesn't change after hitting Stop. Click the `Scene` tab in the same window tab list to get back to your edit view.
* "I changed something about my prefab, but it didn't save the change" - If you modify an object you stored as a prefab in the [Hierarchy Window](https://docs.unity3d.com/Manual/Hierarchy.html) and not on the prefab itself in your Assets folders then the change will not be saved to the prefab the object is associated with unless you update the prefab by clicking the `Apply` button in the Inspector window of; at the top beside `Prefab` just below the name field of the object.
* "The cannon shot gets stuck inside the Cannon or flies off in the wrong direction" - Check that the forward (often z-axis) of the "ProfectileSpawnPoint" is facing in the right direction away from the cannon (at the top of the Unity IDE click `Pivot` and `Local` to better see the position and orientation of a 3D object in local context). Also check the physics force being applied is along the same forward axis.
* "The cannon shot is still not firing forward" - Could be the spawn point is positioned too close to the barrel of the cannon for the size of the cannon shot. If too close, they will collide on instantiation.