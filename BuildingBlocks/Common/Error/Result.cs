using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Error
{
    public class Result
    {
        protected Result (bool isSuccess, Error error)
        {
            if(isSuccess && error != Error.None)
            {
                throw new InvalidOperationException("A successful result cannot contain an error.");
            }

            if(!isSuccess && error == Error.None)
            {
                throw new InvalidOperationException("A failure result must contain an error.");
            }

            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess { get; }
        public Error Error { get; }

        public bool IsFailure => !IsSuccess;

        public static Result Success() => new Result(true, Error.None);

        public static Result Failure(Error error) => new Result(false, error);
    }
}
