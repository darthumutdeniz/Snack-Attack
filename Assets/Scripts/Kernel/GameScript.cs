using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class GameScript : MonoBehaviour
{
    public static GameScript instance;
    public Animator animator;
    Health player;
    [SerializeField] private Image transitionImage;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            player = FindAnyObjectByType<Health>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void NextScene()
    {
        //transitionImage.DOColor(Color.black, 1f);
        SceneManager.LoadSceneAsync((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
        player.GetComponent<Rigidbody2D>().linearVelocity = Vector3.zero;
        player.ResetHealth();
    }

    //Only for Debug
    public void LoadScene(string name)
    {
        SceneManager.LoadSceneAsync(name);
        player.ResetHealth();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
