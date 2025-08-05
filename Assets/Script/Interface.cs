using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConsumable
{
    public void Eat(ResourceManager resourceManager);

}

public interface IDeletable
{
    public void DisableObject();

}

