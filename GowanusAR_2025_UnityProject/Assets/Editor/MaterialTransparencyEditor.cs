using UnityEngine;
using UnityEditor;

public class MaterialTransparencyEditor
{
#if UNITY_EDITOR
        private const string MaterialName = "Girl_Base_SG"; // The material to modify

    [MenuItem("Tools/Material/Toggle Surface Type %#t")]
    private static void ToggleSurfaceType()
    {
        // Find the material by name in the project
        string[] materialGUIDs = AssetDatabase.FindAssets($"t:Material {MaterialName}");
        if (materialGUIDs.Length == 0)
        {
            Debug.LogError($"Material '{MaterialName}' not found in Assets.");
            return;
        }

        string materialPath = AssetDatabase.GUIDToAssetPath(materialGUIDs[0]);
        Material material = AssetDatabase.LoadAssetAtPath<Material>(materialPath);

        if (material == null)
        {
            Debug.LogError($"Failed to load material at path: {materialPath}");
            return;
        }

        // Get the current Surface Type and toggle it
        float currentSurfaceType = material.GetFloat("_Surface");
        material.SetFloat("_Surface", currentSurfaceType == 0 ? 1 : 0); // 0 = Opaque, 1 = Transparent

        // Mark material as dirty so the changes apply
        EditorUtility.SetDirty(material);

        Debug.Log($"Material '{MaterialName}' Surface Type toggled to {(currentSurfaceType == 0 ? "Transparent" : "Opaque")}.");
    }
#endif
}
