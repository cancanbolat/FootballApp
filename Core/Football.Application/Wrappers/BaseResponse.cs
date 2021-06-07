using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.Application.Wrappers
{
    public class BaseResponse
    {
        public BaseResponse()
        {
            Success = true;
        }

        public bool Success { get; set; }
        public string Message { get; set; }

        public void SetException(Exception ex)
        {
            Success = false;
            Message = ex.Message;
        }
    }
}
