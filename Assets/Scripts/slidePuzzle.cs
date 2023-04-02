using UnityEngine;

public class slidePuzzle : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    private int emptySpaceIndex = 15;
    Ray ray;
    RaycastHit hit;

    [SerializeField] private GameObject[] tiles;
    private void Start()
    {
        shuffle();
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
                    int tileIndex = findIndex(hit.transform);
                    tiles[emptySpaceIndex] = tiles[tileIndex];
                    tiles[tileIndex] = null;
                    emptySpaceIndex = tileIndex;
                    
                }
            }
        }
    }

    private void shuffle()
    {
        if (emptySpaceIndex != 15)
        {
            var tileon15 = tiles[15].transform.position;
            tiles[15].transform.position = emptySpace.position;
            emptySpace.position = tileon15;
            tiles[emptySpaceIndex] = tiles[15];
            tiles[15] = null;
            emptySpaceIndex = 15;
        }

        int invertion;
        do
        {
            for (int i = 0; i <= 14; i++)
            {
                var lastPos = tiles[i].transform.position;
                int randomSpot = Random.Range(0, 14);
                tiles[i].transform.position = tiles[randomSpot].transform.position;
                tiles[randomSpot].transform.position = lastPos;
                var tile = tiles[i];
                tiles[i] = tiles[randomSpot];
                tiles[randomSpot] = tile;
            }

            invertion = GetInversions();
        } while (invertion % 2 != 0);
        
    }
    public int findIndex(Transform tile)
    {
        for (int i = 0; i<tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i].transform == tile)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    int GetInversions()
    {
        int inversionsSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if (tiles[j] != null)
                {
                    
                    if (tiles[i].GetComponent<tileScript>().number > tiles[j].GetComponent<tileScript>().number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionsSum += thisTileInvertion;
        }
        return inversionsSum;
    }
}


