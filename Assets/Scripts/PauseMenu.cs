using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
	public GameObject PauseMenuScreen;
	public GameObject RestartScreen;
	public GameObject ExitScreen;
	public GameObject GameHUD;

	public void Start()
	{
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
	}

	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (Time.timeScale == 1)
			{
				PauseGame();
			}
			else
			{
				ResumeGame();
			}
		}
	}

	void PauseGame()
	{
		PauseMenuScreen.SetActive(true);
		Time.timeScale = 0;
		Cursor.lockState = CursorLockMode.None;
		GameHUD.SetActive(false);
	}

	void ResumeGame()
	{
		PauseMenuScreen.SetActive(false);
		Time.timeScale = 1;
		Cursor.lockState = CursorLockMode.Locked;
		GameHUD.SetActive(true);
		RestartScreen.SetActive(false);
		ExitScreen.SetActive(false);
	}

	public void RestartGame()
	{
		RestartScreen.SetActive(true);
	}

	public void ConfirmRestart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void CancelRestart()
	{
		RestartScreen.SetActive(false);
	}

	public void ExitGame()
	{
		ExitScreen.SetActive(true);
	}

	public void ConfirmExit()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void CancelExit()
	{
		ExitScreen.SetActive(false);
	}
}
