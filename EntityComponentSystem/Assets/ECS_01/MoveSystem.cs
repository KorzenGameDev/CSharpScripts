using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class MoveSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation, ref SpeedComponent speedComponent) =>{
            translation.Value.y += speedComponent.moveSpeed * Time.deltaTime;
            if (translation.Value.y > 8f)
                speedComponent.moveSpeed = -math.abs(speedComponent.moveSpeed);
            if (translation.Value.y < -8f)
                speedComponent.moveSpeed = math.abs(speedComponent.moveSpeed);
        });
    }
}
