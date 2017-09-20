using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlaneController : MonoBehaviour {
	private const int NUM_OF_OBJECTS = 4;

	[SerializeField] private float m_MovingSpeed = 5f;
	private RandomPlace m_RandomPlace;

	// Use this for initialization
	void Start () {
		m_RandomPlace = new RandomPlace ();
		setGameObject();
	}

	// Update is called once per frame
	void Update ()
	{
		transform.position += transform.forward * Time.deltaTime * m_MovingSpeed;
	}

	void setGameObject()
	{
		int rand = Random.Range(0, NUM_OF_OBJECTS);

		transform.GetChild(rand).gameObject.SetActive(true);
		transform.GetChild(rand).localPosition = m_RandomPlace.GetPlace (rand);
	}

	private class RandomPlace
	{
		List<Place> m_Places;

		public RandomPlace()
		{
			initPlaces();
		}

		private void initPlaces()
		{
			m_Places = new List<Place>();

			m_Places.Add (new Place (-2f, 2f, 0.1627198f, -4f, 1f));
			m_Places.Add (new Place (-4f, 4f, -0.163903f, -4f, 4f));
			m_Places.Add (new Place (0f, 0f, -0.2339034f, -4f, 4f));
			m_Places.Add (new Place (-4f, 4f, 0.574908f, -4f, 4f));
		}

		public Vector3 GetPlace(int i_Idx)
		{
			if (i_Idx < m_Places.Count) {
				Place place = m_Places[i_Idx];

				return new Vector3(Random.Range(place.minX, place.maxX), place.y, Random.Range(place.minZ, place.maxZ));
			}

			return Vector3.zero;
		}

		private struct Place
		{
			public float minX;
			public float maxX;
			public float y;
			public float minZ;
			public float maxZ;

			public Place(float i_MinX, float i_MaxX, float i_Y, float i_MinZ, float i_MaxZ)
			{
				minX = i_MinX;
				maxX = i_MaxX;
				y = i_Y;
				minZ = i_MinZ;
				maxZ = i_MaxZ;
			}
		}
	}
}
