///////////////////////
// Script Contributors:
// Zeb
//
//
///////////////////////

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> menuPanels = new();
    [SerializeField] private GameObject currentPanel;


    private void Start()
    {
        //AudioManager.instance.PlayMusic("MainMenu");
    }

    private void Awake()
    {
        //AudioManager.instance.PlayMusic("MainMenu");
    }

    #region button functions
    public void OnClickStartButton()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OnClickMenuButton(int desiredPanelIndex)
    {
        // works for all inter-menu buttons, accepts the index of the panel to navigate to.
        currentPanel.SetActive(false);
        menuPanels[desiredPanelIndex].SetActive(true);
        currentPanel = menuPanels[desiredPanelIndex];
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    #endregion

    public void SFXOnClick()
    {
        //AudioManager.instance.PlaySFX("Click");
    }
}
