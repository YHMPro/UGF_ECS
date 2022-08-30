using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{


    public List<int> num = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<10;i++)
        {
            num.Add(i);
        }
    }
    bool removeElement;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            removeElement = true;
            num.RemoveAt(0);
        }
        if(!removeElement)
        {
            foreach (int i in num)
            {
                Debug.Log(i);
            }
        }
        removeElement = false;
    }
}
