using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsManager : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject sceneSwitcher;
    private SwitchScenes _switchScenes;
    void Start()
    {
        Debug.Log("entered creditsManager");
        sceneSwitcher = GameObject.Find("SwitchScene");
        _switchScenes = sceneSwitcher.GetComponent<SwitchScenes>();
        //returnToMainMenu();
        StartCoroutine(returnToMainMenu());
        
    }

    private IEnumerator returnToMainMenu()
    {
        
        yield return new WaitForSeconds(5);
        _switchScenes.LoadGameScene("Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
