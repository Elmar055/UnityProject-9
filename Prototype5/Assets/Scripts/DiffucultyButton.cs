using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiffucultyButton : MonoBehaviour
{
    private Button button;
    private GameManager gameManager;
    // insatiniate in inspector
    public int difficulty;
    // Start is called before the first frame update
    void Start()
    {
        // assign value
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        // when on click diffuculty button execute set difficulty
        button.onClick.AddListener(SetDiffuculty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetDiffuculty()
    {
        Debug.Log(gameObject.name + " was clicked!");
        gameManager.StartGame(difficulty);
    }
}
