using Assets.Scripts.Abstract;
using UnityEngine;

public class ThrowObject : MonoBehaviour, IThrowableObject 
{
    [field: SerializeField]
    public GameObject ProjectilePrefab { get; set; }
    [field: SerializeField]
    public GameObject Socket { get; set; }
    [field: SerializeField]
    public GameObject Target { get; set; }
    [field: SerializeField]
    public float ThrowForce { get; set; }
    [field: SerializeField]
    public float MaxSpread { get; set; }

    public void Execute()
    {
        Throw();
    }

    public void Throw()
    {
        GameObject projectile = Instantiate(ProjectilePrefab, Socket.transform.position, Quaternion.identity);

        Rigidbody projectileRigidBody = projectile.GetComponent<Rigidbody>();

        //Divergence from the original trajectory to add variance for the aim of the thrown object
        float xSpread = Random.Range(-MaxSpread, MaxSpread);
        float ySpread = Random.Range(-MaxSpread, MaxSpread);
        float zSpread = Random.Range(-MaxSpread, MaxSpread);
        Vector3 spreadVector = new(xSpread, ySpread, zSpread);

        // Get the direction towards the target        
        Vector3 dir = (Target.transform.position - Socket.transform.position).normalized;

        // Move the object forward from the launch point (rockAttachSocket) 
        Vector3 forceToAdd = (spreadVector + dir) * (ThrowForce * 100);
        projectileRigidBody.AddForce(forceToAdd);
    }
}
