using UnityEngine;
using UnityEditor;
using GamesOfVaibhav;

[CustomEditor(typeof(EnemyDetection))]
public class YourScriptEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyDetection script = (EnemyDetection)target;

        // Calculate the angle limits
        float halfAngle = script.DetectionAngle * 0.5f;

        // Calculate the clockwise and anti-clockwise angles
        float clockwiseFromAngle = -halfAngle;
        float clockwiseToAngle = halfAngle;
        float antiClockwiseFromAngle = -halfAngle;
        float antiClockwiseToAngle = halfAngle;

        // Visualize the two arcs

        Handles.color = new Color(1.0f, 0.0f, 0.0f, 0.5f);
        DrawArc(script.DetectionOrigin, antiClockwiseFromAngle, antiClockwiseToAngle, script.ColliderRadius);
    }

    private void DrawArc(Transform origin, float fromAngle, float toAngle, float radius)
    {
        Vector3 fromDir = Quaternion.Euler(0, fromAngle, 0) * origin.forward;
        Vector3 toDir = Quaternion.Euler(0, toAngle, 0) * origin.forward;

        Handles.DrawSolidArc(origin.position, origin.up, fromDir, toAngle - fromAngle, radius);
    }
}
