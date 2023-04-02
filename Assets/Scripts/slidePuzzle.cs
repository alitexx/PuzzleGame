using UnityEngine;

public class slidePuzzle : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    Ray ray;
    RaycastHit hit;
    private void Start()
    {
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 5f))
            {
                if (Vector3.Distance(emptySpace.position, hit.transform.position) <= 0.51)
                {
                    Vector3 lastEmptySpacePos = emptySpace.position;
                    emptySpace.position = hit.transform.position;
                    hit.transform.position = lastEmptySpacePos;
                }
            }
        }
    }
}


