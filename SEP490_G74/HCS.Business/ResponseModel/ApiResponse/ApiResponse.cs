﻿using System.Net;

namespace HCS.Business.ResponseModel.ApiResponse
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode { get; private set; }
        public bool IsSuccess { get; private set; }
        public string ErrorMessage { get; private set; } = string.Empty;
        public object? Result { get; private set; }

        public ApiResponse SetOk(object? result)
        {
            IsSuccess = true;
            StatusCode = HttpStatusCode.OK;
            Result = result;
            return this;
        }

        public ApiResponse SetNotFound(object? result = null, string? message = null)
        {
            IsSuccess = false;
            StatusCode = HttpStatusCode.NotFound;
            if (!string.IsNullOrEmpty(message))
            {
                ErrorMessage = message;
            }
            Result = result;
            return this;
        }

        public ApiResponse SetBadRequest(object? result = null, string? message = null)
        {
            IsSuccess = false;
            StatusCode = HttpStatusCode.BadRequest;
            if (message != null)
            {
                ErrorMessage = message;
            }
            Result = result;
            return this;
        }

        public ApiResponse SetApiResponse(HttpStatusCode statusCode, bool isSuccess, string? message = null, object? result = null)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            if (message != null)
            {
                ErrorMessage = message;
            }
            Result = result;
            return this;
        }
    }
}
