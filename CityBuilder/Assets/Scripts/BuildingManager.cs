using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    private GameObject pendingObject;

    private Vector3 pos;
    
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;

    private void Update()
    {
        if (pendingObject != null)
        {
            pendingObject.transform.position = pos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            PlaceObject();
        }
    }
    
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layerMask))
        {
            pos = hit.point;
        }
    }

    public void PlaceObject()
    {
        pendingObject = null;
    }
    
    public void SelectObject(int index)
    {
        pendingObject = Instantiate(objects[index], pos, Quaternion.identity);
    }
}
