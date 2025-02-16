using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject[] wayPoints;
    public Rigidbody enemyRigibody;
    private int currentTargetIndex = 0;
    private bool hasTarget = false;
    private Vector3 movement = new Vector3();
    private float maxSpeed = 30f;
    private float currentSpeed = 0f;
    private float acceleration = 1.5f;

    private void Start()
    {
        enemyRigibody = GetComponent<Rigidbody>();
        if (wayPoints.Length > 0)
        {
            hasTarget = true;
        }
    }

    private void Update()
    {
        if (hasTarget)
        {
            MoveTowardsTarget();
        }
    }

    public void MoveTowardsTarget()
    {
        Vector3 nextPointPosition = wayPoints[currentTargetIndex].transform.position;
        Vector3 directionToTarget = (nextPointPosition - enemyRigibody.position).normalized;
        currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime * acceleration);
        Vector3 newPosition = enemyRigibody.position + directionToTarget * currentSpeed * Time.deltaTime;
        enemyRigibody.MovePosition(newPosition);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Spot"))
        {
            hasTarget = true;
        }
    }
}
