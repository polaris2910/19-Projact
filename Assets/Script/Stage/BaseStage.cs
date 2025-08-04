using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStage : MonoBehaviour
{

    public abstract float spawnInterval { get; }
    public abstract List<int> objectDataList { get; }
    public virtual Sprite backgroundSprite { get; }

    protected abstract Stage GetStageState();

    
}
