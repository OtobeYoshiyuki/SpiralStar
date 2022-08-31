using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappeyStar : BlackStar
{
    // Start is called before the first frame update
    void Start()
    {
        //初期化処理
        StarInit();
    }

    // Update is called once per frame
    void Update()
    {
        //更新処理
        StarUpdate();
    }
}
