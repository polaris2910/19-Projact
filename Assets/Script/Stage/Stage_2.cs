using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_2 : BaseStage
{
    public override float spawnInterval => 2f;

    public override List<int> objectDataList => new List<int> { 2, 2, 3, 1, 1, 2, 0, 4, 2, 1, 3, 3, 3, 4, 2, 1, 1, 2, 4, 3, 3, 2, 2, 3, 1, 2, 3, 4, 2, 3, 3, 1,5 };

   

    protected override Stage GetStageState()
    {
        return Stage.Stage_2;
    }
}



