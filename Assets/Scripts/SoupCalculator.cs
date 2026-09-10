using TMPro;
using UnityEngine;

public class SoupCalculator : MonoBehaviour
{
    int choiceCounter = 2;
    PlayerMovement player;
    GameScript gameScript;
    public int carrotCounter { get; private set; } = 0;
    public int leakCounter {get; private set; } = 0;
    [SerializeField] TextMeshProUGUI carroctCountText;
    [SerializeField] TextMeshProUGUI leakCountText;
    [SerializeField] TextMeshProUGUI counterText;
    bool hasDone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        gameScript = FindAnyObjectByType<GameScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDone) return;
        player = FindAnyObjectByType<PlayerMovement>();
        gameScript = FindAnyObjectByType<GameScript>();
        hasDone = true;
    }

    public void IncreaseCounter(int index)
    {
        if (choiceCounter <= 0)
        {
            return;
        }
        choiceCounter--;
        if (index == 0)
        {
            carrotCounter++;
        }
        else if (index == 1)
        {
            leakCounter++;
        }
        carroctCountText.text = carrotCounter.ToString();
        leakCountText.text = leakCounter.ToString();
        counterText.text = choiceCounter.ToString();
    }

    public void DecreaseCounter(int index)
    {
        if (choiceCounter >= 2)
        {
            return;
        }
        if (index == 0)
        {
            if (carrotCounter <= 0) { return; }
            carrotCounter--;
        }
        else if (index == 1)
        {
            if (leakCounter <= 0) { return; }
            leakCounter--;
        }
        choiceCounter++;
        carroctCountText.text = carrotCounter.ToString();
        leakCountText.text = leakCounter.ToString();
        counterText.text = choiceCounter.ToString();
    }

    public void NextLevel()
    {
        player.IncreaseSpeed(carrotCounter);
        player.gameObject.GetComponent<Health>().IncreaseMaxHealth(leakCounter);
        gameScript.NextScene();
    }
}
