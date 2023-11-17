using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Core.Contracts
{
    public class Result
    {
        public Result(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }
        public Result(string errorMessage, bool isSuccess = false) 
        {
            Message = errorMessage;
            IsSuccess = isSuccess;
        }
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
    }
}
