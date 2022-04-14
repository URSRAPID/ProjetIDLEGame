using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Waiting : MonoBehaviour
{
    UnityEvent<ClientMove> _onEnter;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddListener(UnityAction<ClientMove> method )
    {
        if (_onEnter == null)
        {
            _onEnter = new UnityEvent<ClientMove>();
        }
        _onEnter.AddListener(method);
       
    }
 



    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.transform.CompareTag("Player"))
        {
            _onEnter.Invoke(collision.GetComponent<ClientMove>());
            
        }
        if (collision.transform.CompareTag("ClientSpecial"))
        {
            _onEnter.Invoke(collision.GetComponent<ClientMove>());

        }

    }
   

}
