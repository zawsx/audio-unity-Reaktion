//
// Reaktion - An audio reactive animation toolkit for Unity.
//
// Copyright (C) 2013, 2014 Keijiro Takahashi
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Reaktion {

// Enable only on UGUI enabled versions (requiring UnityEvent)
#if UNITY_4_6 || UNITY_5_0

[AddComponentMenu("Reaktion/Gear/Generic Trigger Gear")]
public class GenericTriggerGear : MonoBehaviour
{
    public ReaktorLink reaktor;
    public float threshold = 0.9f;
    public float interval = 0.1f;
    public UnityEvent target;

    float previousOutput;
    float triggerTimer;

    void Awake()
    {
        reaktor.Initialize(this);
    }

    void Update()
    {
        if (triggerTimer <= 0.0f && reaktor.Output >= threshold && previousOutput < threshold)
        {
            target.Invoke();
            triggerTimer = interval;
        }
        else
        {
            triggerTimer -= Time.deltaTime;
        }
        previousOutput = reaktor.Output;
    }
}

#endif

} // namespace Reaktion
