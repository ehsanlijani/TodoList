using System.ComponentModel;

namespace TodoList.Application.Wrappers;

public enum ErrorType
{
    [Description("Bad Request")]
    Validation = 400,

    [Description("Internal Server Error")]
    Failure = 500,

    [Description("Not Found")]
    NotFound = 404,
}



