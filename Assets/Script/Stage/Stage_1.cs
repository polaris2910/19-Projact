using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_1 : BaseStage
{
    public override float spawnInterval => 3f;

    Color stage1Color = new Color(255f / 255f, 116f / 255f, 123f / 255f);
    public override List<int> objectDataList => new List<int> { 2, 3, 1, 3, 3, 1, 4, 0, 0, 4, 3, 
            0, 3, 0, 1, 4, 0, 2, 1, 1,2,3,0,0,5 };


    public override Color backgroundColor => stage1Color;
    protected override Stage GetStageState()
    {
        return Stage.Stage_1;
    }

}
