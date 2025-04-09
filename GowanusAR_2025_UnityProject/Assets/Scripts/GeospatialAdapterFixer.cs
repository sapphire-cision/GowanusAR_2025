using UnityEditor;
using UnityEngine;
using Google.XR.ARCoreExtensions.GeospatialCreator;
using System;
using System.Reflection;
using System.Linq;

[ExecuteInEditMode]
public class PatchOriginAdapter : MonoBehaviour
{
    void Update()
    {
        var origin = UnityEngine.Object.FindFirstObjectByType<ARGeospatialCreatorOrigin>();
        if (origin == null)
        {
            Debug.LogWarning("❌ No ARGeospatialCreatorOrigin found in scene.");
            return;
        }

        var adapterType = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .FirstOrDefault(t =>
                t.FullName == "Google.XR.ARCoreExtensions.GeospatialCreator.Editor.GeospatialCreatorCesiumAdapter+OriginComponentCesiumAdapter");

        if (adapterType == null)
        {
            Debug.LogWarning("❌ Could not find OriginComponentCesiumAdapter type via reflection.");
            return;
        }

        // Log all constructors
        var ctors = adapterType.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        foreach (var c in ctors)
        {
            Debug.Log("Found constructor: " + c.ToString());
        }

        // Find the one we can use
        var ctor = ctors.FirstOrDefault(c =>
        {
            var parameters = c.GetParameters();
            return parameters.Length == 1 &&
                   parameters[0].ParameterType.IsAssignableFrom(typeof(ARGeospatialCreatorOrigin));
        });

        if (ctor == null)
        {
            Debug.LogWarning("❌ Could not find internal constructor.");
            return;
        }

        var adapterInstance = ctor.Invoke(new object[] { origin });

        var field = typeof(ARGeospatialCreatorOrigin).GetField(
            "_originComponentAdapter",
            BindingFlags.NonPublic | BindingFlags.Instance);

        if (field == null)
        {
            Debug.LogWarning("❌ Could not find _originComponentAdapter field.");
            return;
        }

        field.SetValue(origin, adapterInstance);

        Debug.Log("✅ Successfully patched _originComponentAdapter via reflection.");
    }
}
