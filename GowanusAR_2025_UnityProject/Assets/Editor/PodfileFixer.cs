using UnityEditor;
using UnityEditor.Callbacks;
using System.IO;
using UnityEngine;

public class PodfileFixer
{
    [PostProcessBuild(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
        Debug.Log("PodfileFixer script started..."); // ✅ Add this to confirm it's running

        if (target == BuildTarget.iOS)
        {
            string podfilePath = Path.Combine(pathToBuiltProject, "Podfile");
            Debug.Log($"Looking for Podfile at: {podfilePath}");

            if (File.Exists(podfilePath))
            {
                Debug.Log("Podfile found, modifying..."); // ✅ Confirm Podfile exists
                string[] podfileLines = File.ReadAllLines(podfilePath);
                for (int i = 0; i < podfileLines.Length; i++)
                {
                    if (podfileLines[i].Contains("pod 'ARCore/GARSession'"))
                    {
                        podfileLines[i] = "  pod 'ARCore/GARSession', '~> 1.48.0'";
                        Debug.Log("Updated ARCore/GARSession to 1.48.0");
                    }
                    if (podfileLines[i].Contains("pod 'ARCore/Geospatial'"))
                    {
                        podfileLines[i] = "  pod 'ARCore/Geospatial', '~> 1.48.0'";
                        Debug.Log("Updated ARCore/Geospatial to 1.48.0");
                    }
                }
                File.WriteAllLines(podfilePath, podfileLines);
                Debug.Log("Podfile successfully updated.");
            }
            else
            {
                Debug.LogWarning("Podfile not found in the expected directory.");
            }
        }
    }
}
