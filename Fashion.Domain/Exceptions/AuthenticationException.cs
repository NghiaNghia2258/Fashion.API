﻿namespace Fashion.Domain.Exceptions;

public class AuthenticationException : Exception
{
    public AuthenticationException() { }
    public AuthenticationException(string message) : base(message) { }
    public AuthenticationException(string message, Exception inner) : base(message, inner) { }
    protected AuthenticationException(
      System.Runtime.Serialization.SerializationInfo info,
      System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

}
