using UnityEngine;

public class PreLoadManager : SingletonMono<PreLoadManager>
{
    void Awake()
    {
        instance = this;
    }

    void Update()
    {

    }
}
