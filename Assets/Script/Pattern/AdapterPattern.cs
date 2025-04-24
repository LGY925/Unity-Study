using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



/****************************************************
 *              ������ ���� Adapter                 *
 ****************************************************/

/*
 * <����� ����>
 * ȣȯ���� ���� �� ��ü�� ������ �� �ֵ��� �߰� �Ű�ü�� �����ϴ� ����
 * 
 * <����>
 * 1. ȣȯ���� �ʴ� �� ��ü ���̿� ����� �߰� ��ü�� ����
 * 2. ����� ��ü�� �� ��ü ������ ��ȣ�ۿ� ����� ���
 * 
 * <����>
 * 1. ������ �ڵ带 �������� �ʰ� ������ �����ϹǷ� ������� ��Ģ�� �ؼ���
 * 2. Ŭ�������� ��ȣ�ۿ뿡 ���� ���踦 ����͸� ���� �������� ������ �� �����Ƿ� ������������ ��Ģ�� �ؼ���
 * 
 * <������>
 * 1. �������̽��� ���� �������� �����Ƿ� �������̽��� �������� ���� �� �ִ� �������� ���� ����
 */
namespace Patten
{
    public class DamageAdapter : MonoBehaviour, IDamgable
    {
        public UnityEvent<GameObject, int> OnDamaged;
        public void TakeDamage(GameObject dealer, int damage)
        {
            OnDamaged?.Invoke(dealer, damage);
        }
    }
    public class InteractAdapter : MonoBehaviour, IInteractable
    {
        public UnityEvent OnInteracted;
        public void Interact()
        {
            OnInteracted.Invoke();
        }
    }

    public interface IDamgable
    {
        public GameObject gameObject { get; }
        public void TakeDamage(GameObject dealer, int damage);

    }

    public interface IInteractable
    {
        public void Interact();

    }

    public class DollarCustomer
    {
        public Exchanger exchanger;

        public void Buy()
        {
            // ���� ����
            exchanger.Change();
        }
    }

    public class KRWStore
    {
        public Exchanger exchanger;

        public void Sell()
        {
            // ���� �Ǹ�
        }
    }

    public class Exchanger
    {
        public DollarCustomer customer;
        public KRWStore store;

        public void Change()
        {
            store.Sell();
        }
    }

}

