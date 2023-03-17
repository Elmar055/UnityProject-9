using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    // sent object wave
    private float spawnRate = 1;
    // scoretext
    public TextMeshProUGUI scoreText;
    // gameover text
    public TextMeshProUGUI gameOverText;
    // restartbutton
    public Button restartButton;
    private int score;
    public bool isGameActive;
    public GameObject titleScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // for start couritine
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
        
    }

    public void UpdateScore(int scoreToAdd)
    {
        // update score
        score += scoreToAdd;
        // update on screen
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        
        isGameActive = false;
        // show gameovertext on screen
        gameOverText.gameObject.SetActive(true);
        // show restart button on screen
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        // restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        score = 0;
        isGameActive = true;
        // send object each one second
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        // do not show titleScreen on screen
        titleScreen.gameObject.SetActive(false);
    }
}
