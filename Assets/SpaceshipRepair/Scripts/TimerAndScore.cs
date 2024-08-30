using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceShipRepair
{
    public class TimerAndScore : MonoBehaviour
    {
        public GameObject countDownUI;
        public Text timerText;
        public Text scoreText;
        public Text repairChanceText;
        public GameOverMenu gameOverMenu;  // GameOverMenu�� ����
        public GameObject boom;
        public Text countDownText;
        public GameObject target;

        private float timer = 60f;
        private int score = 0;
        private int repairchance = 4;
        private float countDown = 3f;

        public bool gameStart = false;
        bool launch = false;
        public bool pause = false;

        void Start()
        {
            AudioManager.Instance.PlaySFX("CountDown");
            FindAnyObjectByType<SpawnRocket>().Spawn();
            Time.timeScale = 0.9f;
            if (gameOverMenu == null)
            {
                Debug.LogError("GameOverMenu�� �Ҵ���� �ʾҽ��ϴ�. �ν����Ϳ��� ������ �������ּ���.");
            }
            repairChanceText.text = repairchance.ToString();
        }

        void Update()
        {
            if (!gameStart)
            {
                countDown -= Time.deltaTime;
                countDownText.text = Mathf.Ceil(countDown).ToString();
                if (countDown<=0)
                {
                    countDown = 0;
                    Debug.Log("Game Start");
                    countDownUI.SetActive(false);
                    gameStart = true;
                }
            }

            if (gameStart)
            {
                if(pause)
                {
                    Debug.Log("pause");
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1.0f;
                    timer -= Time.deltaTime;
                    timerText.text = Mathf.Ceil(timer).ToString();
                    if (timer < 0)
                    {
                        timer = 0;
                        Time.timeScale = 0;
                        gameStart = false;
                        GameOver();
                    }
                }
            }

            if (launch)
            {
                FindAnyObjectByType<Rocket>().transform.position = Vector3.MoveTowards(FindAnyObjectByType<Rocket>().transform.position, target.transform.position, 3f * Time.deltaTime);
                //Debug.Log(FindAnyObjectByType<Rocket>().transform.position);
                //Debug.Log(target.transform.position);
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
                    FindAnyObjectByType<SpawnRocket>().spawn = false;
                    launch = true;
                    AddScore(1);
                    Invoke("NewRocket", 3.0f);
                }
                else
                {
                    AudioManager.Instance.PlaySFX("Explosion");
                    Destroy(Instantiate(boom, transform.position, Quaternion.identity), 0.7f);
                    Invoke("BoomDestroy", 0.7f);
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

        private void NewRocket()
        {
            FindAnyObjectByType<SpawnRocket>().spawn = true;
            launch = false;
            FindAnyObjectByType<Rocket>().DestoryRocket();
            FindAnyObjectByType<SpawnRocket>().Spawn();
            ResetRepairChance();
        }

        public void SetTimeScaleZero()
        {
            Time.timeScale = 0.0f;
        }

        public void SetTimeScaleOne()
        {
            Time.timeScale = 1.0f;
        }
    }
}