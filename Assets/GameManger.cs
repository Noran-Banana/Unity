using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.BuiltIn.ShaderGraph;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public static GameManger Instance;

    public int score = 0;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StageClear()
    {
        Debug.Log("Stage Cleared, Score: " + score);
    }
}
