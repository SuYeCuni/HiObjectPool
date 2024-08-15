using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject[] foods;
    
    public int number = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
