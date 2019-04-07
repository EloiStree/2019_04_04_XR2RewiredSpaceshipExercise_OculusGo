using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MorseValueWithOrigine : MorseValueInterface {

    public MorseValueWithOrigine(string emittorName, params MorseKey[] keys): this(emittorName, new MorseValue(keys))
    {}
    public MorseValueWithOrigine(string emittorName, MorseValue value) {
        m_emittorName = emittorName;
        m_morse = value;
    }

    [SerializeField]
    MorseValue m_morse;
    public MorseValue GetMorseValue() { return m_morse;}

    [SerializeField]
    string m_emittorName;
    public string GetEmittorName() {
        return m_emittorName;
    }
    public MorseKey[] GetValue()
    {
        return m_morse.GetValue();
    }
}
