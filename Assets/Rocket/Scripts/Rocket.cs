using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpaceShipRepair;

public class Rocket : MonoBehaviour
{
    [SerializeField] private List<Part> parts;

    private void Awake()
    {
        ChangeRandomCondition(4);
    }

    // true가 리턴되면 모두 고쳐진 상태
    public bool CheckRocketCondition()
    {
        foreach (Part part in parts)
        {
            if (!part.IsFixed)
            {
                Debug.Log("수리 실패");
                return false;
            }
        }
        Debug.Log("수리 성공");
        return true;
    }

    // 랜덤으로 count만큼 고장냄
    public void ChangeRandomCondition(int count)
    {
        HashSet<int> usedIndices = new HashSet<int>();  // 이미 고장난 부품의 인덱스를 추적

        if (count > parts.Count)
        {
            count = parts.Count;
        }

        int attempts = 0;
        while (usedIndices.Count < count && attempts < 100)  // 무한 루프 방지
        {
            int randomIndex = Random.Range(0, parts.Count);

            if (!usedIndices.Contains(randomIndex) && parts[randomIndex].IsFixed)
            {
                parts[randomIndex].IsFixed = false;
                usedIndices.Add(randomIndex);
            }

            attempts++;
        }
    }

    public void TryRepair(string DraggedObject)
    {
        foreach (Part part in parts)
        {
            //Debug.Log("TryRepair Tag: " + DraggedObject + ", Part: " + part.GetPartTag());
            if (part.GetPartTag() == DraggedObject)
            {
                //Debug.Log("Try Repair: " + part.GetPartTag());
                if (!part.IsFixed)
                {
                    //Debug.Log(part.GetPartTag() + "Fixed!!");
                    part.IsFixed = true;
                    part.UpdatePart();
                    break;
                }
            }
        }
    }

    public void DestoryRocket()
    {
        Destroy(gameObject);
    }
}
