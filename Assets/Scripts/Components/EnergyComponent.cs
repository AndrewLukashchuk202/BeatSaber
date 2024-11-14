using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnergyComponent : MonoBehaviour
{
    UnityEvent OnEmpty;
    UnityEvent OnStep;
    UnityEvent OnFull;

        
    [SerializeField] private float energy = 100;
    [SerializeField] private float maxEnergy = 100;
    [SerializeField] private float energyStep = 10;
    [SerializeField] private float energyStepDelay = 1;
    [SerializeField] private bool enableRegen = true;

    public float GetEnergy { get => energy; }
    public void SetRegenState(bool enabled)
    {
        enableRegen = enabled;
    }

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            if (enableRegen)
            {
                Step();
            }            
        }
    }

    public bool Step()
    {
        if (energy >= maxEnergy)
        {
            return false;
        }

        energy = Mathf.Clamp(energy + energyStep, 0, maxEnergy);

        OnStep?.Invoke();

        if (energy == maxEnergy)
        {
            OnFull?.Invoke();
        }
        return true;
    }

}
