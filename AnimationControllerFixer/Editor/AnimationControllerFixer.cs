using UnityEditor;
using UnityEngine;
using System;
using System.IO;
using System.Text.RegularExpressions;

public class AnimationControllerFixer : MonoBehaviour
{
   // Add a menu item to fix layer weights and transition exit times.  Hotkey: Ctrl + i / Option + i
    [MenuItem("Assets/Animation Controller Fixes/Fix Exit Times + Layer Weights %i", false, 0)]
    static void FixWeightsAndTimes()
    {
        // Save asset changes to ensure any user updates to the Controller are present in the fixed version
        AssetDatabase.SaveAssets();

        // Get relative path to the active object within the context of the project, eg Assets/MyController.controller
        string relPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        
        // Use the relative path to get the absolute path for file I/O operations, eg C:/User/Pat/Unity/MyProject/Assets/MyController.controller
        string absPath = Path.GetFullPath(relPath);
        
        // Read the contents of the controller file into string variable origContents
        Debug.Log("Reading contents of " + absPath + "...");
        string origContents = File.ReadAllText(absPath);
        Debug.Log("DONE");

        // Create a backup copy of the controller
        string bakPath = absPath + ".bak";
        Debug.Log("Backing up the current contents of " + absPath + "to " + bakPath + "...");
        File.WriteAllText(bakPath, origContents);
        Debug.Log("DONE");

        // Copy origContents to newContents, setting all m_DefaultWeight values to '1'
        Debug.Log("Setting all layer weights to 1 (full)...");
        string newContents = Regex.Replace(origContents, @"m_DefaultWeight: \S+", "m_DefaultWeight: 1");
        Debug.Log("DONE");

        // Copy origContents to newContents, setting all m_ExitTime and m_HasExitTime values to '0'
        Debug.Log("Setting transition exit times to 0 and disabling them...");
        newContents = Regex.Replace(newContents, @"m_ExitTime: \S+", "m_ExitTime: 0");
        newContents = Regex.Replace(newContents, @"m_HasExitTime: \S+", "m_HasExitTime: 0");
        Debug.Log("DONE");

        // Replace the contents of the controller file with newContents
        Debug.Log("Writing updated contents to " + absPath + "...");
        File.WriteAllText(absPath, newContents);
        Debug.Log("DONE");

        // Reimport the controller so Unity reflects the changes immediately
        Debug.Log("Reimporting " + relPath + "...");
        AssetDatabase.ImportAsset(relPath, ImportAssetOptions.ImportRecursive);

        // Log a message verifying the operation is complete to the console, display a dialog box in the same vein.
        Debug.Log("Operation complete!");
        EditorUtility.DisplayDialog("Animation Controller Fixer", "All layer weights have been set to 1, and all transition exit times have been set to 0 then disabled.", "OK");
    }

    // Validate the currently selected object is a .controller file.  If it is, enable the option to fix layer weights and exit times.  Else, disable it.
    [MenuItem("Assets/Animation Controller Fixes/Fix Exit Times + Layer Weights %i", true)]
    static bool ValidateFixWeightsAndTimes()
    {
        // Get relative path to the active object within the context of the project, eg Assets/MyController.controller
        string relPath = AssetDatabase.GetAssetPath(Selection.activeObject);

        // Test if the current object's path ends with ".controller", then return the outcome
        return relPath.EndsWith(".controller");
    }


    // Add a menu item to fix layer weights. Hotkey: Ctrl + w / Option + w
    [MenuItem("Assets/Animation Controller Fixes/Fix Layer Weights %w", false, 100)]
    static void FixLayerWeights()
    {
        // Save asset changes to ensure any user updates to the Controller are present in the fixed version
        AssetDatabase.SaveAssets();
        
        // Get relative path to the active object within the context of the project, eg Assets/MyController.controller
        string relPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        
        // Use the relative path to get the absolute path for file I/O operations, eg C:/User/Pat/Unity/MyProject/Assets/MyController.controller
        string absPath = Path.GetFullPath(relPath);
        
        // Read the contents of the controller file into string variable origContents
        Debug.Log("Reading contents of " + absPath + "...");
        string origContents = File.ReadAllText(absPath);
        Debug.Log("DONE");

        // Create a backup copy of the controller
        string bakPath = absPath + ".bak";
        Debug.Log("Backing up the current contents of " + absPath + "to " + bakPath + "...");
        File.WriteAllText(bakPath, origContents);
        Debug.Log("DONE");

        // Copy origContents to newContents, setting all m_DefaultWeight values to '1'
        Debug.Log("Setting all layer weights to 1 (full)...");
        string newContents = Regex.Replace(origContents, @"m_DefaultWeight: \S+", "m_DefaultWeight: 1");
        Debug.Log("DONE");

        // Replace the contents of the controller file with newContents
        Debug.Log("Writing updated contents to " + absPath + "...");
        File.WriteAllText(absPath, newContents);
        Debug.Log("DONE");

        // Reimport the controller so Unity reflects the changes immediately
        Debug.Log("Reimporting " + relPath + "...");
        AssetDatabase.ImportAsset(relPath, ImportAssetOptions.ImportRecursive);

        // Log a message verifying the operation is complete to the console, display a dialog box in the same vein.
        Debug.Log("Operation complete!");
        EditorUtility.DisplayDialog("Animation Controller Fixer", "All layer weights have been set to 1.", "OK");
    }

    // Validate the currently selected object is a .controller file.  If it is, enable the option to fix layer weights.  Else, disable it.
    [MenuItem("Assets/Animation Controller Fixes/Fix Layer Weights %w", true)]
    static bool ValidateFixLayerWeights()
    {
        // Get relative path to the active object within the context of the project, eg Assets/MyController.controller
        string relPath = AssetDatabase.GetAssetPath(Selection.activeObject);

        // Test if the current object's path ends with ".controller", then return the outcome
        return relPath.EndsWith(".controller");
    }

    // Add a menu item to fix transition exit times. Hotkey: Ctrl + e / Option + e
    [MenuItem("Assets/Animation Controller Fixes/Fix Exit Times %e", false, 100)]
    static void FixExitTimes()
    {
        // Save asset changes to ensure any user updates to the Controller are present in the fixed version
        AssetDatabase.SaveAssets();
        
        // Get relative path to the active object within the context of the project, eg Assets/MyController.controller
        string relPath = AssetDatabase.GetAssetPath(Selection.activeObject);
        
        // Use the relative path to get the absolute path for file I/O operations, eg C:/User/Pat/Unity/MyProject/Assets/MyController.controller
        string absPath = Path.GetFullPath(relPath);
        
        // Read the contents of the controller file into string variable origContents
        Debug.Log("Reading contents of " + absPath + "...");
        string origContents = File.ReadAllText(absPath);
        Debug.Log("DONE");

        // Create a backup copy of the controller
        string bakPath = absPath + ".bak";
        Debug.Log("Backing up the current contents of " + absPath + "to " + bakPath + "...");
        File.WriteAllText(bakPath, origContents);
        Debug.Log("DONE");

        // Copy origContents to newContents, setting all m_ExitTime and m_HasExitTime values to '0'
        Debug.Log("Setting transition exit times to 0 and disabling them...");
        string newContents = Regex.Replace(origContents, @"m_ExitTime: \S+", "m_ExitTime: 0");
        newContents = Regex.Replace(newContents, @"m_HasExitTime: \S+", "m_HasExitTime: 0");
        Debug.Log("DONE");

        // Replace the contents of the controller file with newContents
        Debug.Log("Writing updated contents to " + absPath + "...");
        File.WriteAllText(absPath, newContents);
        Debug.Log("DONE");

        // Reimport the controller so Unity reflects the changes immediately
        Debug.Log("Reimporting " + relPath + "...");
        AssetDatabase.ImportAsset(relPath, ImportAssetOptions.ImportRecursive);

        // Log a message verifying the operation is complete to the console, display a dialog box in the same vein.
        Debug.Log("Operation complete!");
        EditorUtility.DisplayDialog("Animation Controller Fixer", "All transition exit times have been set to 0 and disabled.", "OK");
    }

    // Validate the currently selected object is a .controller file.  If it is, enable the option to fix exit times.  Else, disable it.
    [MenuItem("Assets/Animation Controller Fixes/Fix Exit Times %e", true)]
    static bool ValidateFixExitTimes()
    {
        // Get relative path to the active object within the context of the project, eg Assets/MyController.controller
        string relPath = AssetDatabase.GetAssetPath(Selection.activeObject);

        // Test if the current object's path ends with ".controller", then return the outcome
        return relPath.EndsWith(".controller");
    }


}