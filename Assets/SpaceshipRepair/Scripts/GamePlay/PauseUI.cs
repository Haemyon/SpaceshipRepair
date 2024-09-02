using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace SpaceShipRepair
{

    public class PauseUI : MonoBehaviour
    {
        public GameObject Pause;
        public GameObject Popup;

        void Start()
        {
            Pause.SetActive(false);
            Popup.SetActive(false);
        }

        public void ShowPause()
        {
            Pause.SetActive(true);
            FindAnyObjectByType<TimerAndScore>().pause = true;
            Time.timeScale = 0;
        }

        public void ClosePause()
        {
            Pause.SetActive(false);
            FindAnyObjectByType<TimerAndScore>().pause = false;
            Time.timeScale = 1.0f;
        }

        public void Continue()
        {
            Pause.SetActive(false);
            FindAnyObjectByType<TimerAndScore>().pause = false;
            Time.timeScale = 1.0f;
        }

        public void BackToMainMenu()
        {
            Popup.SetActive(true);
        }

        public void ClosePopup()
        {
            Popup.SetActive(false);
        }

        public void ConfirmPopup()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}