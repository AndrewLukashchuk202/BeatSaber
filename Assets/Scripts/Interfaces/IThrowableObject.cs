using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Abstract
{
    public interface IThrowableObject : IAnimEventExecute
    {
        GameObject ProjectilePrefab { get; set; }
        GameObject Socket { get; set; }        
        GameObject Target { get; set;}

        float ThrowForce { get; set; }
        float MaxSpread { get; set; }
        
        void Throw();
    }
}
