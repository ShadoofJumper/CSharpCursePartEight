using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PlayerManager))]
[RequireComponent(typeof(InventoryManager))]


public class Manager : MonoBehaviour
{
    public static PlayerManager player { get; private set; }
    public static InventoryManager inventory { get; private set; }

    private List<IGameManager> _startSequence; // all manager (dispatcher) 

    void Awake()
    {
        player = GetComponent<PlayerManager>();
        inventory = GetComponent<InventoryManager>();

        _startSequence = new List<IGameManager>();
        _startSequence.Add(player);
        _startSequence.Add(inventory);
        StartCoroutine(StartupManager());
    }

    private IEnumerable StartupManager()
    {
        foreach (IGameManager manager in _startSequence)
        {
            manager.Startup();
        }

        yield return null;

        int numModules = _startSequence.Count;
        int numReady = 0;

        while (numReady < numModules) // working untill all of manager will be working
        {
            //save start count of reeady manager each iteration
            int lastReady = numReady;
            numReady = 0;
            //then count ready
            foreach (IGameManager manager in _startSequence)
            {
                if (manager.status == ManagerStatus.Started)
                {
                    numReady++;
                }
            }
            //if ready bigger then last info then print info in console
            if (numReady > lastReady)
            {
                Debug.Log("Progress: "+numReady +"/"+numModules);
                yield return null;
            }

            Debug.Log("All manager started up");

        }
    }

}
