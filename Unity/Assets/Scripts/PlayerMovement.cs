using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private Transform moveDestinationTransform;
    [SerializeField] Camera camera;
    [SerializeField] GameObject sphere;
    private NavMeshAgent navMeshAgent;
    private InputActions inputActions;
    public Vector2 mousePositionV2;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //camera = GetComponent<Camera>();
        inputActions = new InputActions();
        inputActions.PlayerActionMap.Enable();
        //mousePosition = inputActions.PlayerActionMap.MousePosition.ReadValue<Vector3>();


    }

    void Update()
    {
        navMeshAgent.destination = sphere.transform.position;
        mousePositionV2 = inputActions.PlayerActionMap.MousePosition.ReadValue<Vector2>();
    }

    public void moveCharacter()
    {
        var ray = camera.ScreenPointToRay(mousePositionV2);
        RaycastHit raycastHit;

        if(Physics.Raycast(ray, out raycastHit))
        {
            print($"Atingiu {raycastHit.transform.name} em {raycastHit.point}");
            sphere.transform.position = raycastHit.point;
        }
    }
}
