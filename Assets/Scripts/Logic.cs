using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Logic : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject victoryScreen;
    public GameObject player;
    public GameObject victoryCoin;

    public void Update()
    {
        spawnVictoryCoin();
    }

    public void spawnVictoryCoin()
    {
        if (player.GetComponent<Player>().coinsCollected == 6)
        {
            victoryCoin.SetActive(true);
        }
    }
    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void victory()
    {
        victoryScreen.SetActive(true); 
    }

    public void exitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
