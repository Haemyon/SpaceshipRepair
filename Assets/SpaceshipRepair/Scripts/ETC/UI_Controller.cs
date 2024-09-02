using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace SpaceShipRepair
{

    public class UI_Controller : MonoBehaviour
    {
        public void ToggleBGM()
        {
            AudioManager.Instance.PlaySFX("UI_On_Off");
            AudioManager.Instance.ToggleMusic();
        }

        public void ToggleSFX()
        {
            AudioManager.Instance.PlaySFX("UI_On_Off");
            AudioManager.Instance.ToggleSFX();
        }
    }
}