using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public GameObject menu;
	public GameObject loadingInterface;
	public Image loadingProgressBar;
	public GameObject levelPanel;
	public AudioSource menuSelect;

	List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
    public void StartGame(string levelName)
	{
		HideMenu();
		ShowLoadingScreen();
		scenesToLoad.Add(SceneManager.LoadSceneAsync(levelName));
		StartCoroutine(LoadingScreen());
	}
	public void OpenLevels()
	{
		levelPanel.SetActive(!levelPanel.activeSelf);
		menuSelect.Play();
	}
	public void StartBuild()
	{
        menuSelect.Play();
        HideMenu();
		scenesToLoad.Add(SceneManager.LoadSceneAsync("CreativeScene"));
		StartCoroutine(LoadingScreen());
	}
	public void OpenMenu()
	{
        menuSelect.Play();
        HideMenu();
		scenesToLoad.Add(SceneManager.LoadSceneAsync("MenuScene") );
		StartCoroutine(LoadingScreen());
	}
    public void OpenCredits()
    {
        menuSelect.Play();
        HideMenu();
        scenesToLoad.Add(SceneManager.LoadSceneAsync("CreditsScene"));
        StartCoroutine(LoadingScreen());
    }
    public void HideMenu()
	{
		menu.SetActive(false);
	}
	public void ShowLoadingScreen()
	{
		loadingInterface.SetActive(true);
	}
    IEnumerator LoadingScreen()
	{
		float totalProgress = 0f;
		for(int i = 0; i < scenesToLoad.Count; i++)
		{
			while ( !scenesToLoad[i].isDone)
			{
				totalProgress += scenesToLoad[i].progress;
				loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
				yield return null;
			}
		}
	}
	public void ExitGame()
	{
		Application.Quit();
	}
}
