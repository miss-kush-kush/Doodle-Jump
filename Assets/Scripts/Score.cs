using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text gameOverText;

    [SerializeField] private Transform camera;
    [SerializeField] private Transform doodler;

    private int yCamera, yDoodler, maxScore = 0;
    [SerializeField] private int yPositionDeath;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        yDoodler = (int)doodler.position.y;
        yCamera = (int)camera.position.y;

        if(yDoodler < (yCamera - yPositionDeath))
        {
            if(!gameOverText.gameObject.activeSelf)
            {
                gameOverText.gameObject.SetActive(true);
                gameOverText.text += "\nr - restart\nq - quit";
            }

            if(Input.GetKeyUp(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            else if(Input.GetKeyUp(KeyCode.Q)) 
            {
                Application.Quit();
                Debug.Log("Application Quit()");
            }
        }
        if (maxScore < yDoodler)
        {
            maxScore = yDoodler;
            scoreText.text = maxScore.ToString();
        }    
    }
}
