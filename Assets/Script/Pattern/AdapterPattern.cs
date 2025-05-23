using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



/****************************************************
 *              디자인 패턴 Adapter                 *
 ****************************************************/

/*
 * <어댑터 패턴>
 * 호환되지 않은 두 객체를 협업할 수 있도록 중간 매개체를 구현하는 패턴
 * 
 * <구현>
 * 1. 호환하지 않는 두 객체 사이에 어댑터 중간 객체를 구현
 * 2. 어댑터 객체는 두 객체 사이의 상호작용 방법을 기술
 * 
 * <장점>
 * 1. 기존의 코드를 변경하지 않고 적용이 가능하므로 개방폐쇄 원칙이 준수됨
 * 2. 클래스간의 상호작용에 대한 설계를 어댑터를 통해 상위모듈로 구현할 수 있으므로 의존성역전의 원칙이 준수됨
 * 
 * <주의점>
 * 1. 인터페이스를 직접 포함하지 않으므로 인터페이스를 가짐으로 얻을 수 있는 가독성을 얻지 못함
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
            // 물건 구매
            exchanger.Change();
        }
    }

    public class KRWStore
    {
        public Exchanger exchanger;

        public void Sell()
        {
            // 물건 판매
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

