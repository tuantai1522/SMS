namespace SMS.UseCases.Exceptions;

public sealed class DuplicateKeyException(string message, Exception inner) : Exception(message, inner);