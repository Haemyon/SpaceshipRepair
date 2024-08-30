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

    // true�� ���ϵǸ� ��� ������ ����
    public bool CheckRocketCondition()
    {
        foreach (Part part in parts)
        {
            if (!part.IsFixed)
            {
                Debug.Log("���� ����");
                return false;
            }
        }
        Debug.Log("���� ����");
        return true;
    }

    // �������� count��ŭ ���峿
    public void ChangeRandomCondition(int count)
    {
        HashSet<int> usedIndices = new HashSet<int>();  // �̹� ���峭 ��ǰ�� �ε����� ����

        if (count > parts.Count)
        {
            count = parts.Count;
        }

        int attempts = 0;
        while (usedIndices.Count < count && attempts < 100)  // ���� ���� ����
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
