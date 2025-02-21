using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject foodPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(new(Camera.main.pixelWidth / 2, Camera.main.pixelHeight / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(foodPrefab, hit.point, Quaternion.identity);
            }
        }
    }
}
