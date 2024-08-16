using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public SpaceshipSpawner spawner;

    public void OnClick()
    {
        spawner.SpawnRandomSpaceship();
    }
}
