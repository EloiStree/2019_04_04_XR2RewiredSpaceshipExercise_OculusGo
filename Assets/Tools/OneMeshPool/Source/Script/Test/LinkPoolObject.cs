using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkPoolObject : MonoBehaviour {

    public string _poolIdName="Default";
    public OneMeshPool _linkedPool;
    public PoolObject _linkedObject;
    public bool m_useParentScale;
    void Start ()
    {
        if(_linkedPool==null)
          _linkedPool = OneMeshPool.GetPool(_poolIdName);
        if (_linkedPool != null) { 
            _linkedObject = _linkedPool.Next(true,true);
            if (_linkedObject != null)
            {
                _linkedObject.transform.parent = this.transform;
                _linkedObject.transform.localPosition = Vector3.zero;
                _linkedObject.transform.localScale =  this.transform.localScale;
                return;
            }
        }
        Destroy(this.gameObject);
	}

    private Vector3 Multiply(Vector3 localScale1, Vector3 localScale2)
    {
        localScale1.x *= localScale2.x;
        localScale1.y *= localScale2.y;
        localScale1.z *= localScale2.z;
        return localScale1;
    }

    // Update is called once per frame
    void OnDestroy () {
        if (_linkedObject) {

            _linkedObject.transform.parent = null;
            _linkedObject.SetAsActive(false);
        }

    }
}
