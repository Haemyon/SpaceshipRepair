using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceShipRepair
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject Settings;
        public GameObject Info;

        void Start()
        {
            Settings.SetActive(false);
            Info.SetActive(false);
        }

        public void ShowSettings()
        {
            Settings.SetActive(true);
        }

        public void ShowInfo()
        {
            Info.SetActive(true);
        }

        public void CloseSettings()
        {
            Settings.SetActive(false);
        }

        public void CloseInfo()
        {
            Info.SetActive(false);
        }

        public void StartGame()
        {
            AudioManager.Instance.PlaySFX("Game_Start");
            SceneManager.LoadScene("GameScene");
        }
    }
}