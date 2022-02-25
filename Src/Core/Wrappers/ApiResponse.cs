using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Wrappers
{
    public class ApiResponse<T>
    {
        public ApiResponse() { }

        public ApiResponse(T data, string message = null)
        {
            Success = true;
            Message = message;
            Data = data;
        }
        public ApiResponse(string message)
        {
            Success = false;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
    }
}
