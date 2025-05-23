﻿using Microsoft.AspNetCore.Http;

namespace API.DTO
{
    public class ApiException
    {
       
        public ApiException(int statusCode, string message, string? details = null)
        {
            StatusCode = statusCode;
            Message = message;
            Details = details;
          
        }

        public int StatusCode { get; }
        public string Message { get; }
        public string? Details { get; }
    }
}
