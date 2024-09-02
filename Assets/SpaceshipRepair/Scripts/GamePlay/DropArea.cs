using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceShipRepair
{
    public class DropArea : MonoBehaviour, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            // ��ӵ� ������Ʈ�� ������ ����
            GameObject droppedObject = eventData.pointerDrag;

            if (droppedObject != null)
            {
                //Debug.Log(droppedObject.name + "��(��) �巡�� ������ ��ӵǾ����ϴ�!");
                //Debug.Log("Tag: " + droppedObject.tag);
                // �ʿ��� ���� �߰� ���� (��: ��ӵ� ������Ʈ�� Ư�� ��ġ�� �̵�)
                AudioManager.Instance.PlaySFX("Parts_Drop");
                FindObjectOfType<Rocket>().TryRepair(droppedObject.tag);
                FindObjectOfType<TimerAndScore>().RepairTry();
            }
        }
    }
}