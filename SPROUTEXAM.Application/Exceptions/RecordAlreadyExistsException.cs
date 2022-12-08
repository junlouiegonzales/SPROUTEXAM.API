using System;

namespace SPROUTEXAM.Application.Exceptions
{
    public class RecordAlreadyExistsException : Exception
    {
        public RecordAlreadyExistsException(string message) : base(message)
        {
        }
    }
}