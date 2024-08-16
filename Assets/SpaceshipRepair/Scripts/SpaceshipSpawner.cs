using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipSpawner : MonoBehaviour
{

    [System.Serializable]
    public struct SpaceshipPart
    {
        public GameObject normalPrefab; // 정상 상태 프리팹
        public GameObject brokenPrefab; // 손상 상태 프리팹
        public bool isBroken; // 손상 여부
    }

    [System.Serializable]
    public class SpaceshipBlueprint
    {
        public List<SpaceshipPart> parts;
        public int maxBrokenParts;
    }

    public List<GameObject> spaceshipPrefabs; // 우주선 프리팹 리스트
    public Transform spawnPoint; // 스폰 위치 (옵션)
    public List<SpaceshipBlueprint> spaceshipBlueprints = new List<SpaceshipBlueprint>();
    public Canvas canvas;

    public void SpawnRandomSpaceship()
    {
        // 랜덤 인덱스 생성
        int randomIndex = Random.Range(0, spaceshipPrefabs.Count);

        // 선택된 프리팹 가져오기
        GameObject spaceshipPrefab = spaceshipPrefabs[randomIndex];

        // 스폰 위치 결정 (화면 중앙 기준)
        Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));

        // 우주선 생성 및 로그 남기기
        GameObject newSpaceship = Instantiate(spaceshipPrefab, spawnPosition, Quaternion.identity);
        newSpaceship.transform.SetParent(canvas.transform);
        foreach(var part in spaceshipBlueprints[randomIndex].parts)
        {
            GameObject partInstance = Instantiate(part.isBroken ? part.brokenPrefab : part.normalPrefab, spawnPosition, Quaternion.identity);
            partInstance.transform.SetParent(canvas.transform);
        }
        Debug.Log($"스폰된 우주선: {newSpaceship.name}, 시간: {Time.time}, 위치: {spawnPosition}");
    }
}
