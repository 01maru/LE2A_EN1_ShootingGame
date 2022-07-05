using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GManager : MonoBehaviour
{
    private GameObject[] enemy;

    public GameObject panel;
    public GameObject button;
    public GameObject gameoverpanel;
    public GameObject retrybutton;
    public void SceneReset()
    {
        UIController.ResetHP();
        string activeSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(activeSceneName);
    }
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
        Application.targetFrameRate = 60;
        panel.SetActive(false);
        button.SetActive(false);
        gameoverpanel.SetActive(false);
        retrybutton.SetActive(false);
    }
    public void ChangeScene(string nextScene)
    {
        SceneManager.LoadScene(nextScene);

        if (nextScene == "Stage")
        {
            UIController.ResetHP();
            UIController.score = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (UIController.playerHP == 0)
        {
            gameoverpanel.SetActive(true);
            button.SetActive(true);
            retrybutton.SetActive(true);
        }
        else if (enemy.Length == 0)  //  “G‚ª‚¢‚È‚­‚È‚Á‚½‚ç
        {
            panel.SetActive(true);
            button.SetActive(true);
        }
    }
}
