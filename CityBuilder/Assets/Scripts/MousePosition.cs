using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector3 pos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        transform.position = pos;
    }
}
