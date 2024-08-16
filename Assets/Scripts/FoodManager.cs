using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FoodManager : MonoBehaviour
{
    public GameObject[] foods;
    
    public int number = 50;
    
    public bool useObjectPool;
<<<<<<< HEAD
    public bool useSelf;
=======
>>>>>>> 5989ff2e6a0463b93b9d73e4e3bf34a1b9af819d

    private ObjectPool<GameObject> foodPool;
    // Start is called before the first frame update
    void Start()
    {
        foodPool = new ObjectPool<GameObject>(() =>
        {
            var food = Instantiate(foods[Random.Range(0, foods.Length)], transform);
                //food.transform.localPosition = Random.insideUnitSphere;
            food.AddComponent<Food>().destroyEvent.AddListener(() =>
            {
                foodPool.Release(food);
            });
            return food;
        },
            go =>
        {
            go.SetActive(true);
            go.transform.localPosition = Random.insideUnitSphere;
        },
            go =>
        {
            go.SetActive(false);
        }, 
            go => {Destroy(go);});
    }

    // Update is called once per frame
    void Update()
    {
        if(useObjectPool)
        {
            for(int i = 0; i < number; i++)
            {
                foodPool.Get();
            }
        }
<<<<<<< HEAD
        else if(useSelf)
        {
            for (int i = 0; i < number; i++)
            {
                bool isFirst = false;
                GameObject food = ChunkAllocator.Instance.GetGameObject("food pool",
                    foods[Random.Range(0, foods.Length)], out isFirst, transform);
                food.transform.localPosition = Random.insideUnitSphere;
                if (isFirst)
                {
                    //添加食物脚本并注册销毁事件
                    food.AddComponent<Food>().destroyEvent.AddListener(() =>
                    {
                        ChunkAllocator.Instance.Revert("food pool",food);
                    });
                }
            }
        }
        else 
=======
        else
>>>>>>> 5989ff2e6a0463b93b9d73e4e3bf34a1b9af819d
        {
            for (int i = 0; i < number; i++)
            {
                var food = Instantiate(foods[Random.Range(0, foods.Length)], transform);
                food.transform.localPosition = Random.insideUnitSphere;
<<<<<<< HEAD
                //添加食物脚本并注册销毁事件
=======
>>>>>>> 5989ff2e6a0463b93b9d73e4e3bf34a1b9af819d
                food.AddComponent<Food>().destroyEvent.AddListener(() =>
                {
                    Destroy(food);
                });
            }
        }
        
    }
}
