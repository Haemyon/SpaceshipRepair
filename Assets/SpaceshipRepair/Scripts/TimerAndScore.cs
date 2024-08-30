using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipRepair
{
    public class TimerAndScore : MonoBehaviour
    {
        public Text timerText;
        public Text scoreText;
        public Text repairChanceText;
        public GameOverMenu gameOverMenu;  // GameOverMenu�� ����
        public GameObject boom;

        private float timer = 60f;
        private int score = 0;
        private int repairchance = 4;


        void Start()
        {
            FindAnyObjectByType<SpawnRocket>().Spawn();
            Time.timeScale = 1.0f;
            if (gameOverMenu == null)
            {
                Debug.LogError("GameOverMenu�� �Ҵ���� �ʾҽ��ϴ�. �ν����Ϳ��� ������ �������ּ���.");
            }
            repairChanceText.text = repairchance.ToString();
        }

        void Update()
        {
            timer -= Time.deltaTime;
            timerText.text = Mathf.Ceil(timer).ToString();
            if (timer < 0)
            {
                timer = 0;
                Time.timeScale = 0;
                GameOver();
            }
        }

        public void AddScore(int amount)
        {
            score += amount;
            scoreText.text = score.ToString();
        }

        public void StartTimer()
        {
            timer = 60f;
        }

        void GameOver()
        {
            Debug.Log("���� ����");

            // ���� ������ GameOverMenu�� ����
            gameOverMenu.ShowGameOverMenu(score);
        }

        public async void RepairTry() 
        {
            repairchance--;
            repairChanceText.text = repairchance.ToString();
            if (repairchance <= 0)
            {
                //���ּ� ���� �Ϸ� ���� ǥ�� �� ���ھ� �ø���
                if (FindAnyObjectByType<Rocket>().CheckRocketCondition())
                {
                    AudioManager.Instance.PlaySFX("Launch");
                    AddScore(1);
                    FindAnyObjectByType<Rocket>().DestoryRocket();
                    FindAnyObjectByType<SpawnRocket>().Spawn();
                    ResetRepairChance();
                }
                else
                {
                    AudioManager.Instance.PlaySFX("Explosion");
                    Destroy(Instantiate(boom, transform.position, Quaternion.identity), 0.5f);
                    Invoke("BoomDestroy", 0.5f);
                    Debug.Log("Destroy");
                }
            }
        }

        void ResetRepairChance()
        {
            repairchance = 4;
            repairChanceText.text = repairchance.ToString();
        }

        private void BoomDestroy()
        {
            FindAnyObjectByType<Rocket>().DestoryRocket();
            FindAnyObjectByType<SpawnRocket>().Spawn();
            ResetRepairChance();
        }
    }
}