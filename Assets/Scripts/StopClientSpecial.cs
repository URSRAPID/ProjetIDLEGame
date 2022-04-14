using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StopClientSpecial : MonoBehaviour
{
    UnityEvent<ClientSpecialMove> _onEnterClientSpecial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddListenerClientSpecial(UnityAction<ClientSpecialMove> metodSpecial)
    {
        if (_onEnterClientSpecial == null)
        {
            _onEnterClientSpecial = new UnityEvent<ClientSpecialMove>();
        }
        _onEnterClientSpecial.AddListener(metodSpecial);
    }

    private void OnTriggerEnter2D(Collider2D collisionSpecial)
    {

        if (collisionSpecial.transform.CompareTag("ClientSpecial"))
        {

            _onEnterClientSpecial.Invoke(collisionSpecial.GetComponent<ClientSpecialMove>());

        }

    }
}
