using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipSpawner : MonoBehaviour
{

    [System.Serializable]
    public struct SpaceshipPart
    {
        public GameObject normalPrefab; // ���� ���� ������
        public GameObject brokenPrefab; // �ջ� ���� ������
        public bool isBroken; // �ջ� ����
    }

    [System.Serializable]
    public class SpaceshipBlueprint
    {
        public List<SpaceshipPart> parts;
        public int maxBrokenParts;
    }

    public List<GameObject> spaceshipPrefabs; // ���ּ� ������ ����Ʈ
    public Transform spawnPoint; // ���� ��ġ (�ɼ�)
    public List<SpaceshipBlueprint> spaceshipBlueprints = new List<SpaceshipBlueprint>();
    public Canvas canvas;

    public void SpawnRandomSpaceship()
    {
        // ���� �ε��� ����
        int randomIndex = Random.Range(0, spaceshipPrefabs.Count);

        // ���õ� ������ ��������
        GameObject spaceshipPrefab = spaceshipPrefabs[randomIndex];

        // ���� ��ġ ���� (ȭ�� �߾� ����)
        Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        // ���ּ� ���� �� �α� �����
        GameObject newSpaceship = Instantiate(spaceshipPrefab, spawnPosition, Quaternion.identity);
        newSpaceship.transform.SetParent(canvas.transform);
        foreach(var part in spaceshipBlueprints[randomIndex].parts)
        {
            GameObject partInstance = Instantiate(part.isBroken ? part.brokenPrefab : part.normalPrefab, spawnPosition, Quaternion.identity);
            partInstance.transform.SetParent(canvas.transform);
        }
        Debug.Log($"������ ���ּ�: {newSpaceship.name}, �ð�: {Time.time}, ��ġ: {spawnPosition}");
    }
}
