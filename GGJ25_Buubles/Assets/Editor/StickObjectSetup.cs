using UnityEditor;
using UnityEngine;

public class StickObjectSetup : MonoBehaviour
{
    [MenuItem("Tools/StickObject Setup")]
    private static void AddComponentsToSelected()
    {
        // Get all selected GameObjects
        GameObject[] selectedObjects = Selection.gameObjects;

        if (selectedObjects.Length == 0)
        {
            Debug.LogWarning("No GameObjects selected. Please select one or more GameObjects.");
            return;
        }

        foreach (GameObject obj in selectedObjects)
        {
            // Add a Box Collider if it doesn't already have one
            if (obj.GetComponent<BoxCollider>() == null)
            {
                obj.AddComponent<BoxCollider>();
                Debug.Log($"Added Box Collider to {obj.name}");
            }

            // Add a Rigidbody if it doesn't already have one
            if (obj.GetComponent<Rigidbody>() == null)
            {
                obj.AddComponent<Rigidbody>();
                Debug.Log($"Added Rigidbody to {obj.name}");
            }
            
            if (obj.GetComponent<StickObject>() == null)
            {
                obj.AddComponent<StickObject>();
                Debug.Log($"Added StickObject to {obj.name}");
            }
        }
    }
}
