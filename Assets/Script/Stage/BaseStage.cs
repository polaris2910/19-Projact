using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseStage : MonoBehaviour
{

    public abstract float spawnInterval { get; }
    public abstract List<int> objectDataList { get; }
    public virtual Color backgroundColor { get; } = Color.white;

    protected abstract Stage GetStageState();

    
}
