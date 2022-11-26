using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plates : MonoBehaviour
{
    [SerializeField] List<GameObject> plates = new List<GameObject>();

    void Start()
    {
        for (var i = 0; i < plates.Count; i += plates.Count / 12)
        {
            var x = Random.Range(i, i + 4);
            OFFplate(x);

        }

    }

    public void OFFplate(int count)
    {
        plates[count].GetComponent<Collider>().isTrigger = true;
    }
  
}
