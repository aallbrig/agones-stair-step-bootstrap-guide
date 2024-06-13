using UnityEditor;

namespace Editor
{
    public static class BuildManager
    {
        [MenuItem("Game/BuildManager/Build All")]
        public static void BuildAll()
        {
            BuildGameClients();
            BuildGameServers();
        }
        // [MenuItem("Game/BuildManager/Build Game Client")]
        public static void BuildGameClients()
        {
            BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = new []
                {
                    "Assets/Scenes/Game.unity"
                },
                locationPathName = "Builds/GameClient/game.amd64.app",
                target = BuildTarget.StandaloneOSX,
                subtarget = (int) StandaloneBuildSubtarget.NoSubtarget,
                options = BuildOptions.None
            });
        }
        // [MenuItem("Game/BuildManager/Build Game Server")]
        public static void BuildGameServers()
        {
            // set to IL2CPP for server builds
            var oldBackend = PlayerSettings.GetScriptingBackend(BuildTargetGroup.Standalone);
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, ScriptingImplementation.IL2CPP);
            BuildPipeline.BuildPlayer(new BuildPlayerOptions
            {
                scenes = new []
                {
                    "Assets/Scenes/Game.unity"
                },
                locationPathName = "Builds/GameServer/game.x86_64",
                target = BuildTarget.StandaloneLinux64,
                subtarget = (int) StandaloneBuildSubtarget.Server,
                options = BuildOptions.Development
            });
            PlayerSettings.SetScriptingBackend(BuildTargetGroup.Standalone, oldBackend);
        }
    }
}
