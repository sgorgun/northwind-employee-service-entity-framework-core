﻿namespace NorthwindEmployeeEfCoreService.Tests;

/// <summary>
/// Represents an exception that is thrown when there is an error related to a SQL script.
/// </summary>
public class SqlScriptException : DbException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SqlScriptException"/> class.
    /// </summary>
    public SqlScriptException()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SqlScriptException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public SqlScriptException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SqlScriptException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="innerException">The exception that is the cause of the current exception.</param>
    public SqlScriptException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}