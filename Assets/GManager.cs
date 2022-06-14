using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GManager : MonoBehaviour
{
    private GameObject[] enemy;

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemy.Length == 0)  //  “G‚ª‚¢‚È‚­‚È‚Á‚½‚ç
        {
            panel.SetActive(true);
        }
    }
}
