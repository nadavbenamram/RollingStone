using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {
    [SerializeField] float m_MovingSpeed = 5f;

    // Use this for initialization
    void Start () {
        setGameObject();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position += transform.forward * Time.deltaTime * m_MovingSpeed;
    }

    void setGameObject()
    {
        int rand = Random.Range(0, 4);

        transform.GetChild(rand).gameObject.SetActive(true);
        transform.GetChild(rand).localPosition = getPositionByChildIndex(rand);
    }

    private Vector3 getPositionByChildIndex(int childIndex)
    {
        Vector3 newPosition;

        switch (childIndex)
        {
            case 0:
                newPosition = getPlace(-2f, 2f, 0.1627198f, -4f, 1f);
                break;
            case 1:
                newPosition = getPlace(-4f, 4f, -0.163903f, -4f, 4f);
                break;
            case 2:
                newPosition = getPlace(0f, 0f, -0.2339034f, -4f, 4f);
                break;
            case 3:
            default:
                newPosition = getPlace(-4f, 4f, 0.574908f, -4f, 4f);
                break;
        }

        return newPosition;
    }

    private Vector3 getPlace(float minX, float maxX, float y, float minZ, float maxZ)
    {
        return new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));
    }
}
