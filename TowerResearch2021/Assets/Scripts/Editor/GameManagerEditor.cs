using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        GameManager gameManager = (GameManager)target;
        gameManager.blocksIndex = EditorGUILayout.IntField("blocksIndex", gameManager.blocksIndex);
        EditorGUILayout.HelpBox("This should be set to 0 before playing. If you need to edit other GM values, enter Debug mode in the top right of the inspector." +
            "When reseting a tower, ensure that the rotation is reset as well", MessageType.Info);

        if (GUILayout.Button("Reset Tower Blocks"))
        {
            gameManager.blocksIndex -= 6;
            gameManager.Invoke("buildTower", 0f);
            gameManager.Invoke("buildTower", 0.1f);
        }
        if (GUILayout.Button("Reset Tower Rotation"))
        {
            gameManager.baseBlock.GetComponent<BaseController>().Invoke("ResetRotation", 0f);
        }
    }
}
