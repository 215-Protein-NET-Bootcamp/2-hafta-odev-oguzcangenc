﻿using System;

namespace EmployeeTracking.Base
{
    public class MessageResultException : Exception
    {
        public MessageResultException()
        {
        }

        public MessageResultException(string message) : base(message)
        {
        }

        public MessageResultException(string message, Exception inner) : base(message, inner)
        {
        }
    }


}
