using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace SpaceShipRepair
{

    public class SpawnRocket : MonoBehaviour
    {
        private Rocket spawnRocket;

        [SerializeField] private List<Rocket> rockets;
        public void Spawn()
        {
            int randomIndex = Random.Range(0, 3);
            spawnRocket = rockets[randomIndex];
            //Debug.Log("Spawn");
            Instantiate(spawnRocket, transform.position, Quaternion.identity);
            //Debug.Log("Spawn Fin");
        }
    }
}