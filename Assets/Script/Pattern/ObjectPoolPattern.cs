using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/****************************************************************\
 *                     디자인 패턴 ObjectPool                   *
\****************************************************************/

/*
 * <오브젝트 풀 패턴>
 * 프로그램 내에서 빈번하게 재활용하는 인스턴스들을 풀에 보관한 뒤
 * 인스턴스의 생성&삭제 대신 대여&반납을 사용하는 기법
 * 
 * 
 * <구현>
 * 1. 인스턴스들을 보관할 풀을 생성
 * 2. 프로그램의 시작시 풀에 인스턴스들을 생성하여 보관
 * 3. 인스턴스 생성이 필요할 때 풀에서 대여하여 사용
 * 4. 인스턴스 삭제가 필요할 때 풀에 반납하여 보관 
 * 
 * <장점>
 * 1. 빈번하게 사용하는 인스턴스 생성에 소요되는 오버헤드를 줄임
 * 2. 빈번하게 사용하는 인스턴스 삭제에 부담되는 가비지 콜렉터의 동작을 줄임
 * 
 * <주의점>
 * 1. 미리 생성해놓은 인스턴스들이 사용하지 않는 경우에도 메모리를 차지하고 있음
 * 2. 오브젝트 풀을 힙영역의 여유공간이 줄어들어 오히려 프로그램에 부담이 되는 경우가 있음
 */
namespace Patten
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] List<PooledObject> pool = new List<PooledObject>();
        [SerializeField] PooledObject prefab;
        [SerializeField] int size;

        private void Awake()
        {
            for (int i = 0; i < size; i++)
            {
                PooledObject instance = Instantiate(prefab);
                instance.gameObject.SetActive(false);
                pool.Add(instance);
            }

        }
        public PooledObject GetPool(Vector3 position, Quaternion rotation)
        {
            if (pool.Count == 0)
            {
                return Instantiate(prefab, position, rotation);
            }
            PooledObject instance = pool[pool.Count - 1];
            pool.RemoveAt(pool.Count - 1);

            instance.returnPool = this;
            instance.transform.position = position;
            instance.transform.rotation = rotation;
            instance.gameObject.SetActive(true);

            return instance;
        }
        public void ReturnPool(PooledObject instance)
        {
            instance.gameObject.SetActive(false);
            pool.Add(instance);
        }
    }
    public class PooledObject : MonoBehaviour
    {
        public ObjectPool returnPool;
        [SerializeField] float returnTime;
        private float timer;

        private void OnEnable()
        {
            timer = returnTime;
        }
        private void Update()
        {
            timer -= Time.deltaTime;
            if (timer < 0)
            {
                ReturnPool();
            }
        }

        public  void ReturnPool()
        {
            if (returnPool == null)
            {
                Destroy(gameObject);
            }
            else
            {
                returnPool.ReturnPool(this);
            }
        }

    }

}
