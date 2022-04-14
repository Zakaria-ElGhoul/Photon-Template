using UnityEngine;
using UnityEngine.AI;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour 
{
    NavMeshAgent agent;
    PhotonView photonView;
    public float rotateSpeedMovement = 0.075f; 
    float rotateVelocity;

    private void Start() 
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        photonView = gameObject.GetComponent<PhotonView>();
    } 
    
    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);

                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                    float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref rotateVelocity,
                rotateSpeedMovement * (Time.deltaTime * 1));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
        }
    }
}