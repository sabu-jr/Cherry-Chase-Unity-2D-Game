using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BuildScript
{
    static void WindowsBuild()
    {
        string[] scenes = FindEnabledEditorScenes();


        BuildPipeline.BuildPlayer(scenes, "../WindowsBuild/CherryChase.exe", BuildTarget.StandaloneWindows, BuildOptions.None );
  
    }
}
