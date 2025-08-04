using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1 : BaseStage
{
    public override float spawnInterval => 3f;

    Color stage1Color = Color.white;
    public override List<int> objectDataList => new List<int> { 1, 2, 3, 1, 4, 0, 0, 4, 3, 0, 1, 0, 2, 1, 0, 0, 5 };



    public override Color backgroundColor => stage1Color;
    protected override Stage GetStageState()
    {
        return Stage.Stage_1;
    }

}
