using System;

namespace MHalas.BGM.Base.Exceptions
{
    public class NotFoundInDatabaseException : Exception
    {
        public NotFoundInDatabaseException() 
            : base("Element you`re trying to find does not exist.")
        {
        }
    }
}
