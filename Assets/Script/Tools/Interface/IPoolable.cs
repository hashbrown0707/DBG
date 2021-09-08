using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public interface IPoolable
    {
        void OnDespawned();
        void OnSpawned();
    }

    public interface IPoolable<TParam1>
    {
        void OnDespawned();
        void OnSpawned(TParam1 p1);
    }

    public interface IPoolable<TParam1, TParam2>
    {
        void OnDespawned();
        void OnSpawned(TParam1 p1, TParam2 p2);
    }

    public interface IPoolable<TParam1, TParam2, TParam3>
    {
        void OnDespawned();
        void OnSpawned(TParam1 p1, TParam2 p2, TParam3 p3);
    }

    public interface IPoolable<TParam1, TParam2, TParam3, TParam4>
    {
        void OnDespawned();
        void OnSpawned(TParam1 p1, TParam2 p2, TParam3 p3, TParam4 p4);
    }
}
