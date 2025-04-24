using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/****************************************************************\
 *                     ������ ���� ObjectPool                   *
\****************************************************************/

/*
 * <������Ʈ Ǯ ����>
 * ���α׷� ������ ����ϰ� ��Ȱ���ϴ� �ν��Ͻ����� Ǯ�� ������ ��
 * �ν��Ͻ��� ����&���� ��� �뿩&�ݳ��� ����ϴ� ���
 * 
 * 
 * <����>
 * 1. �ν��Ͻ����� ������ Ǯ�� ����
 * 2. ���α׷��� ���۽� Ǯ�� �ν��Ͻ����� �����Ͽ� ����
 * 3. �ν��Ͻ� ������ �ʿ��� �� Ǯ���� �뿩�Ͽ� ���
 * 4. �ν��Ͻ� ������ �ʿ��� �� Ǯ�� �ݳ��Ͽ� ���� 
 * 
 * <����>
 * 1. ����ϰ� ����ϴ� �ν��Ͻ� ������ �ҿ�Ǵ� ������带 ����
 * 2. ����ϰ� ����ϴ� �ν��Ͻ� ������ �δ�Ǵ� ������ �ݷ����� ������ ����
 * 
 * <������>
 * 1. �̸� �����س��� �ν��Ͻ����� ������� �ʴ� ��쿡�� �޸𸮸� �����ϰ� ����
 * 2. ������Ʈ Ǯ�� �������� ���������� �پ��� ������ ���α׷��� �δ��� �Ǵ� ��찡 ����
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
