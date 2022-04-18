using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour

{

    [SerializeField] GameObject ballPrefab;
    [SerializeField] GameObject playerPrefab;
    [SerializeField] private TMP_Text _scoreText;
    private int _score;
   


    void Start()
    {
        Cursor.visible = false;
        _score = 0;
        UpdateScore(0);
        _scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        Debug.Log("Adding score "+scoreToAdd+", current score: "+_score);
        _scoreText.text = "Score: "+_score;
    }

    public void GameOver()
    {
        Cursor.visible = true;
        LoadMenuScene();
    }
    public void LoadGameScene()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(1);
    }

    public void LoadMenuScene()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(0);
       
    }

}
