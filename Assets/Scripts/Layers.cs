using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class Layers : MonoBehaviour
{
    [SerializeField]
    private GameObject Layer;
    
    [SerializeField]
    private float angleStep;

    [SerializeField]
    private int LayerAmount;
    
    [SerializeField]
    private float platformHeight;

    public Material badMaterial;
    public Material GoodMaterial;
   
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < LayerAmount; i++)
        {
            var newObj=  Instantiate(Layer, Vector3.up * -platformHeight * i, Quaternion.Euler(0, angleStep * i, 0), transform);

            int childCount = newObj.transform.childCount;
            for (int j = childCount - 1; j >= 0; j--)
            {
                var child = newObj.transform.GetChild(j).gameObject;
                child.tag = "Good";
                child.GetComponent<Renderer>().sharedMaterial = GoodMaterial;
            }

            if (Random.Range(0, 100) < 15)
            {
                int randChild = Random.Range(0, childCount);
                for (int j = childCount - 1; j >= 0; j--)
                {
                    if (j == randChild)
                    {
                        continue;
                    }

                    var child = newObj.transform.GetChild(j).gameObject;
                    child.tag = "Bad";
                    child.GetComponent<Renderer>().sharedMaterial = badMaterial;
                }
            }
        }
    }
    
    private void Update()
    {
        transform.Rotate(Vector3.up * 20 * Time.deltaTime);
    }
}
