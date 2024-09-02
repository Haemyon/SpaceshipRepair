using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace SpaceShipRepair
{
    public class SpawnRocket : MonoBehaviour
    {
        private Rocket spawnRocket;
        public Position spawn_position;
        public GameObject targetPosition;

        public bool spawn = true;

        [SerializeField] private List<Rocket> rockets;
        public void Spawn()
        {
            int randomIndex = Random.Range(0, 3);
            spawnRocket = rockets[randomIndex];
            //Debug.Log("Spawn");
            Instantiate(spawnRocket, transform.position, Quaternion.identity);

            //FindAnyObjectByType<Rocket>().transform.position = new Vector3(0, 10, 0);
        }

        private void Update()
        {
            if (spawn)
            {
                FindAnyObjectByType<Rocket>().transform.position = Vector3.MoveTowards(FindAnyObjectByType<Rocket>().transform.position, targetPosition.transform.position, 3f * Time.deltaTime);
                //Debug.Log(FindAnyObjectByType<Rocket>().transform.position);
            }
        }
    }
}