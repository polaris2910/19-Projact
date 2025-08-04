using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1 : BaseStage
{
    public override float spawnInterval => 3f;

    public override List<int> objectDataList => new List<int> { 2, 3, 1, 3, 3, 1, 4, 0, 0, 4, 3, 4, 2, 0, 1, 2,
            0, 3, 3, 0, 2, 4, 0, 2, 1, 1, 1, 1, 1, 2, 0, 0, 0, 3, 0, 1, 1, 3, 2, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1 };


}
