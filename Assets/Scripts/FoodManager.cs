using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FoodManager : MonoBehaviour
{
    public GameObject[] foods;
    
    public int number = 50;
    
    public bool useObjectPool;

    public bool useSelf;


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
        {
            for (int i = 0; i < number; i++)
            {
                var food = Instantiate(foods[Random.Range(0, foods.Length)], transform);
                food.transform.localPosition = Random.insideUnitSphere;

                //添加食物脚本并注册销毁事件
                food.AddComponent<Food>().destroyEvent.AddListener(() =>
                {
                    Destroy(food);
                });
            }
        }
        
    }
}
