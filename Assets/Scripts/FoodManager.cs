using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FoodManager : MonoBehaviour
{
    public GameObject[] foods;
    
    public int number = 50;
    
    public bool useObjectPool;

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
        else
        {
            for (int i = 0; i < number; i++)
            {
                var food = Instantiate(foods[Random.Range(0, foods.Length)], transform);
                food.transform.localPosition = Random.insideUnitSphere;
                food.AddComponent<Food>().destroyEvent.AddListener(() =>
                {
                    Destroy(food);
                });
            }
        }
        
    }
}
