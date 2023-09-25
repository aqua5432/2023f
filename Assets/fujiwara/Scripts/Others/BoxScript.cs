using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private RightButtonScript RBS;
    static int stagenumber = 1;
    public int st
    {
        get { return stagenumber; }
        set { stagenumber = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        stagenumber = st;
    }

    // Update is called once per frame
    void Update()
    {
        this.RBS = FindObjectOfType<RightButtonScript>();
        st = RBS.RSN;

      if (st == 1)
        {
            transform.position = new Vector3(400, 406, 0);
        }
      else if (st == 2)
        {
            transform.position = new Vector3(680, 406, 0);
        }
      else
        {
            transform.position = new Vector3(960, 406, 0);
        }
    }
}
