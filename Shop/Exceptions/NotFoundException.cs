using System;

namespace Shop.Exceptions
{
    public class NotFoundException : Exception
    {
        public int UserId { get; }

        public NotFoundException(string message, int userId) : base(message)
        {
            UserId = userId;
        }

    }
}