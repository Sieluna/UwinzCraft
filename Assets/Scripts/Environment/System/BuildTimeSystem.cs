using System;
using System.Runtime.InteropServices;
using Environment.Data;
using UnityEngine;

namespace Environment.System
{
    public class BuildTimeSystem
    {
        private TimePrefab m_Data;
        private float m_TimeProgression = 0f;
        
        public BuildTimeSystem(TimePrefab data) => this.m_Data = data;

        public void Init()
        {
            m_TimeProgression = m_Data.dayCycleLength > 0f ? 0.4f / m_Data.dayCycleLength : 0f;
        }

        public void Refresh()
        {
            if (Application.isPlaying)
            {
                m_Data.time += m_TimeProgression * Time.deltaTime;
                if (m_Data.time >= 24f)
                {
                    m_Data.time = 0f;
                }
            }
        }
    }
}