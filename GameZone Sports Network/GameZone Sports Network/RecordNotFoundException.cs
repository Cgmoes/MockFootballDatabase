﻿using System;
using System.Runtime.Serialization;

namespace Data
{
    [Serializable]
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string key)
           : base($"The requested record with key [{key}] does not exist.")
        {
        }

        protected RecordNotFoundException(SerializationInfo serializationInfo, StreamingContext streamingContext)
           : base(serializationInfo, streamingContext)
        {
        }
    }
}