using UnityEngine;

public class SpawnPointAdjuster : MonoBehaviour
{
    Respawn player;
    bool hasDone = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<Respawn>();
        player.startPos = transform.position;
        player.transform.position = player.startPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDone) return;
        player = FindAnyObjectByType<Respawn>();
        player.startPos = transform.position;
        player.transform.position = player.startPos;
        hasDone = true;
    }
}
