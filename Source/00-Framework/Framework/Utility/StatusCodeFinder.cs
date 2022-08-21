﻿using Framework.Exceptions;
using Grpc.Core;
using System.Net;

namespace Framework.Utility;

public static class StatusCodeFinder
{
    public static HttpStatusCode FindHttpStatusCode(Exception exception)
    {
        return exception switch
        {
            EShopException => FindHttpStatusCode(((EShopException)exception).ExceptionStatus),
            UnauthorizedAccessException => HttpStatusCode.Unauthorized,
            AccessViolationException => HttpStatusCode.Forbidden,
            InvalidOperationException when exception.Message.Contains("no elements") => HttpStatusCode.NotFound,
            _ => HttpStatusCode.InternalServerError,
        };
    }

    public static HttpStatusCode FindHttpStatusCode(ExceptionStatus status)
    {
        return status switch
        {
            ExceptionStatus.OK => HttpStatusCode.OK,

            ExceptionStatus.Unauthenticated => HttpStatusCode.Unauthorized,
            ExceptionStatus.InvalidArgument => HttpStatusCode.BadRequest,
            ExceptionStatus.AlreadyExists => HttpStatusCode.BadRequest,
            ExceptionStatus.OutOfRange => HttpStatusCode.BadRequest,
            ExceptionStatus.PermissionDenied => HttpStatusCode.Forbidden,
            ExceptionStatus.NotFound => HttpStatusCode.NotFound,

            ExceptionStatus.Unavailable => HttpStatusCode.InternalServerError,
            ExceptionStatus.DataLoss => HttpStatusCode.InternalServerError,
            ExceptionStatus.Cancelled => HttpStatusCode.InternalServerError,
            ExceptionStatus.Unknown => HttpStatusCode.InternalServerError,
            ExceptionStatus.ResourceExhausted => HttpStatusCode.InternalServerError,
            ExceptionStatus.FailedPrecondition => HttpStatusCode.InternalServerError,
            ExceptionStatus.Aborted => HttpStatusCode.InternalServerError,
            ExceptionStatus.Unimplemented => HttpStatusCode.InternalServerError,
            ExceptionStatus.Internal => HttpStatusCode.InternalServerError,
            ExceptionStatus.DeadlineExceeded => HttpStatusCode.GatewayTimeout,
            _ => HttpStatusCode.InternalServerError,
        };
    }

    public static StatusCode FindGrpcStatusCode(Exception exception)
    {
        return exception switch
        {
            EShopException => FindGrpcStatusCode(((EShopException)exception).ExceptionStatus),
            UnauthorizedAccessException => StatusCode.Unauthenticated,
            AccessViolationException => StatusCode.PermissionDenied,
            InvalidOperationException when exception.Message.Contains("no elements") => StatusCode.NotFound,
            _ => StatusCode.Internal,
        };
    }

    public static StatusCode FindGrpcStatusCode(ExceptionStatus status)
    {
        return (StatusCode)status;
    }
}