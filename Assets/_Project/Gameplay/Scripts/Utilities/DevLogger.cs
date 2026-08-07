public static class DevLogger
{
    [System.Diagnostics.Conditional("UNITY_EDITOR")]
    public static void Log(string message) => UnityEngine.Debug.Log(message);
}
