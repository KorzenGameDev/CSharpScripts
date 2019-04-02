using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [SerializeField]private Color hoverColor;
    [SerializeField]private Vector3 positionOffset;

    new private Renderer renderer;
    private Color startColor;

    private GameObject turret;
    private BuildMenager buildMenager;
    private ShopMenager shop;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        startColor = renderer.material.color;

        buildMenager = BuildMenager.buildMenager;
        shop = FindObjectOfType<ShopMenager>();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildMenager.GetTurretToBild() == null)
            return;

        if (turret != null)
            return;

        if (!shop.IsBuy())
            return;

        GameObject turretToBuild = buildMenager.GetTurretToBild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position+positionOffset, transform.rotation);
    }

    private void OnMouseEnter()
    {

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildMenager.GetTurretToBild() == null)
            return;

        renderer.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        renderer.material.color = startColor;
    }

}