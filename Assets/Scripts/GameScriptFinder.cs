using UnityEngine;

public class GameScriptFinder : MonoBehaviour
{
    GameScript gameScript;
    bool hasDone = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameScript = FindAnyObjectByType<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDone) return;
        gameScript = FindAnyObjectByType<GameScript>();
        hasDone = true;
    }

    public void NextLevel()
    {
        gameScript.NextScene();
    }

    public void QuitGame()
    {
        gameScript.QuitGame();
    }
}
