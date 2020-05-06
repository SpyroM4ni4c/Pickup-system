using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{

	public Transform m_thedest;
	float m_distanceToObject = 2f;
	public float m_throwForce = 10f;
	public Rigidbody rb;
	public Transform m_cam;
	public GameObject m_CurrentText;
	public static bool m_Image = false;
	public float sphereradius = 2f;
	




	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		
		
	}

	private void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.R))
		{
			GetComponent<Rigidbody>().AddForce(m_cam.forward * m_throwForce);
			GetComponent<Rigidbody>().useGravity = true;
			 OnMouseUp();
		}

		
	}



	// Start is called before the first frame update

	private void OnMouseDown()
	{
		Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);
		if (Physics.Raycast(m_thedest.transform.position, m_thedest.transform.forward, m_distanceToObject))
		{
			if (sphereradius <= 1f)
			{
				//GetComponent<BoxCollider>().enabled = false;
				GetComponent<Rigidbody>().useGravity = false;
				
				this.transform.position = m_thedest.position;
				this.transform.parent = GameObject.Find("PickUpDestination").transform;

				if (Input.GetMouseButtonUp(1))
				{
					GetComponent<Rigidbody>().AddForce(m_thedest.forward * m_throwForce);
				}

				if (Input.GetKeyDown(KeyCode.E))
				{
					m_CurrentText.SetActive(true);
				}
				m_CurrentText.SetActive(false);
			}
			
		}

		
		
		
	}

	private void OnMouseUp()
	{
		this.transform.parent = null;
		GetComponent<Rigidbody>().useGravity = true;
		//GetComponent<BoxCollider>().enabled = true;
	}

	private void OnDrawGizmos()
	{
		Gizmos.DrawSphere(transform.position, 2f);
	}




}
