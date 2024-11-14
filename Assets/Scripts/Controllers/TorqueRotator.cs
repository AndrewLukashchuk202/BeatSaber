using UnityEngine; 

namespace Assets.Scripts
{
    internal class TorqueRotator: MonoBehaviour
    {
        public float _torqueRotationMin = -200;
        public float _torqueRotationMax = 200;

        public Rigidbody _rigidBodyRef;


        public void Start()
        {
            //Add a torque to the object to rotate it in a random rotation.
            Vector3 torque = new(Random.Range(_torqueRotationMin, _torqueRotationMax),
                                 Random.Range(_torqueRotationMin, _torqueRotationMax),
                                 Random.Range(_torqueRotationMin, _torqueRotationMax));

            if (_rigidBodyRef != null ) 
            {
                _rigidBodyRef.AddRelativeTorque(torque, ForceMode.Force);
            }            
        }
    }
}
