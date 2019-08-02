using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameMnager
{
    ManagerStatus status { get; }

    void Startup();
}
