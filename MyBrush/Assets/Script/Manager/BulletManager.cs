using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{   
	public static BulletManager Instance;
	
	private GameObject PoolingBulletPrefab;
	
	Queue<Bullet> poolingObjectQueue = new Queue<Bullet>();
	
	enum BULLET_TYPE
	{
		  eBullet_Normal = 0
		,
	};
    
    void Awake()
    {
        Instance = this;		
		Initialize(20);
    }
	
	private void Initialize(int _initCount)
	{
		for(int i = 0 ; i < _initCount; ++i)		
			poolingObjectQueue.Enqueue(CreateNewBullet());
		
	}
	
	private Bullet CreateNewBullet()
	{
		var newBullet = Instantiate(PoolingBulletPrefab).GetComponent<Bullet>();
		newBullet.gameobject.SetActive(false);
		newBullet.transform.SetParent(transform);
		
		return newBullet;	
	}   
	
	public static Bullet GetObject(E_BulletType _eBulletType)
    {
        if(Instance.poolingObjectQueue.Count > 0)
        {
            var obj = Instance.poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
			obj.SetBulletType(_eBulletType);
			
            return obj;
        }
        else
        {
            var newObj = Instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
			obj.SetBulletType(_eBulletType);

            return newObj;
        }
    }

    public static void ReturnObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(Instance.transform);		
        Instance.poolingObjectQueue.Enqueue(obj);
    }
}
