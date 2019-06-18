using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Rendering;
using Unity.Transforms;
using Unity.Mathematics;
using Unity.Collections;

public class TestECS_02 : MonoBehaviour
{
    [SerializeField] private Material material;

    private EntityManager entityManager;

    private void Start()
    {
        entityManager = World.Active.EntityManager;

        NativeArray<Entity> entityArray = new NativeArray<Entity>(10, Allocator.Temp);
        EntityArchetype entityArchetype = entityManager.CreateArchetype(
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(Translation),
            typeof(Rotation)
            //typeof(Scale)
            //typeof(NonUniformScale)
        );

        entityManager.CreateEntity( entityArchetype, entityArray);

        foreach (Entity entity in entityArray)
        {
            entityManager.SetSharedComponentData(entity, new RenderMesh
            {
                mesh = CreateMesh(1f,1f),
                material = material,
            });

            /*entityManager.SetComponentData(entity, new NonUniformScale
            {
                Value = new float3(1f, 3f, 1f)
            });*/
        }

        entityArray.Dispose();
    }

    private Mesh CreateMesh(float width, float height)
    {
        Vector3[] vertices = new Vector3[4];
        Vector2[] uv = new Vector2[4];
        int[] triangles = new int[6];

        float halfWidth = width / 2;
        float halfHeight = height / 2;


        vertices[0] = new Vector3(-halfWidth, -halfHeight);
        vertices[1] = new Vector3(-halfWidth, +halfHeight);
        vertices[2] = new Vector3(+halfWidth, +halfHeight);
        vertices[3] = new Vector3(+halfWidth, -halfHeight);

        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(0, 1);
        uv[2] = new Vector2(1, 1);
        uv[3] = new Vector2(1, 0);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 3;

        triangles[3] = 1;
        triangles[4] = 2;
        triangles[5] = 3;

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        return mesh;
    }
}


public class MovingSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Translation translation) => {
            float moveSpeed = 1f;
            translation.Value.x += moveSpeed * Time.deltaTime;
        });
    }
}

public class RotateSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Rotation rotation) => {
            rotation.Value = quaternion.Euler(0, 0, math.PI * Time.realtimeSinceStartup);
        });
    }
}

public class ScalerSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        Entities.ForEach((ref Scale scale) => {
            scale.Value += 1f * Time.deltaTime;
        });
    }
}